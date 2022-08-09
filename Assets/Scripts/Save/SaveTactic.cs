using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTactic
{
    public int GameMode = 0;
    public int TrackNum = 0;

    public int[] ControlMethod = new int[4] { 0, 0, 0, 0 };

    public float[,] Position = new float[4, 3] { { 0, 0, 0},{ 0, 0, 0}, { 0, 0, 0 }, { 0, 0, 0 } };

    public float[,] Speed = new float[4,3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

    public float[,] Angle = new float[4,3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

    public int[] CarColor = new int[4] { 0,0,0,0};

    public float[] steer = new float[4] { 0, 0, 0, 0 };
    public float[] accel = new float[4] { 0, 0, 0, 0 };
    public float[] footbrake = new float[4] { 0, 0, 0, 0 };
    public float[] handbrake = new float[4] { 0, 0, 0, 0 };

    public int min = 0;
    public int sec = 0;
    public float milli = 0f;
    public int[] score = new int[4] { 0, 0, 0, 0 };
    public int[] lapNum = new int[4] { 0, 0, 0, 0 };

    public float[] ExtentOfDamage = new float[4] { 0, 0, 0, 0 };
    public int[] CollisionNum = new int[4] { 0, 0, 0, 0 };

    public bool[] HalfFlag = new bool[4] { false, false, false, false};

    public int PlayNum = 1;
}

