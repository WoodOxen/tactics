/**
 * @file Agent.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Agent : MonoBehaviour
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

    [SerializeField] private TMP_Text agentName;
    [SerializeField] private TMP_Text currentSpeed;
    [SerializeField] private TMP_Text currentHeading;
    [SerializeField] private TMP_Text currentScore;
    
    public Agent(AgentData agentData)
    {
        AgentID = agentData.AgentID;
        VehicleID = agentData.VehicleID;
        VehicleSize = agentData.VehicleSize;
        ControlMethod = agentData.ControlMethod;
        State = agentData.State;
        ControlCommand = agentData.ControlCommand;
        StartFrame = agentData.StartFrame;
        EndFrame = agentData.EndFrame;
    }
}
