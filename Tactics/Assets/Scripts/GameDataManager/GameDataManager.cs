using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private GameData gameData;
    private string dataPath = PlayerPrefs.GetString(
        "GameDataPath", Application.dataPath + "/GameData/");
    public static GameDataManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Manager in the scene.");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGameList()
    {
        string[] dataFileList = Directory.GetFiles(dataPath);
        // if (dataFileList.Count() == 0)
        // {
        //     Debug.LogError("No data file is found!");
        // }
        // else
        // {

        // }
    }

    public void SaveGame()
    {
        if (! Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
    }
}
