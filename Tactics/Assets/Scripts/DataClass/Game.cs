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
    public int gameMode;
    public int mapName;
    public int numPlayer;
    public Player[] players;

    public void SaveGame ()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame (string fileName)
    {
        GameData gameData = SaveSystem.LoadGame(fileName);

        gameMode = gameData.gameMode;
        mapName = gameData.mapName;
        numPlayer = gameData.numPlayer;
        players = new Player[numPlayer];
        for (int i = 0; i < numPlayer; i++)
        {
            players[i] = new Player(gameData.playersData[i]);
        }
    }
}