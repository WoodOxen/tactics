/**
* @file AgentData.cs
* @brief 定义AgentData类，明确存档时需要储存哪些内容
* @details
* @author Yueyuan Li
* @author Yuhang Li
* @date 2023-04-23
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// @class AgentData
/// @brief Define the data types to save when save an agent.
public class AgentData
{
    public int agentID;
    public int vehicleID;
    public float[] vehicleSize;
    public string vehicleType;
    public int controlMethod;
    public float[] speed;
    public float[] heading;
    public float[,] location;
    public float[] steer;
    public float[,] brake;
    public int numFrame;

    public AgentData (Agent agent)
    {
        agentID = agent.agentID;
        vehicleID = agent.vehicleID;
        vehicleSize = agent.vehicleSize;
        vehicleType = agent.vehicleType;
        controlMethod = agent.controlMethod;
        steer = agent.steer;
        brake = agent.brake;
        numFrame = agent.numFrame;
    }
}
