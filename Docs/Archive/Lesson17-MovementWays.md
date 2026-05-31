# Lesson17 - 物体位移方式理论

## 教程/小节名称

唐老狮 Unity 教程 - Lesson17 物体位移方式理论

## 本节目标

总结 Unity 中让一个物体产生位移的常见方式，理解 Transform 直接移动和 Rigidbody 物理移动之间的区别。

## 已完成内容

- 总结直接在 `Update()` 等生命周期函数中修改 `transform.position`。
- 总结使用 Transform 提供的 `Translate()` 方法移动物体。
- 总结通过 `Rigidbody.AddForce()` 给物体施加世界方向的力。
- 总结通过 `Rigidbody.AddRelativeForce()` 给物体施加自身局部方向的力。
- 总结通过修改 Rigidbody 速度属性直接改变运动速度。
- 新建 `Assets/Scripts/Lesson17/` 目录，保留默认空场景和空脚本作为本节理论小节占位。

## 四种位移方式对比

### 直接修改 Position

直接给 `transform.position` 赋值，控制最直接，适合简单位移、瞬移、非物理对象位置更新。

特点：

- 不依赖 Rigidbody。
- 不走物理受力逻辑。
- 对需要严肃物理碰撞的对象要谨慎使用。

### 使用 Translate

调用 `transform.Translate()` 让物体按指定方向移动，本质仍然是改变 Transform。

特点：

- 写法比手动改 position 更像“沿某方向移动”。
- 可以选择世界坐标或自身局部坐标方向。
- 适合初学阶段理解方向和位移。

### 使用 AddForce / AddRelativeForce

通过 Rigidbody 给物体施加力，让物体在物理系统中产生运动。

特点：

- 需要 Rigidbody。
- 会受到质量、阻力、重力、碰撞等物理因素影响。
- `AddForce()` 使用世界方向，`AddRelativeForce()` 使用物体自身局部方向。

### 直接修改 Rigidbody 速度

直接设置 Rigidbody 的速度，让物体立刻获得指定运动速度。

特点：

- 需要 Rigidbody。
- 控制结果明确。
- 会覆盖当前速度，需要注意是否破坏其他力产生的效果。

## 做得好的地方

- 能把 Lesson16 的子弹移动和本节 Rigidbody 运动理论衔接起来理解。
- 能意识到不是所有练习都需要提前使用最正式的物理写法，跟着教程节奏学习更稳。
- 这节理论没有硬塞练习代码，避免为了写代码而偏离小节目标。

## 当前问题

- 当前阶段主要是理论理解，还需要后续通过实际案例观察不同移动方式的差异。

## 推荐改进方向

- 后续写移动逻辑前，先判断对象是否需要参与物理系统。
- 如果对象只是界面、镜头、简单演示物体，可以考虑 Transform 移动。
- 如果对象需要受力、碰撞、重力或和其他物理对象互动，应优先考虑 Rigidbody 相关移动。
- 后续可以回看 Lesson16 子弹，比较 `Translate`、速度赋值、施加力三种方案的差异。

## 教程写法与当前 Unity 选择

- 教程总结的四种位移方式在当前 Unity 版本中仍然可用。
- 当前 Unity 版本中，`Rigidbody.velocity` 在部分新 API 语境下会看到 `linearVelocity` 相关概念，但入门阶段理解“直接改速度”这个类别更重要。
- 初学阶段先掌握使用场景和差异，不必急着引入复杂运动框架。

## 相关提交

- `study: 完成唐老狮教程 - Lesson17 物体位移方式理论`
