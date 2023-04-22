using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gameMode;
    public int mapId;
    public int[] vehicleId;
    public int[] vehicleType;
    public int[] vehicleColor;

    public float[,] steer;
    public float[,] throttle;
    public float[,] brake;
}
