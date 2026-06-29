# CurrentStatus

## 当前学习状态

- 当前完成：Lesson21 音频基础理论；已补完 PlayerPrefs、UGUI、Json 持久化三部分前置内容
- 下一阶段：回到本项目，开始制作唐老狮入门小项目
- 学习来源：唐老狮 Unity 教程练习
- Unity 版本：`6000.3.10f1`
- Input System：`1.18.0`
- 当前分支：`master`
- 远程仓库：`https://github.com/CyreneMine/UnityTeach1.git`

## 最近完成

- Lesson11：新旧输入系统对照、坦克移动、车体旋转、炮塔旋转。
- Lesson12：Screen 分 P 扩展练习、鼠标滚轮控制炮管俯仰、右键摄像机观察。
- Lesson13：Camera 分屏、跟随目标、Layer + Culling Mask 分层渲染。
- Lesson14：`WorldToScreenPoint`、`ScreenToWorldPoint`、鼠标点击位置创建 Cube。
- Lesson15：点光源模拟蜡烛摆动与亮度变化，方向光旋转模拟昼夜变化。
- Lesson16：鼠标左键发射子弹、Trigger 碰撞检测、子弹触地/碰敌销毁、敌人被击中 3 次销毁。
- Lesson17：总结物体位移的四种方式：直接改 Position、`Translate`、`Rigidbody.AddForce/AddRelativeForce`、直接改 Rigidbody 速度。
- Lesson18：AudioClip 音频导入参数。
- Lesson19：`AudioSource` 和 `AudioListener` 组件参数。
- Lesson20：`AudioSource` 常用播放控制 API。
- Lesson21：麦克风录制、结束录制、播放录音和 `AudioClip.GetData()` 读取采样数据。
- 阶段补课：完成 PlayerPrefs、UGUI、Json 持久化三部分内容，具备继续制作小项目所需的 UI 和本地数据保存基础。

## 当前重点概念

- 新旧输入系统都需要认识：新项目更推荐 Input System，存量项目仍可能使用旧输入系统。
- Inspector 显式引用通常比运行时字符串查找更稳定。
- `Mathf.Clamp` 只返回限制后的值，不会自动修改 Transform。
- Unity 欧拉角常以 `0~360` 表示，限制负角度前需要转换成 signed angle。
- Camera 的 Viewport Rect 可用于分屏。
- Layer + Culling Mask 可让不同摄像机看到不同对象。
- `ScreenToWorldPoint` 必须提供有意义的 `z` 深度。
- 鼠标点击场景放置物体时，实际项目中常用射线检测。
- `Light.intensity` 可以通过代码控制亮度变化。
- `Directional Light` 的 Transform 旋转会改变全局光照方向，可用于理解昼夜变化的基础原理。
- Trigger 碰撞需要至少一方带 Rigidbody，并且对象 Tag 要和代码判断一致。
- 修改 Tag 需要提交 `ProjectSettings/TagManager.asset`。
- Transform 位移和 Rigidbody 物理位移属于不同思路，是否参与物理系统是重要区别。
- `AddForce` 表示持续施力或冲量，直接改速度表示立刻覆盖当前运动速度。
- 音频学习分为导入参数、场景播放组件、代码控制 API、麦克风录制与采样数据读取。
- `OnGUI` 已偏旧，后续入门项目优先使用 UGUI；PlayerPrefs 用于保存简单本地设置或进度。
- Json 持久化适合保存结构化数据，例如关卡进度、背包、配置表缓存或比 PlayerPrefs 更复杂的本地存档。

## 当前常见风险

- 多个脚本实例同时启用，导致重复执行生命周期或控制同一对象。
- Inspector 引用未绑定导致空引用。
- 修改 Layer/Tag/Input Actions 后忘记提交 `ProjectSettings` 或生成代码。
- Unity 场景文件中的临时摄像机位置、Transform 变化混入提交。
- 重命名 `[SerializeField]` 字段后，需要重新保存 Inspector 引用，或使用 `FormerlySerializedAs` 保留旧字段迁移。
- 使用 Tag 驱动碰撞逻辑时，要确认场景对象和 Prefab 的 Tag 都已正确设置。
- 文档收尾时遗漏 README 或 CurrentStatus。

## 当前学习路线调整

- PlayerPrefs、UGUI、Json 持久化前置内容已完成。
- 本项目从阶段暂停切回小项目制作阶段。
- 后续继续完成唐老狮入门教程项目，并优先使用 UGUI 代替旧式 `OnGUI`。
- `OnGUI` 只需要能看懂教程写法和历史用途，不作为后续项目主力 UI 方案。

## 默认检查流程

后续轻量检查时，优先读取：

- `Docs/CurrentStatus.md`
- `README.md`
- 当前 Lesson 的脚本和场景
- `git status`
- 当前变更的 `git diff`

只有在需要复盘历史时，才读取 `Docs/Archive/` 中对应 Lesson 文件。

## 最近提交

- `study: 更新 Unity 教程练习记录`
