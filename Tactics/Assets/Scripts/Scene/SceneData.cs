/**
 * @file SceneData.cs
 * @brief Define the data types to save for a simulation case.
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public int ScenarioID;
    public int EvaluationMode = 0;
    public int MapID = 0;
    public int AgentNumber = 1;
    public AgentData[] AgentsData;

    public SceneData(Scene scene)
    {
        ScenarioID = scene.ScenarioID;
        EvaluationMode = scene.EvaluationMode;
        MapID = scene.MapID;
        AgentNumber = scene.AgentNumber;
        AgentsData = new AgentData[AgentNumber];

        for (int i = 0; i < AgentNumber; i++)
        {
            AgentsData[i] = new AgentData(scene.Agents[i]);
        }
    }
}
