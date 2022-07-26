using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTactic
{
    public int GameMode = 0;
    public int TrackNum = 0;
    public int ControlMethod = 0;
    public float PositionX = 0f ;
    public float PositionY = 0f;
    public float PositionZ = 0f;

    public float SpeedX = 0f;
    public float SpeedY = 0f;
    public float SpeedZ = 0f;

    public float AngleX = 0f;
    public float AngleY = 0f;
    public float AngleZ = 0f;

    public int CarColor = 0;
    public float steer = 0f;
    public float accel = 0f;
    public float footbrake = 0f;
    public float handbrake = 0f;

    public int min = 0;
    public int sec = 0;
    public float milli = 0f;
    public int score = 0;
    public int lapNum = 0;

    public float ExtentOfDamage = 0f;
    public int CollisionNum = 0;

    public bool HalfFlag = false;
}

