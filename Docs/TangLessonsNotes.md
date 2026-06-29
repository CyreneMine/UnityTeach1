# TangLessonsNotes

本文件现在作为唐老狮教程知识点索引使用。完整知识点记录按 Lesson 归档到 `Docs/Archive/`。

日常检查时优先读取 `Docs/CurrentStatus.md`；需要查某节教程细节时，再打开对应 Archive 文件。

## 当前环境

- Unity 版本：`6000.3.10f1`
- Input System：`1.18.0`
- 教程来源：唐老狮 Unity 教程练习
- 教程时间背景：约 2022 年

## 知识点索引

### 输入系统

归档文件：[Lesson11 - Input System 与坦克控制](Archive/Lesson11-InputSystem.md)

重点：

- 旧输入系统仍适合理解每帧读取输入，也常见于存量项目。
- 新 Input System 更适合结构化输入配置、多设备和可维护项目。
- 运行时应避免新旧控制脚本同时启用并控制同一对象。

### Screen 扩展、滚轮与炮管俯仰

归档文件：[Lesson12 - Screen 扩展与炮管俯仰](Archive/Lesson12-ScreenAndGunPitch.md)

重点：

- `Mathf.Clamp` 只返回限制后的值，不会自动修改 Transform。
- `Rotate()` 是累加旋转，限制俯仰角更适合直接设置 `localEulerAngles`。
- Unity 欧拉角常显示为 `0~360`，限制负角度前需要转换成 signed angle。

### Camera 组件

归档文件：[Lesson13 - Camera 组件练习](Archive/Lesson13-Camera.md)

重点：

- Viewport Rect 可用于分屏。
- Layer + Culling Mask 可让不同摄像机看到不同对象。
- 多 Camera 同屏时要同时关注 Clear Flags、Depth 和 Culling Mask。
- 实际项目可继续学习 Cinemachine、URP Camera Stack、Render Texture。

### 坐标转换

归档文件：[Lesson14 - 坐标转换练习](Archive/Lesson14-CoordinateConversion.md)

重点：

- `WorldToScreenPoint` 把世界坐标转换为屏幕坐标。
- `ScreenToWorldPoint` 把屏幕坐标转换为世界坐标，但必须提供有意义的 `z` 深度。
- 鼠标点击场景放置物体时，实际项目中更常用 `ScreenPointToRay` + 射线检测。

### 光源组件

归档文件：[Lesson15 - 光源组件练习](Archive/Lesson15-Light.md)

重点：

- `Point Light` 适合模拟局部光源，例如蜡烛、灯泡、火把。
- `Light.intensity` 可以通过代码动态改变，用来模拟亮度波动。
- `Directional Light` 代表方向性全局光，旋转它可以改变整体受光方向。
- 教程中用 Transform 和 intensity 直接控制光源的写法现在仍然可用，适合初学阶段理解 Light 组件。
- 正式项目中的昼夜系统通常还会联动环境光、天空盒、后处理、阴影和渲染管线设置。

### 物理系统碰撞检测

归档文件：[Lesson16 - 物理系统碰撞检测练习](Archive/Lesson16-PhysicsCollision.md)

重点：

- `OnTriggerEnter(Collider other)` 用于 Trigger 碰撞回调，需要 Collider 配置为 `Is Trigger`。
- Trigger 回调通常要求参与检测的对象中至少一方带有 Rigidbody。
- 用 Tag 判断对象类型是教程阶段很直观的写法，现在仍然可用。
- Unity 更推荐 `CompareTag()` 做 Tag 比较；当前小练习中 `tag == "xxx"` 也能正常工作。
- 子弹带 Rigidbody 但使用 Transform 移动可以完成当前练习；后续学习 Rigidbody 运动时再切换到更物理的写法。

### 物体位移方式

归档文件：[Lesson17 - 物体位移方式理论](Archive/Lesson17-MovementWays.md)

重点：

- 直接修改 `transform.position` 是瞬移式的位置赋值，不经过物理系统求解。
- `transform.Translate()` 是基于 Transform 的位移 API，本质仍是直接改变 Transform。
- `Rigidbody.AddForce()` / `AddRelativeForce()` 通过施加力让物体运动，更符合物理模拟思路。
- 直接修改 Rigidbody 速度会立刻覆盖当前速度，适合需要明确控制速度的场景。
- 需要参与碰撞、受力、重力等物理表现时，优先考虑 Rigidbody 相关移动方式。

### Audio 基础理论

归档文件：[Lesson18-21 - Audio 基础理论](Archive/Lesson18-21-AudioBasics.md)

重点：

- AudioClip 导入参数决定音频资源的内存、加载方式、压缩质量和播放成本。
- `AudioSource` 负责播放声音，`AudioListener` 负责接收声音，场景中通常只保留一个启用的 Listener。
- `AudioSource.Play()`、`Stop()`、`Pause()`、`PlayOneShot()` 是初学阶段最常用的播放控制 API。
- 麦克风录制通过 `Microphone.Start()` 开始，`Microphone.End()` 结束，录制结果是一个 `AudioClip`。
- `AudioClip.GetData()` 读取的是采样数据，不等于直接保存成音频文件；真正导出 WAV 等格式还需要额外编码。

### GUI / UGUI / PlayerPrefs 路线选择

归档文件：[阶段补课 - UGUI、PlayerPrefs 与 Json 持久化](Archive/Pause-UGUI-PlayerPrefs.md)

重点：

- `OnGUI` 属于较老的即时模式 GUI，当前阶段只需要能看懂教程写法和历史用途。
- 后续入门项目优先使用 UGUI 制作菜单、设置面板、游戏界面和结算界面。
- PlayerPrefs 适合保存音量、最高分、简单设置和轻量进度。
- Json 持久化适合保存结构化数据，例如关卡进度、角色数据、背包、配置和更复杂的本地存档。
- PlayerPrefs、UGUI、Json 持久化三部分前置内容已完成，本项目可以回到入门小项目制作阶段。

### 实践小项目

归档文件：[实践小项目 - P67-P99 分 P 清单](Archive/SmallProject-P67-P99.md)

重点：

- 实践小项目视频范围为 P67-P99。
- P67 是知识总结，P68 开始进入小项目必备知识点。
- 小项目会综合用到场景切换、鼠标显示与锁定、随机数、委托、资源导入、UGUI、音频、排行榜、坦克/敌人/武器/奖励、通关失败界面和项目打包。
- 后续每次检查代码时，需要优先确认当前正在做哪一 P，以及这一 P 更偏“Unity 配置”“UI 逻辑”“数据逻辑”还是“玩法对象逻辑”。
- P77 音效数据逻辑中要注意：自定义 PlayerPrefs 管理器如果直接用 `GetInt/GetFloat/GetString` 读取不存在的 key，会返回类型默认值；再通过反射写回数据对象时，可能覆盖 C# 字段初始化值。
- 当前小项目进度：P77「音效数据逻辑」已完成，下一步 P78「排行榜界面」。

## 后续记录规则

- 每完成一个新 Lesson，在 `Docs/Archive/` 中新增对应文件。
- 本文件只补充索引和跨 Lesson 的知识点入口，不再写长篇流水内容。
- 如果一个知识点反复出现，可以在本文件中保留短摘要，并把详细过程放到归档文件。
