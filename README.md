# UnityTeach1

## 项目简介

这是一个 Unity 学习练习项目，用于跟随唐老狮 Unity 教程完成基础知识、脚本、场景、Prefab、输入系统、Transform 控制、Camera 组件、坐标转换、光源组件、物理碰撞检测、物体位移方式、音频基础、UGUI、本地数据持久化等内容的练习。

本项目不只是保存代码，也会长期记录学习过程、常见错误、教程旧写法与当前 Unity 推荐写法之间的差异。

## 当前学习来源

唐老狮 Unity 教程练习。

教程内容大约来自 2022 年左右，因此本项目会在学习原教程写法的同时，记录这些写法在当前 Unity 版本中的适用性，以及是否存在更推荐的新做法。

## 当前学习阶段

当前已完成到 `Lesson21 / Audio 基础理论`，并已补完 `PlayerPrefs`、`UGUI`、`Json 持久化` 三部分前置内容。

最近几节主要是理论内容：物体位移方式、音频导入参数、`AudioSource` / `AudioListener` 组件、`AudioSource` API、麦克风录制与 `AudioClip.GetData()`。

当前项目已经从“阶段暂停补课”切回“制作唐老狮入门小项目”。实践小项目视频范围已记录为 `P67-P99`，目前已完成到 `P86 / 玩家基础移动旋转摄像机跟随等`，GameScene 已进入核心玩法阶段。下一步进入 `P87 / 玩家小地图`，随后继续武器、子弹、奖励和敌人逻辑。旧式 `OnGUI` 只作为了解内容，后续项目优先使用 UGUI。

当前项目环境：

- Unity：`6000.3.10f1`
- Input System：`1.18.0`

## 已完成内容

- Unity 项目基础结构
- 多个教程小节脚本目录
- 多个练习场景
- Prefab 练习资源
- 旧输入系统练习
- 新 Input System 练习
- `Lesson11` 坦克移动、车体旋转和炮塔旋转
- `Lesson11` 新旧输入系统对照
- `Lesson12` 鼠标滚轮控制炮管上下俯仰
- `Lesson12` 炮管俯仰角度限制
- 右键按住时摄像机围绕坦克观察
- Unity 欧拉角 `0~360` 与 `-180~180` 转换理解
- `Lesson13` Camera 分屏显示
- `Lesson13` Camera 跟随坦克
- `Lesson13` Layer + Culling Mask 分层渲染
- `Lesson13` 多 Camera 同窗口显示不同对象
- `Lesson14` 世界坐标转屏幕坐标
- `Lesson14` 鼠标点击位置转世界坐标并创建 Cube
- `Lesson15` 点光源模拟蜡烛摆动和亮度变化
- `Lesson15` 方向光旋转模拟昼夜变化
- `Lesson16` 鼠标左键发射子弹
- `Lesson16` Trigger 碰撞检测、子弹销毁和敌人血量销毁
- `Lesson17` 物体位移方式理论总结
- `Lesson18` AudioClip 音频导入参数
- `Lesson19` AudioSource 和 AudioListener 组件参数
- `Lesson20` AudioSource 常用 API
- `Lesson21` 麦克风录制、播放录音和 AudioClip 采样数据读取
- PlayerPrefs 简单本地数据保存
- UGUI 基础界面制作
- Json 持久化结构化本地数据保存
- 实践小项目 P67-P86：小项目准备内容、开始界面、设置界面、音效数据逻辑、排行榜界面、排行榜数据逻辑、背景音乐、GameScene 基础场景、游戏主界面、设置/退出面板复用、坦克基类、玩家基础移动旋转和摄像机跟随
- Git 仓库初始化和 GitHub 推送
- Unity 专用 `.gitignore`
- 项目级助手规则 `AGENTS.md`
- 学习记录文档目录 `Docs/`
- GPT 辅助学习过程记录目录 `Gpt对话协助/`

## 项目结构

```text
Assets/
  Prefabs/             Prefab 练习资源
  Scenes/              Unity 场景
  Scripts/             唐老狮教程分节脚本和练习场景
  PlayerController.*   Input System 输入配置和生成代码
Packages/              Unity 包配置
ProjectSettings/       Unity 项目设置，包括 Layer/Tag 等
Docs/                  学习进度、常见错误和教程笔记
Gpt对话协助/           通过 GPT 辅助解决问题的学习记录
AGENTS.md              项目级助手协作规则
README.md              项目说明
```

## 学习记录入口

