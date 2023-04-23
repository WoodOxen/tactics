/**
* @file PlayerData.cs
* @brief 定义PlayerData类，明确存档时需要储存哪些内容
* @details
* @author Yueyuan Li
* @author Yuhang Li
* @date 2023-04-23
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerID;
    public int vehicleID;
    public int controlMethod;
    public float[] steer;
    public float[] brake;
    public float[] numFrame;

    public PlayerData (Player player)
    {
        playerID = player.playerID;
        vehicleID = player.vehicleID;
        controlMethod = player.controlMethod;
        steer = player.steer;
        brake = player.brake;
        numFrame = player.numFrame;
    }
}
