/**
 * @file Agent.cs
 * @brief
 * @author Yueyuan Li
  * @date 2023-04-23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Agent : MonoBehaviour
{
    [SerializeField] private TMP_Text agentName;
    [SerializeField] private TMP_Text currentSpeed;
    [SerializeField] private TMP_Text currentHeading;
    [SerializeField] private TMP_Text currentScore;
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

    public Agent (AgentData agentData)
    {
        agentID = agentData.agentID;
        vehicleID = agentData.vehicleID;
        controlMethod = agentData.controlMethod;
        steer = agentData.steer;
        brake = agentData.brake;
        numFrame = agentData.numFrame;
    }
}