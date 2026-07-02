# 实践小项目 - P81-P86 GameScene 核心基础

## 教程/小节名称

唐老狮 Unity 教程 - 实践小项目 P81 到 P86

## 本节目标

从 Begin 场景进入 GameScene，完成基础场景、游戏主界面、设置/退出界面复用、坦克基类和玩家基础控制，为后续小地图、武器、子弹、奖励和敌人逻辑做准备。

## 已完成内容

- P81：搭建 GameScene 基础场景。
- P82：制作游戏主界面，包含分数、时间、血量、设置按钮、退出按钮和小地图入口等基础 UI。
- P83：复用设置面板，并排查设置面板从 BeginScene 迁移到 GameScene 后的跨场景依赖问题。
- P84：制作退出界面 `QuitPanel`，打开时暂停游戏，关闭时恢复 `Time.timeScale`。
- P85：新增坦克基类 `TankBaseObj`，整理攻击、防御、血量、移动速度、旋转速度、炮塔引用、死亡特效和受伤/死亡逻辑。
- P86：新增玩家对象 `PlayerObj`，完成玩家基础移动、车体旋转、炮塔旋转和摄像机跟随相关内容。
- P86 扩展：同时完成两种输入方式：
  - 旧版 `Input.GetAxis` 写法，适合快速理解每帧读取输入。
  - 新版 `Unity Input System` 写法，使用 `PlayerController` 输入配置读取 Move / Look，并通过 `performed/canceled` 回调保存当前输入状态。

## 做得好的地方

- 没有只机械照搬教程旧版 Input 写法，而是主动把新版 Input System 也做了一遍，形成了新旧输入系统对照。
- 能把 Begin 场景中已经做好的设置界面迁移到 GameScene 复用，同时通过报错理解跨场景静态引用残留的问题。
- `TankBaseObj` 的抽象方向是对的：玩家和敌人都会有攻击、防御、血量、死亡等共同逻辑，提前抽出基类能减少后续重复代码。
- 退出界面用 `Time.timeScale` 控制暂停/恢复，符合当前小项目阶段的直观做法。

## 当前问题

- `SettingPanel` 已通过场景名判断避免在 GameScene 中继续显示 `BeginPanel`，能解决当前报错；但它仍带有 BeginScene 语义，后续更推荐让不同场景的关闭行为分离。
- `PlayerObj.OnDisable()` 里会访问 `playerAction`，如果对象在 `Start()` 前被禁用，可能需要补空判断。
- `GamePanel.AddScore(int score)` 当前显示时使用的是本次传入的 `score`，如果目标是显示累计分数，后续应确认是否要改为显示 `nowScore`。
- 新旧输入方式目前适合作为学习对照；实际运行时应避免两套输入逻辑同时驱动同一玩家对象。

## 推荐改进方向

- 将设置面板的“关闭后行为”从场景名判断和 `BeginPanel` 中进一步解耦：BeginScene 关闭设置后回到开始面板，GameScene 关闭设置后只回到游戏 UI。
- 如果继续使用 `BasePanel<T>` 的静态实例写法，可以考虑在 `OnDestroy()` 中清空实例，减少切场景后的 Missing Reference。
- 后续正式使用新版 Input System 时，注意在 `OnEnable/OnDisable` 中成对启用、订阅、取消订阅，并对输入对象做空判断。
- 小项目阶段可以先保持当前结构，等 P87 小地图和 P88 武器子弹接入后，再统一检查玩家对象职责是否需要拆分。

## 下一节建议

进入 P87「玩家小地图」，继续完善玩家表现和游戏场景观察能力。之后开始 P88「武器和子弹对象」，把玩家输入和战斗行为真正接起来。
