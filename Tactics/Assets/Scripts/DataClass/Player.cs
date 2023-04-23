/**
 * @file Player.cs
 * @brief
 * @author Yueyuan Li
  * @date 2023-04-23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;
    public int vehicleID;
    public int controlMethod;
    public float[] steer;
    public float[] brake;
    public float[] numFrame;

    public Player (PlayerData playerData)
    {
        playerID = playerData.playerID;
        vehicleID = playerData.vehicleID;
        controlMethod = playerData.controlMethod;
        steer = playerData.steer;
        brake = playerData.brake;
        numFrame = playerData.numFrame;
    }
}