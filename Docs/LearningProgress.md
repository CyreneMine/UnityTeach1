# LearningProgress

本文件现在作为学习进度索引和最近变更记录使用。完整小节总结按 Lesson 归档到 `Docs/Archive/`。

日常检查时优先读取：

- `Docs/CurrentStatus.md`
- `README.md`
- 当前 Lesson 对应脚本/场景

需要复盘历史时，再读取 `Docs/Archive/` 中对应 Lesson 文件。

## 当前进度

- 当前完成：实践小项目 P80「背景音乐」，Begin 场景基础功能基本完成
- 当前定位：Begin 场景菜单、设置、排行榜、背景音乐已收尾；明天进入 P81「基础场景搭建」和后续游戏核心内容
- 下一阶段：开始制作唐老狮入门小项目的游戏核心场景、主界面和玩法对象逻辑
- 当前项目环境：Unity `6000.3.10f1`，Input System `1.18.0`
- 最近提交：`study: 完成唐老狮教程 - P80 Begin 场景收尾`

## 归档索引

- [Lesson11 - Input System 与坦克控制](Archive/Lesson11-InputSystem.md)
- [Lesson12 - Screen 扩展与炮管俯仰](Archive/Lesson12-ScreenAndGunPitch.md)
- [Lesson13 - Camera 组件练习](Archive/Lesson13-Camera.md)
- [Lesson14 - 坐标转换练习](Archive/Lesson14-CoordinateConversion.md)
- [Lesson15 - 光源组件练习](Archive/Lesson15-Light.md)
- [Lesson16 - 物理系统碰撞检测练习](Archive/Lesson16-PhysicsCollision.md)
- [Lesson17 - 物体位移方式理论](Archive/Lesson17-MovementWays.md)
- [Lesson18-21 - Audio 基础理论](Archive/Lesson18-21-AudioBasics.md)
- [阶段补课 - UGUI、PlayerPrefs 与 Json 持久化](Archive/Pause-UGUI-PlayerPrefs.md)
- [实践小项目 - P67-P99 分 P 清单](Archive/SmallProject-P67-P99.md)
- [实践小项目 - P78-P79 排行榜界面与数据逻辑](Archive/SmallProject-P78-P79-Rank.md)
- [实践小项目 - P75-P80 Begin 场景收尾](Archive/SmallProject-P75-P80-BeginScene.md)
- [文档结构调整记录](Archive/DocsReorganization.md)

## 最近变更

### 2026-07-01 实践小项目 P80 Begin 场景收尾

#### 教程/小节名称

唐老狮 Unity 教程 - 实践小项目 P80「背景音乐」与 Begin 场景阶段收尾

#### 本节目标

为 Begin 场景接入背景音乐，并对开始界面、设置界面、排行榜界面和本地数据保存做阶段性收尾，准备明天进入游戏核心内容。

#### 已完成内容

- 新增 `BKMusic` 脚本，用独立脚本包装 Begin 场景的 `AudioSource`。
- 在 Begin 场景中新增 `BKMusic` 对象，并配置背景音乐循环播放。
- `BKMusic.Awake()` 中读取 `GameDataMgr.Instance.musicData`，按已保存的音乐开关和音量初始化背景音乐状态。
- `GameDataMgr.OpenOrCloseMusic()` 中同步更新音乐开关，并实时控制背景音乐静音。
- `GameDataMgr.ChangeMusicVolume()` 中同步更新音乐音量，并实时控制背景音乐音量。
- 复查 Begin 场景脚本实例，`BeginPanel`、`SettingPanel`、`RankPanel`、`BKMusic` 当前各 1 个。
- 复查 Build Settings，`BeginScene` 和 `GameScene` 已在构建场景列表中。

#### 做得好的地方

- 能把 P77 保存的音乐设置真正接到 P80 背景音乐播放上，让设置数据不只是“存起来”，而是能实时影响表现。
- Begin 场景功能链路已经比较完整：开始游戏、退出游戏、打开设置、保存设置、打开排行榜、读取排行榜、播放背景音乐。
- 保持了适合当前小项目阶段的简单实现，没有过早引入复杂音频管理框架。

#### 当前问题

- `GameDataMgr` 当前直接调用 `BKMusic.Instance`，在 Begin 场景中可用；后续如果设置面板复用到 GameScene，需要确认 GameScene 中也存在音乐实例，或者给调用处增加空判断/持久化音乐管理器。
- `BKMusic` 当前没有显式检查 `AudioSource` 是否存在，场景配置正确时没问题；如果以后迁移到 Prefab，需注意组件依赖。

#### 推荐改进方向

