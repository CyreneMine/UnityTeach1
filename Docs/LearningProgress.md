# LearningProgress

本文件现在作为学习进度索引和最近变更记录使用。完整小节总结按 Lesson 归档到 `Docs/Archive/`。

日常检查时优先读取：

- `Docs/CurrentStatus.md`
- `README.md`
- 当前 Lesson 对应脚本/场景

需要复盘历史时，再读取 `Docs/Archive/` 中对应 Lesson 文件。

## 当前进度

- 当前完成：Lesson17 物体位移方式理论
- 下一阶段：继续学习 Lesson18 或下一 P 内容
- 当前项目环境：Unity `6000.3.10f1`，Input System `1.18.0`
- 最近提交：`study: 完成唐老狮教程 - Lesson17 物体位移方式理论`

## 归档索引

- [Lesson11 - Input System 与坦克控制](Archive/Lesson11-InputSystem.md)
- [Lesson12 - Screen 扩展与炮管俯仰](Archive/Lesson12-ScreenAndGunPitch.md)
- [Lesson13 - Camera 组件练习](Archive/Lesson13-Camera.md)
- [Lesson14 - 坐标转换练习](Archive/Lesson14-CoordinateConversion.md)
- [Lesson15 - 光源组件练习](Archive/Lesson15-Light.md)
- [Lesson16 - 物理系统碰撞检测练习](Archive/Lesson16-PhysicsCollision.md)
- [Lesson17 - 物体位移方式理论](Archive/Lesson17-MovementWays.md)
- [文档结构调整记录](Archive/DocsReorganization.md)

## 最近变更

### 2026-05-31 Lesson17 物体位移方式理论

#### 教程/小节名称

唐老狮 Unity 教程 - Lesson17 物体位移方式理论

#### 本节目标

总结 Unity 中让一个物体产生位移的常见方式，理解 Transform 移动和 Rigidbody 物理移动的区别。

#### 已完成内容

- 总结直接修改 `transform.position` 的移动方式。
- 总结使用 `transform.Translate()` 的移动方式。
- 总结通过 `Rigidbody.AddForce()` 和 `Rigidbody.AddRelativeForce()` 施加力的移动方式。
- 总结直接修改 `Rigidbody` 速度属性的移动方式。
- 新建 `Assets/Scripts/Lesson17/` 目录，保留本节理论小节的空场景和空脚本占位。

#### 做得好的地方

- 能把 Lesson16 中“子弹 Transform 移动”和后续 Rigidbody 运动内容衔接起来理解。
- 能区分教程当前阶段的写法和后续正式物理运动写法，不急着提前改掉练习代码。
- 这节没有强行写练习代码，符合题目只有理论总结的特点。

#### 当前问题

- 当前还只是理论理解，后续需要通过实际 Rigidbody 示例观察不同移动方式的手感和物理表现。

#### 推荐改进方向

- 后续遇到角色、子弹、可推动物体时，先判断对象是否需要参与物理系统，再决定用 Transform 还是 Rigidbody。
- 学到 Rigidbody 运动后，可以回看 Lesson16 子弹移动，对比 `Translate`、`velocity`、`AddForce` 的区别。

#### 下一节建议

继续学习物理系统后续内容时，重点观察不同 ForceMode、速度赋值和 FixedUpdate 的使用场景。

### 2026-05-31 Lesson16 物理系统碰撞检测练习

#### 教程/小节名称

唐老狮 Unity 教程 - Lesson16 物理系统碰撞检测练习

#### 本节目标

在之前 Input 和 Screen 练习的基础上，加入鼠标左键发射子弹、子弹触地销毁、子弹击中立方体 3 次后销毁立方体的功能。

#### 已完成内容

- 新建 `Assets/Scripts/Lesson16_物理系统碰撞检测/` 练习目录和 `Lesson16.unity` 场景。
- 新增 `Lesson16.cs`，使用新 Input System 的 `Fire.performed` 事件实例化子弹。
- 新增 `Bullet.prefab`，配置 `Bullet` Tag、`SphereCollider`、`Rigidbody` 和 `BulletController`。
- 新增 `BulletController.cs`，通过 `FixedUpdate()` 移动子弹，并在触发 `Ground` 或 `Enemy` 时销毁子弹。
- 新增 `EnemyController.cs`，敌人被 `Bullet` 触发时扣血，血量归零后销毁自身。
- 在 `ProjectSettings/TagManager.asset` 中新增 `Ground`、`Enemy`、`Bullet` Tag。
- 将 `ButtleController` / `buttleSpeed` 拼写调整为 `BulletController` / `bulletSpeed`。
- 将敌人死亡判断从每帧 `Update()` 轮询改为扣血后立即判断。
- 保留旧输入系统点击发射写法作为注释对照。

#### 做得好的地方

