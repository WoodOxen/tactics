using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTactic
{
    public int GameMode = 0;
    public int TrackNum = 0;

    public int[] ControlMethod;
    public int[] CarColor;

    public float[,] steer;
    public float[,] accel;
    public float[,] footbrake;
    public float[,] handbrake;
    public int count;

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

