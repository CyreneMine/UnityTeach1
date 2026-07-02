# CurrentStatus

## 当前学习状态

- 当前完成：实践小项目 P86「玩家基础移动旋转摄像机跟随等」
- 当前定位：GameScene 已进入核心玩法阶段，完成基础场景、游戏主界面、设置/退出面板复用、坦克基类与玩家基础控制
- 下一阶段：继续 P87「玩家小地图」，再进入武器、子弹、奖励和敌人逻辑
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
- 小项目分 P：已记录实践小项目 P67-P99，后续按场景切换、鼠标隐藏锁定、随机数与委托、资源导入、UI、音效、排行榜、敌人/子弹/奖励、通关/失败界面、打包与总结推进。
- P67-P79：完成小项目准备内容、开始界面、设置界面、音效数据逻辑、排行榜界面和排行榜数据逻辑；当前使用 UGUI 自己实现设置窗口和排行榜窗口，并用 PlayerPrefs 保存音乐/音效设置与排行榜数据。
- P78-P79：完成排行榜 UI 显示、排行榜数据结构、添加成绩、排序、截断和保存；没有完全照搬教程排序写法，而是改为“分数高优先，分数相同再按时间短优先”，并加入同名玩家只保留最好成绩的覆盖逻辑。
- P80：完成 Begin 场景背景音乐对象 `BKMusic`，通过 `AudioSource` 播放循环背景音乐，并让设置面板中的音乐开关和音乐音量可以实时影响背景音乐。
- Begin 场景收尾：开始游戏、退出游戏、设置面板、排行榜面板、音乐设置、排行榜数据保存等基础菜单功能已经串起来；并补充了独立 UI 摄像机渲染方案。
- P81-P86：完成 GameScene 基础搭建、游戏主界面、设置界面复用、退出界面、坦克基类和玩家基础移动/旋转/摄像机跟随等内容。
- P86 输入实践：在玩家控制中同时完成旧版 `Input` 写法和新版 `Unity Input System` 写法的对照，新版方案使用 `PlayerController` 输入配置读取 Move / Look。

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
- 使用自定义 `PlayerPrefsDataMgr.LoadData()` 反射加载数据时，字段默认值可能会先执行但随后被 PlayerPrefs 读取结果覆盖；读取不存在的 bool key 时默认会得到 `false`。
- P77 中确认：关闭设置窗口时保存数据的思路可行，但首次初始化标记需要正确设置为已初始化，避免下次加载时被默认逻辑重置。
- P79 中确认：排行榜排序比较器不应只按时间排序；更合理的规则是先比较分数，分数高的在前，分数相同时再比较用时，用时短的在前，并在完全相等时返回 `0`。
- P79 中确认：同名玩家重复提交成绩时，应保留最好成绩；新分数更高时同时覆盖分数和时间，分数相同时只保留更短时间，新分数更低时忽略。
- P80 中确认：背景音乐可以先用独立 `BKMusic` 脚本包装 `AudioSource`，在小项目阶段足够直观；设置变化时通过 `GameDataMgr` 同步到 `BKMusic.Instance`。
- Begin 场景 UI 渲染优化：Canvas 从 Overlay 改为 Screen Space - Camera，并绑定独立 `UICamera`；`UICamera` 只渲染 UI 层，Depth 高于 Main Camera，CanvasScaler 改为 Scale With Screen Size，后续更适合分辨率适配和摄像机分层。
- P83 设置面板复用中确认：跨场景复用 UI 面板时，不能让通用面板继续依赖 BeginScene 专属对象；静态 `Instance` 可能在切场景后留下已销毁对象引用，引发 `MissingReferenceException`。
- P86 玩家控制中确认：旧版 `Input.GetAxis` 适合快速理解连续输入；新版 `Input System` 更适合把输入配置资产化，并通过 `performed/canceled` 回调维护当前输入向量。

## 当前常见风险

