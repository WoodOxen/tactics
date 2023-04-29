/**
 * @file Scene.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public int ScenarioID;
    public int EvaluationMode;
    public int MapID;
    public int AgentNumber;
    public Agent[] Agents;

    public void SaveScene()
    {
        SaveLoadSystem.SaveScene(this);
    }

    public void LoadScene(string fileName)
    {
        SceneData sceneData = SaveLoadSystem.LoadScene(fileName);

        ScenarioID = sceneData.ScenarioID;
        EvaluationMode = sceneData.EvaluationMode;
        MapID = sceneData.MapID;
        AgentNumber = sceneData.AgentNumber;
        Agents = new Agent[AgentNumber];

        for (int i = 0; i < AgentNumber; i++)
        {
            Agents[i] = new Agent(sceneData.AgentsData[i]);
        }
    }
}
