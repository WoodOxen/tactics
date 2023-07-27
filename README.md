Language : English | [中文](./README.zh.md)

[![Read the Docs](https://img.shields.io/readthedocs/tactics)](https://tactics.readthedocs.io/en/latest/)

# TACTICS

- [TACTICS](#tactics)
  - [About](#about)
  - [Development](#development)
    - [Document for Developers](#document-for-developers)
    - [Development Plan](#development-plan)

## About

Tactics is a comprehensive simulator tailored for autonomous driving research. The primary goal of this project is to provide academia with a collection of Out-Of-The-Box (OOTB) functionalities, facilitating quick exploration of tasks related to perception and decision-making. The potential applications of Tactics encompass:

:construction: controlling: realistic vehicle dynamics for different types of vehicles

| Vehicle type | Development status | Real world test |
| --- | --- | --- |
| Sedan | :construction: | |
| SUV | :construction: | |
| Trailer | :construction: | |

:construction: perception: synthesized raw sensor data, including data in adverse weather

- Vehicle sensor: camera, event camera, lidar
- Weather: sunny, rainy, foggy, snowy

:construction: perception: ground truth for tasks like object detection, semantic segmentation, depth prediction

:construction: driving decision: built traffic scenarios for training and testing

:beginner: map reconstruction: automatic map structuralization and reconstruction from raw sensor data

:beginner: V2X: vehicle-to-vehicle communication and vehicle-to-road communication

You can access the detailed user documentation for Tactics here. Currently, the document is available in both English and Chinese. We also encourage and welcome translations into other languages.

## Development

Tactics v0.0.0 is built upon Unity 2021.3.24f1 and is currently under development. Given the current limited number of developers, it is estimated that it will take approximately five years to fully implement all the planned functions in Tactics. We are actively seeking contributors to join this open-source project. If you are interested in contributing, we warmly welcome your involvement.

### Document for Developers

To support the developer community, we have prepared a dedicated documentation that helps developers quickly access all the necessary information about Tactics development. We welcome and encourage developers to provide feedback and suggestions while using Tactics. Together, we aim to build a stronger and more developer-friendly community, driving continuous improvement and development of Tactics.

- [Folder structure](https://tacitcs-doc.readthedocs.io/en/latest/developer/folder_structure/)
- [Code style](https://tacitcs-doc.readthedocs.io/en/latest/developer/csharp_coding_style/)
- [Github submission](https://tacitcs-doc.readthedocs.io/en/latest/developer/github_submission/)

### Development Plan
