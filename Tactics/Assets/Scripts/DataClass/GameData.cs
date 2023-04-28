/**
* @file GameData.cs
* @brief Define the data types to save when save a game.
* @author Yueyuan Li
* @date 2023-04-23
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int scenario = 0;
    public int evaluationMode = 0;
    public int mapName = 0;
    public int numAgent = 1;
    public AgentData[] agentsData;

    public GameData (Game game)
    {
        scenario = game.scenario;
        mapName = game.mapName;
        numAgent = game.numAgent;
        agentsData = new AgentData[numAgent];
        for (int i = 0; i < numAgent; i++)
        {
            agentsData[i] = new AgentData(game.agents[i]);
        }
    }
}