- 能把发射、子弹、敌人拆成不同脚本，各自负责自己的职责。
- 能意识到当前课程重点是 Trigger 和碰撞检测，而不是提前优化 Rigidbody 移动方式。
- 能根据教程答案和审查建议清理拼写问题、无用 using 和不必要的每帧判断。
- 能正确把 TagManager 变更纳入版本管理范围。

#### 当前问题

- 子弹移动仍使用 `Transform.Translate`，这符合当前教程节奏；后续学到 Rigidbody 运动时再对比两种方式。
- 当前用 `tag == "xxx"` 判断 Tag，在练习规模下能用；正式项目或高频碰撞中更推荐 `CompareTag()`。
- 子弹速度较快且使用离散碰撞检测，未来速度继续增大时需要关注穿透问题。

#### 推荐改进方向

- 后续学习 Rigidbody 后，可以把子弹移动改为基于 Rigidbody 的速度、力或 `MovePosition`。
- 后续项目复杂后，可以用 `CompareTag()`、Layer、接口或伤害组件替代简单字符串 Tag 判断。
- 可以继续观察 Trigger、Collider、Rigidbody 三者组合对回调触发的影响。

#### 下一节建议

继续学习物理系统相关内容时，重点区分 Trigger 回调、Collision 回调、Rigidbody 运动和 Transform 直接移动之间的差异。

### 2026-05-30 Lesson15 光源组件练习

#### 教程/小节名称

唐老狮 Unity 教程 - Lesson15 光源组件练习

#### 本节目标

通过代码结合点光源模拟蜡烛光源效果，并通过方向光旋转模拟白天黑夜变化。

#### 已完成内容

- 新建 `Assets/Scripts/Lesson15/` 练习目录和 `Lesson15.unity` 场景。
- 使用 `Point Light` 模拟蜡烛光源。
- 通过移动点光源位置模拟蜡烛左右轻微摆动。
- 通过修改 `Light.intensity` 模拟蜡烛亮度波动。
- 使用 `Directional Light` 旋转模拟昼夜变化。
- 新增 `Assets/Materials/Gray.mat` 作为场景材质练习资源。
- 调整字段命名，将 `light` 改为更明确的 `candleLight`。
- 重新在 Inspector 中保存 `candleLight` 和 `directionalLight` 引用。

#### 做得好的地方

- 能根据题目要求把 Light 组件属性和 Transform 控制结合起来。
- 能把练习重点留在“理解光源组件”上，没有过早追求复杂昼夜系统。
- 发现字段重命名后的引用问题后，选择在 Unity Inspector 中重新拖引用并保存场景，处理方式符合当前学习阶段。

#### 当前问题

- 蜡烛摆动和亮度变化目前使用边界反向逻辑，能完成练习，但效果偏机械。
- 如果后续做正式项目，可以再考虑更自然的 `Mathf.Sin`、`Mathf.PingPong` 或噪声变化。

#### 推荐改进方向

- 当前教程阶段保持现有写法即可，重点理解 `Light` 组件和 Transform 控制。
- 后续个人项目中再优化光照过渡、环境光、天空盒和后处理联动。
- 重命名序列化字段时，继续注意 Inspector 引用是否仍然存在。

#### 下一节建议

继续学习下一 P 内容时，先明确题目要练的是组件 API、坐标转换、输入系统还是场景配置，再决定是否需要把优化留到个人项目中。

### 2026-05-28 文档结构调整

#### 教程/小节名称

项目文档结构优化

#### 本节目标

将原本持续追加的长文档改为“当前摘要 + 按 Lesson 归档”的结构，减少后续检查和总结时读取超长文档造成的上下文消耗。

#### 已完成内容

- 新增 `Docs/CurrentStatus.md` 作为默认读取的当前状态摘要。
- 新增 `Docs/Archive/` 目录。
- 将 Lesson11 到 Lesson14 的完整总结迁移到独立归档文件。
- 将 `LearningProgress.md` 改为索引和最近变更记录。
- 将 `TangLessonsNotes.md` 改为教程知识点索引。
- 更新 `README.md` 和 `AGENTS.md`，记录新的文档读取流程。

#### 做得好的地方

- 保留历史总结，不丢失学习过程。
- 默认读取文件变短，后续轻量检查会更省额度。
- 按 Lesson 归档更符合唐老狮教程的学习节奏。

#### 当前问题

- 历史内容迁移后，后续需要养成每节完成时同步更新 `CurrentStatus.md` 和对应 Archive 文件的习惯。

#### 推荐改进方向

- 后续默认只读 `CurrentStatus.md`，除非用户要求复盘历史或当前问题和历史 Lesson 强相关。
- 每次完成新 Lesson 时，新建 `Docs/Archive/LessonXX-主题.md`。

#### 下一节建议

继续学习下一 P 时，先在 `CurrentStatus.md` 更新当前 Lesson，再在完成后归档到 `Docs/Archive/`。
