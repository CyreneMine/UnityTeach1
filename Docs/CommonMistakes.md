# CommonMistakes

这里用于长期记录 Unity 学习过程中反复出现的问题。每次代码审查或调试后，如果发现同类问题重复出现，应追加到对应分类下。

## 生命周期理解错误

- 暂无记录。

## Inspector 引用为空

- 2026-05-30：`Lesson15` 中将序列化字段 `light` 重命名为 `candleLight` 后，场景里原本保存的 Inspector 引用不会自动变成新字段名，导致脚本可能出现空引用。
  - 问题类型：序列化字段改名 / Inspector 引用未重新保存。
  - 排查方法：检查场景 YAML 或 Inspector 中脚本组件字段，确认是否存在新字段 `candleLight`、`directionalLight`，而不是只剩旧字段 `light`。
  - 经验总结：字段改名后，要么在 Inspector 中重新拖引用并保存场景，要么使用 `UnityEngine.Serialization.FormerlySerializedAs` 帮 Unity 迁移旧字段数据。

## Prefab 覆盖问题

- 暂无记录。

## Input System 配置问题

- 初始观察：项目中已经出现旧输入系统和新 Input System 对照练习。后续检查输入相关 bug 时，需要同时确认 Input Action 资源、生成的 C# 类、Action Map 启用状态、事件订阅和取消订阅。

## 动画参数错误

- 暂无记录。

## Rigidbody / Collider 使用问题

- 2026-05-31：`Lesson16` 中子弹、地面、敌人的碰撞逻辑依赖 Tag、Collider、Trigger 和 Rigidbody 同时配置正确。
  - 问题类型：物理碰撞配置遗漏 / Tag 与代码判断不一致。
  - 排查方法：确认 `Bullet` Prefab 带 `Rigidbody` 和 `SphereCollider(Is Trigger)`；确认地面 Tag 为 `Ground`，敌人 Tag 为 `Enemy`，子弹 Tag 为 `Bullet`；确认 `ProjectSettings/TagManager.asset` 已提交。
  - 经验总结：碰撞代码看起来正确但不触发时，优先检查 Inspector 配置，而不是只盯脚本。

## 其他常见问题

- 2026-06-29：实践小项目 P77「音效数据逻辑」中，设置窗口关闭时调用 `GameDataMgr.Instance.SaveData()` 保存数据，但重新运行后设置看起来没有生效。
  - 问题类型：PlayerPrefs 默认值覆盖 / 首次初始化标记理解错误 / 反射加载覆盖字段默认值。
  - 现象：`MusicData` 中曾经写过 `public bool isFirst = true;`，但通过 `PlayerPrefsDataMgr.LoadData(typeof(MusicData), "Music")` 加载后，`isFirst` 仍然变成 `false`，导致初始化判断失效。
  - 原因：`LoadData()` 先通过 `Activator.CreateInstance(type)` 创建对象，此时字段默认值确实会生效；但随后它遍历字段并执行 `fieldInfo.SetValue(data, LoadValue(...))`。当 PlayerPrefs 中还没有对应 bool key 时，`PlayerPrefs.GetInt(keyName)` 默认返回 `0`，于是 `LoadValue()` 返回 `false`，又把对象里原本的 `isFirst = true` 覆盖掉。
  - 经验总结：最终赋给 `musicData` 的不是单纯 C# 默认初始化后的对象，而是 `PlayerPrefsDataMgr` 按自己读取规则处理后的对象。字段默认值会先执行，但如果加载逻辑没有区分“key 不存在”和“值就是 false / 0”，就会被默认读取结果覆盖。
  - 推荐做法：使用 `notFirst` 这类标记时，第一次初始化后要把它设为 `true` 并保存；更稳的方案是让数据管理器使用 `PlayerPrefs.HasKey()` 判断是否已有存档，或在加载失败/没有 key 时保留对象的字段默认值。

- 2026-05-26：`Lesson11` 调试时，之前用于测试 API 的空 GameObject 上仍然挂着 `Lesson11` 脚本，导致场景中存在两个脚本实例。正确挂在 `Tank` 上的实例可以找到子物体 `Tank_Head`，但空对象实例找不到 `Tank_Head`，于是 `Update()` 中访问 `tankHead.Rotate(...)` 时出现 `NullReferenceException`。
  - 问题类型：脚本挂载对象错误 / 多实例脚本未关闭。
  - 排查方法：在 Hierarchy 搜索 `t:Lesson11`，确认场景里有几个对象挂了同一个脚本；日志中使用 `Debug.Log($"脚本挂在:{gameObject.name}", this);`，方便点击 Console 直接定位对象。
  - 经验总结：Unity 中每一个激活的、挂有脚本的 GameObject 都会独立执行 `Awake`、`Start`、`Update` 等生命周期，不会只执行当前“想调试”的那个对象。

- 2026-05-26：`Lesson12` 实现鼠标滚轮控制炮管俯仰时，最初误以为 `Math.Clamp` / `Mathf.Clamp` 会自动限制 Transform 旋转。
  - 问题类型：Clamp 返回值未赋值 / Transform 旋转理解不清。
  - 排查方法：确认 Clamp 的返回值是否被保存或赋回 `localEulerAngles`；确认代码是否仍在使用 `Rotate()` 累加旋转。
  - 经验总结：Clamp 只计算并返回限制后的值，不会自动修改对象状态。需要把结果赋给变量或 Transform。

- 2026-05-26：限制炮管俯仰角时，直接用 `localEulerAngles.x` 和 `-20~20` 比较会出问题，因为 Unity 欧拉角通常显示为 `0~360`。
  - 问题类型：Unity 欧拉角范围理解错误。
  - 排查方法：打印 `gun.localEulerAngles.x`，观察向负方向旋转时是否变成 `359`、`350`、`340` 这类值。
  - 经验总结：限制负角度前，先把 `0~360` 转换成 `-180~180`，例如 `if (x > 180) x -= 360;`。
