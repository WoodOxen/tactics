# TACTICS

Language : [English](./README.md) | 中文

[![Read the Docs](https://readthedocs.org/projects/tactics/badge/?version=latest)](https://tactics.readthedocs.io/en/latest)

- [TACTICS](#tactics)
  - [关于](#关于)
  - [开发](#开发)
    - [开发者文档](#开发者文档)
    - [开发计划](#开发计划)

## 关于

Tactics是一款专为自动驾驶研究量身定制的开源模拟器。该项目的主要目标是为学术界提供一系列即开即用的工具，以便快速探索与感知和决策相关的任务。Tactics可能的应用包括：

:construction: 车辆控制：不同类型车辆的真实动力学控制

| 车辆类型 | 开发状态 | 实车测试 |
| --- | --- | --- |
| 轿车| :construction: | |
| SUV | :construction: | |
| 拖车 | :construction: | |

:construction: 感知：合成原始传感器数据，包括恶劣天气中的数据

- 车辆传感器：摄像头、事件相机、激光雷达
- 天气：晴天、雨天、雾天、雪天

:construction: 感知：用于目标检测、语义分割、深度预测等任务的真实数据

:construction: 驾驶决策：构建用于训练和测试的交通场景

:beginner: 地图重建：自动从原始传感器数据中提取和重建地图结构

:beginner: V2X通信：车辆对车辆通信和车辆对路边设施通信

您可以通过[此处](https://tactics.readthedocs.io/en/latest/zh/)访问Tactics的详细用户文档。目前，该文档提供英文和中文版本。我们也欢迎您将其翻译成其他语言。

## 开发

Tactics v0.0.0是基于Unity 2021.3.24f1构建的，目前正在开发中。由于开发人员有限，预计需要大约五年的时间来完全实现目前规划中的的功能。我们非常欢迎合作者加入这个开源项目。

(注意：版本号"v0.0.0"通常是一个早期版本，可能存在较多的功能未完善或仍在开发中，因此估计需要较长时间来达到全面成熟的状态。)

### 开发者文档

为了支持开发者社区，我们专门为开发者提供了一份文档，帮助开发者迅速获取有关Tactics开发的必要信息。我们欢迎并鼓励开发者提供反馈和意见。通过共同努力，打造一个更强大、更友好的开发者社区，共同推动Tactics的不断完善和发展。

- [项目文件结构](https://tactics.readthedocs.io/en/latest/zh/developer/folder_structure/)
- [代码风格规范](https://tactics.readthedocs.io/en/latest/zh/developer/csharp_coding_style/)
- [Github提交规范](https://tactics.readthedocs.io/en/latest/zh/developer/github_submission/)

### 开发计划