- 明天进入 P81 后，优先搭好游戏场景基础结构，再逐步接入游戏主界面、设置复用和玩法对象。
- 后续如果多个场景都需要背景音乐，可以考虑让音乐对象 `DontDestroyOnLoad`，或抽出更统一的音频管理器；当前阶段先保持简单写法即可。
- 设置面板在 GameScene 复用前，要重新检查按钮、Toggle、Slider 引用和打开/关闭流程。

#### 下一节建议

进入 P81「基础场景搭建」，开始从 Begin 场景切换到真正的游戏核心内容。

### 2026-07-01 实践小项目 P78-P79 排行榜界面与数据逻辑

#### 教程/小节名称

唐老狮 Unity 教程 - 实践小项目 P78「排行榜界面」与 P79「排行榜数据逻辑」

#### 本节目标

完成开始场景中的排行榜窗口显示、排行榜数据结构、成绩添加、排序、截断和本地保存。

#### 已完成内容

- 使用 UGUI 制作排行榜界面，并通过 `RankPanel` 刷新排名姓名、分数和用时。
- 新增 `RankInfo` 和 `RankInfoList`，用于保存单条排行榜数据和排行榜列表。
- 在 `GameDataMgr.AddRankInfo()` 中完成添加成绩、同名覆盖、排序、保留前 9 名和 PlayerPrefs 保存。
- 将教程中只按时间排序的写法调整为更符合排行榜需求的规则：分数高优先，分数相同再比较用时短。
- 针对同一个 Name 重复提交成绩的情况，加入“只保留最好成绩”的逻辑。

#### 做得好的地方

- 没有机械照搬教程的 `rankInfoList.Sort((a, b) => a.time < b.time ? -1 : 1)`，而是根据排行榜需求重新设计排序优先级。
- 能意识到比较器返回值不是布尔值，而是负数、零、正数分别表示排序先后和相等。
- 能发现同名玩家重复提交成绩时，教程没有处理覆盖逻辑，并主动增加 `isExist` 标记区分新数据和已有数据。
- 修正了“新高分只覆盖分数、不覆盖时间”可能导致分数和旧时间拼接的问题。

#### 当前问题

- 排行榜目前仍有测试数据添加逻辑，后续接入正式游戏结算时需要清理或迁移到调试入口。
- 当前排行榜 UI 只显示 9 条数据，数据截断逻辑也按 9 条保留，后续如果 UI 改成 10 条，需要同步调整循环和截断条件。

#### 推荐改进方向

- 后续接入游戏结算时，把 `AddRankInfo()` 放到通关/失败或结算流程中调用。
- 可以继续优化时间显示格式，例如补零显示为 `00:01:05`。
- 如果后续需要区分同名玩家，可以再引入玩家 ID；当前小项目阶段用 Name 去重已经足够。

#### 下一节建议

进入 P80「背景音乐」，把 P77 保存的音乐开关和音量真正接入背景音乐播放逻辑。

### 2026-06-29 实践小项目 P77 音效数据逻辑

#### 教程/小节名称

唐老狮 Unity 教程 - 实践小项目 P77「音效数据逻辑」

#### 本节目标

完成设置窗口中的音乐/音效数据逻辑，让 UI 操作能够同步到数据对象，并在关闭设置窗口时通过 PlayerPrefs 保存本地设置。

#### 已完成内容

- 使用 UGUI 自己实现设置窗口，没有完全照搬教程旧 UI 写法。
- 完成音乐开关、音效开关、音乐音量、音效音量的数据结构设计。
- 使用 `GameDataMgr` 管理音乐/音效设置数据。
- 使用 `PlayerPrefsDataMgr` 保存和读取 `MusicData`。
- 排查并理解字段默认值被 `LoadData()` 反射加载结果覆盖的问题。
- 记录 PlayerPrefs 初始化标记 `isFirst` / `notFirst` 的经验。

#### 做得好的地方

- 能根据当前项目实际情况使用 UGUI 自己组织设置窗口，而不是机械照搬教程写法。
- 能沿着“按钮点击 -> 数据管理器 -> PlayerPrefs 管理器 -> 实际保存结果”的链路定位问题。
- 能理解 `LoadData()` 中反射赋值会覆盖字段默认值，这是 P77 里很关键的数据持久化认知。

#### 当前问题

- P77 的音效数据逻辑已经完成，但后续还需要和背景音乐、按钮音效、游戏内音效实际播放联动验证。
- 排行榜相关 UI 和数据逻辑尚未开始。

#### 推荐改进方向

- P78 先完成排行榜界面布局和显示逻辑。
- P79 再整理排行榜数据结构、保存、读取、排序和刷新。
- 后续加入音频播放时，用 P77 保存的开关和音量统一控制音乐/音效。

#### 下一节建议

进入 P78「排行榜界面」，先把排行榜 UI 做出来，再进入 P79 的排行榜数据逻辑。

### 2026-06-29 记录实践小项目分 P 清单

#### 教程/小节名称

