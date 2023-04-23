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
    public int gameMode = 0;
    public int mapName = 0;
    public int numPlayer = 1;
    public PlayerData[] playersData;

    public GameData (Game game)
    {
        gameMode = game.gameMode;
        mapName = game.mapName;
        numPlayer = game.numPlayer;
        playersData = new PlayerData[numPlayer];
        for (int i = 0; i < numPlayer; i++)
        {
            playersData[i] = new PlayerData(game.players[i]);
        }
    }
}