- [当前学习状态](Docs/CurrentStatus.md)
- [学习进度](Docs/LearningProgress.md)
- [常见错误](Docs/CommonMistakes.md)
- [唐老狮教程笔记](Docs/TangLessonsNotes.md)
- [按 Lesson 归档](Docs/Archive/)
- [实践小项目 P67-P99 分 P 清单](Docs/Archive/SmallProject-P67-P99.md)
- [GPT 辅助学习记录](Gpt对话协助/)

## 当前重点记录

- 旧输入系统仍有现实项目价值，尤其是存量项目和小型练习。
- 新 Input System 更适合结构化输入配置、多设备和可维护项目。
- 坦克的 `A/D` 更适合做车体旋转，而不是左右平移。
- `transform.Find` 适合学习层级查找，但稳定项目中更推荐 Inspector 显式引用。
- `Mathf.Clamp` 只返回限制后的值，不会自动修改 Transform。
- Unity 的 `localEulerAngles` 常以 `0~360` 表示，限制负角度前需要转换成 signed angle。
- Camera 的 Viewport Rect 可用于分屏。
- Layer + Culling Mask 可让不同摄像机看到不同对象。
- 多 Camera 同屏时要同时关注 Clear Flags、Depth 和 Culling Mask。
- `ScreenToWorldPoint` 必须提供有意义的 `z` 深度。
- 鼠标点击场景放置物体时，实际项目中常用射线检测。
- `Point Light` 可用于局部光源，`Directional Light` 可用于整体方向光。
- 重命名 `[SerializeField]` 字段后，要检查 Inspector 引用是否重新保存。
- Trigger 碰撞检测需要同时关注 Collider、Rigidbody、Is Trigger 和 Tag。
- 修改 Tag 后需要提交 `ProjectSettings/TagManager.asset`。
- Transform 移动和 Rigidbody 物理移动的核心区别是是否交给物理系统处理。
- `AddForce` 更偏物理受力，直接改速度更偏明确控制运动结果。
- 音频学习需要同时关注资源导入、场景播放组件、代码控制和录音数据。
- `OnGUI` 已偏旧，后续入门项目优先使用 UGUI。
- PlayerPrefs 适合保存音量、最高分、设置项和简单进度。
- Json 持久化适合保存结构化数据，例如关卡进度、角色数据、背包、配置和本地存档。
- 自定义 PlayerPrefs 数据管理器读取不存在的 key 时，要注意默认返回值可能覆盖 C# 字段初始化值。
- 排行榜排序应先明确业务规则：当前小项目采用分数高优先，分数相同再按用时短优先。
- 同名玩家重复提交成绩时，当前项目只保留最好成绩；新高分要同时覆盖分数和时间，不能把新分数和旧时间拼成错误记录。
- Begin 场景背景音乐通过 `BKMusic` 包装 `AudioSource`，并由 `GameDataMgr` 在设置变化时同步音乐开关和音量。
- Begin 场景 UI 已调整为独立 `UICamera` 渲染，Canvas 使用 Screen Space - Camera，并配合 CanvasScaler 做分辨率适配。
- GameScene 设置面板复用时要避免继续依赖 `BeginPanel`；跨场景静态 `Instance` 可能留下已销毁对象引用。
- P86 玩家控制同时保留旧版 `Input` 和新版 `Unity Input System` 对照，新项目更推荐把正式输入流程逐步迁移到 Input System。

## 后续计划

- 每完成一个教程小节后，更新 `Docs/CurrentStatus.md`，并在 `Docs/Archive/` 中维护对应 Lesson 归档。
- `LearningProgress.md` 和 `TangLessonsNotes.md` 作为索引使用，避免每次检查时读取过长文档。
- 每次收尾同步检查 README 是否需要更新。
- 每次代码审查后，整理做得好的地方和需要改进的问题。
- 将重复出现的 Unity 问题沉淀到 `CommonMistakes.md`。
- 对教程旧写法和当前 Unity 推荐写法做对照记录。
- 继续保持新旧输入系统对照学习。
- 后续学习射线检测时，对照理解 `ScreenToWorldPoint` 和 `ScreenPointToRay`。
- 后续学习 Rigidbody 运动时，对照理解 Transform 直接移动和 Rigidbody 物理移动的区别。
- PlayerPrefs、UGUI、Json 持久化前置内容已完成。
- 接下来继续制作唐老狮入门教程小项目。
- 当前小项目视频定位：P86 已完成；下一步 P87「玩家小地图」。
- 优先用 UGUI 做菜单、设置面板、游戏界面和结算界面。
- 使用 PlayerPrefs 保存音量、简单设置等轻量数据。
- 使用 Json 保存结构化游戏数据或更完整的本地存档。
- 在合适的小节节点创建 Git commit，并在明确要求时 push 到 GitHub。