唐老狮 Unity 教程 - 实践小项目 P67-P99

#### 本节目标

记录实践小项目的视频分 P，方便后续检查代码、总结本节和提交时准确定位当前学习进度。

#### 已完成内容

- 记录实践小项目视频范围：P67 到 P99。
- 确认 P67 为知识总结。
- 确认下一步从 P68「场景切换和退出游戏」进入小项目必备知识。
- 新增实践小项目完整分 P 清单归档。

#### 下一节建议

从 P68 开始，先掌握场景切换和退出游戏，再进入鼠标隐藏锁定、随机数、委托、模型资源导入和小项目需求分析。

### 2026-06-29 阶段补课完成，回到小项目制作

#### 教程/小节名称

唐老狮 Unity 教程 - PlayerPrefs、UGUI、Json 持久化前置内容

#### 本节目标

在正式制作入门小项目前，补齐界面制作、简单本地设置保存、结构化本地数据持久化三部分基础能力。

#### 已完成内容

- 完成 PlayerPrefs 相关内容，理解简单键值数据的保存、读取和删除。
- 完成 UGUI 相关内容，具备使用 Canvas、RectTransform、基础 UI 组件和事件绑定制作项目界面的基础。
- 完成 Json 持久化相关内容，理解将对象数据序列化为 Json、保存到本地文件、再读取恢复的基本流程。
- 学习路线从“阶段暂停补课”切回“开始制作唐老狮入门小项目”。

#### 做得好的地方

- 没有直接照搬旧式 `OnGUI` 作为项目主力界面，而是先补齐更适合当前 Unity 项目的 UGUI。
- 在做小项目前先学习 PlayerPrefs 和 Json 持久化，后续做设置、进度、存档时会更顺。
- 能把“简单设置”和“结构化存档”区分开：PlayerPrefs 负责轻量键值，Json 更适合复杂数据。

#### 当前问题

- PlayerPrefs、UGUI、Json 目前还没有和本项目小项目整合，后续需要在菜单、设置、游戏数据保存中落地。

#### 推荐改进方向

- 小项目开始后，优先规划菜单、设置界面、游戏主界面和结算界面。
- 音量、画质、简单开关等设置优先考虑 PlayerPrefs。
- 关卡进度、角色数据、背包、分数记录等结构化数据优先考虑 Json 文件保存。

#### 下一节建议

回到唐老狮入门小项目制作阶段，先搭建项目基础流程，再逐步接入 UGUI、音频、输入、物理和数据保存。

### 2026-06-01 Lesson18-21 Audio 基础理论与阶段暂停

#### 教程/小节名称

唐老狮 Unity 教程 - Lesson18 到 Lesson21 Audio 基础理论

#### 本节目标

补充音频资源导入、`AudioSource` / `AudioListener` 组件、`AudioSource` API、麦克风录制与音频采样数据读取的理论知识，并记录后续学习路线调整。

#### 已完成内容

- 总结 Lesson18：AudioClip 导入参数，包括 Load Type、Preload Audio Data、Compression Format、Quality、Sample Rate 等。
- 总结 Lesson19：`AudioSource` 和 `AudioListener` 组件参数。
- 总结 Lesson20：`AudioSource` 常用 API，包括 `Play()`、`Pause()`、`Stop()`、`PlayOneShot()` 等。
- 总结 Lesson21：`Microphone.Start()`、`Microphone.End()`、播放录制 AudioClip，以及 `AudioClip.GetData()` 读取采样数据。
- 记录当前项目阶段暂停：先学习 UGUI 和 PlayerPrefs，再回来继续制作入门教程项目。
- 记录技术选择：旧式 `OnGUI` 只作为了解内容，后续项目优先使用 UGUI。

#### 做得好的地方

- 能识别教程中的 `OnGUI` 已经偏旧，没有机械照搬到后续项目。
- 能在正式做入门项目前先补齐 UGUI 和 PlayerPrefs，避免项目做到一半再补基础。
- 能把没有练习题的理论课合并记录，减少文档碎片。

#### 当前问题

- Audio 理论还没有结合实际小项目使用，后续需要在入门项目中通过 BGM、按钮音效、开火音效、设置音量等功能巩固。
- UGUI 和 PlayerPrefs 尚未学完，本项目会暂停一段时间。

#### 推荐改进方向

- 学 UGUI 时重点关注 Canvas、RectTransform、Button、Text、Image、Panel、事件绑定和基础界面组织。
- 学 PlayerPrefs 时重点关注音量、最高分、设置项、简单进度的保存和读取。
- 回到本项目后，用 UGUI 制作菜单、设置面板、游戏界面和结算界面。

#### 下一节建议

先完成 UGUI 和 PlayerPrefs 学习，再回来继续唐老狮入门项目整合阶段。

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
