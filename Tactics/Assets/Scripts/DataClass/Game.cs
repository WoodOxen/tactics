/**
 * @file Game.cs
 * @brief
 * @author Yueyuan Li
  * @date 2023-04-23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int scenario;
    
    public int mapName;
    public int numAgent;
    public Agent[] agents;

    public void SaveGame ()
    {
        SaveLoadSystem.SaveGame(this);
    }

    public void LoadGame (string fileName)
    {
        GameData gameData = SaveLoadSystem.LoadGame(fileName);

        scenario = gameData.scenario;
        mapName = gameData.mapName;
        numAgent = gameData.numAgent;
        agents = new Agent[numAgent];
        for (int i = 0; i < numAgent; i++)
        {
            agents[i] = new Agent(gameData.agentsData[i]);
        }
    }
}