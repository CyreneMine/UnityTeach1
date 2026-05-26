# CommonMistakes

这里用于长期记录 Unity 学习过程中反复出现的问题。每次代码审查或调试后，如果发现同类问题重复出现，应追加到对应分类下。

## 生命周期理解错误

- 暂无记录。

## Inspector 引用为空

- 暂无记录。

## Prefab 覆盖问题

- 暂无记录。

## Input System 配置问题

- 初始观察：项目中已经出现旧输入系统和新 Input System 对照练习。后续检查输入相关 bug 时，需要同时确认 Input Action 资源、生成的 C# 类、Action Map 启用状态、事件订阅和取消订阅。

## 动画参数错误

- 暂无记录。

## Rigidbody / Collider 使用问题

- 暂无记录。

## 其他常见问题

- 2026-05-26：`Lesson11` 调试时，之前用于测试 API 的空 GameObject 上仍然挂着 `Lesson11` 脚本，导致场景中存在两个脚本实例。正确挂在 `Tank` 上的实例可以找到子物体 `Tank_Head`，但空对象实例找不到 `Tank_Head`，于是 `Update()` 中访问 `tankHead.Rotate(...)` 时出现 `NullReferenceException`。
  - 问题类型：脚本挂载对象错误 / 多实例脚本未关闭。
  - 排查方法：在 Hierarchy 搜索 `t:Lesson11`，确认场景里有几个对象挂了同一个脚本；日志中使用 `Debug.Log($"脚本挂在:{gameObject.name}", this);`，方便点击 Console 直接定位对象。
  - 经验总结：Unity 中每一个激活的、挂有脚本的 GameObject 都会独立执行 `Awake`、`Start`、`Update` 等生命周期，不会只执行当前“想调试”的那个对象。
