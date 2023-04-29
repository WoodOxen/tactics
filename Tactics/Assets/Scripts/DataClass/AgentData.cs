/**
 * @file AgentData.cs
 * @brief 定义AgentData类，明确存档时需要储存哪些内容
 * @details
 * @author Yueyuan Li
 * @author Yuhang Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// @class AgentData
/// @brief Define the data types to save for an agent.
public class AgentData
{
    public int AgentID;
    public int VehicleID;
    public float[] VehicleSize;
    public string VehicleType;
    public int ControlMethod;
    public float[] State;
    public float[] ControlCommand;
    public int StartFrame;
    public int EndFrame;

    public AgentData(Agent agent)
    {
        AgentID = agent.AgentID;
        VehicleID = agent.VehicleID;
        VehicleSize = agent.VehicleSize;
        ControlMethod = agent.ControlMethod;
        State = agent.State;
        ControlCommand = agent.ControlCommand;
        StartFrame = agent.StartFrame;
        EndFrame = agent.EndFrame;
    }
}
