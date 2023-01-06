/**
  * @file SaveTactic.cs
  * @brief 定义SaveTactic类，明确存档时需要储存哪些内容
  * @details  
  * 挂载该脚本的对象：无 \n
  * @author 李雨航
  * @date 2022-01-06
  */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTactic
{
    /// 仿真模式 
    public int GameMode = 0;
    /// 赛道编号 
    public int TrackNum = 0;

    /// 各车辆控制方式 
    public int[] ControlMethod;
    /// 各车辆颜色 
    public int[] CarColor;

    /// 仿真过程中各车辆输入的steer参数 
    public float[,] steer;
    /// 仿真过程中各车辆输入的accel参数 
    public float[,] accel;
    /// 仿真过程中各车辆输入的footbrake参数 
    public float[,] footbrake;
    /// 仿真过程中各车辆输入的handbrake参数 
    public float[,] handbrake;
    /// 仿真全程车辆一共获取了几个steer、accel、footbrake、handbrake参数
    public int count;

    /// 参与仿真的车辆数目 
    public int PlayNum = 1;

    //历史残留代码
    //存档功能由“在仿真中途存档，读档后从该状态继续运行”改为“读档时复现存档中的仿真内容”
    //因此下列代码暂时废弃
    //public float[,] Position = new float[4, 3] { { 0, 0, 0},{ 0, 0, 0}, { 0, 0, 0 }, { 0, 0, 0 } };
    //public float[,] Speed = new float[4,3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    //public float[,] Angle = new float[4,3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    //public int min = 0;
    //public int sec = 0;
    //public float milli = 0f;
    //public int[] score = new int[4] { 0, 0, 0, 0 };
    //public int[] lapNum = new int[4] { 0, 0, 0, 0 };
    //public float[] ExtentOfDamage = new float[4] { 0, 0, 0, 0 };
    //public int[] CollisionNum = new int[4] { 0, 0, 0, 0 };
    //public bool[] HalfFlag = new bool[4] { false, false, false, false};

}