- 多个脚本实例同时启用，导致重复执行生命周期或控制同一对象。
- Inspector 引用未绑定导致空引用。
- 修改 Layer/Tag/Input Actions 后忘记提交 `ProjectSettings` 或生成代码。
- Unity 场景文件中的临时摄像机位置、Transform 变化混入提交。
- 重命名 `[SerializeField]` 字段后，需要重新保存 Inspector 引用，或使用 `FormerlySerializedAs` 保留旧字段迁移。
- 使用 Tag 驱动碰撞逻辑时，要确认场景对象和 Prefab 的 Tag 都已正确设置。
- PlayerPrefs 初始化标记要小心：`isFirst = true` 这类字段默认值可能被加载逻辑覆盖，推荐用 `notFirst` 或 `HasKey` 思路明确区分“没有存档”和“存档值为 false”。
- 排行榜数据更新时，要避免把新高分和旧低分对应的旧时间拼接成一条错误记录；成绩和时间应作为同一次游戏结果一起更新。
- 当前 `GameDataMgr` 直接调用 `BKMusic.Instance`，Begin 场景中可用；后续如果设置面板复用到 GameScene，要确保游戏场景也有音乐实例，或者补空判断/持久音乐管理器。
- 独立 UI 摄像机方案下，要持续确认 Main Camera 和 UICamera 的 Culling Mask、Depth、Clear Flags，以及 Canvas 的 Render Camera 是否仍然正确绑定。
- `SettingPanel` 复用到 GameScene 时，要避免关闭按钮继续调用 `BeginPanel.Instance.ShowMe()`；GameScene 中应只隐藏设置面板或回到游戏 UI。
- `PlayerObj.OnDisable()` 当前会访问 `playerAction`，如果对象在 `Start()` 前被禁用，可能需要补空判断；后续调试玩家对象生命周期时优先检查这一点。
- 文档收尾时遗漏 README 或 CurrentStatus。

## 当前学习路线调整

- PlayerPrefs、UGUI、Json 持久化前置内容已完成。
- 本项目已进入实践小项目制作阶段，目前完成到 P86，GameScene 核心玩法对象已经开始实现。
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

## 实践小项目分 P

- P67：知识总结（00:06:45）
- P68：必备知识点 场景切换和退出游戏（00:12:55）
- P69：必备知识点 鼠标隐藏锁定相关（00:10:03）
- P70：必备知识点 随机数和 Unity 自带委托等（00:12:48）
- P71：必备知识点 模型资源的导入（00:09:49）
- P72：需求分析（00:08:50）
- P73：必备代码资源导入（00:05:50）
- P74：场景装饰（00:13:54）
- P75：开始界面（00:29:53）
- P76：设置界面（00:19:59）
- P77：音效数据逻辑（00:23:52）
- P78：排行榜界面（00:25:17）
- P79：排行榜数据逻辑（00:20:13）
- P80：背景音乐（00:11:15）
- P81：基础场景搭建（00:06:46）
- P82：游戏主界面（00:26:27）
- P83：设置界面复用（00:11:17）
- P84：退出界面（00:10:38）
- P85：坦克基类（00:22:06）
- P86：玩家 基础移动旋转摄像机跟随等（00:16:28）
- P87：玩家 小地图（00:08:23）
- P88：武器和子弹对象（00:35:39）
- P89：武器奖励对象和获取特效（00:34:59）
- P90：属性奖励对象（00:18:45）
- P91：可击毁箱子（00:14:49）
- P92：固定不动的敌人（00:27:00）
- P93：移动的敌人（00:28:37）
- P94：怪物血条（00:19:46）
- P95：通关点（00:17:10）
- P96：通关界面（00:10:32）
- P97：失败界面（00:11:20）
- P98：项目打包（00:14:29）
- P99：实践总结（00:05:19）

## 最近提交

- `study: 完成唐老狮教程 - P86 玩家基础控制`
