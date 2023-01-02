using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public static int LoadNum = 0;
    public static SaveTactic save;
    public void LoadGame(string str)
    {
        Time.timeScale = 1;
        if (File.Exists(Application.dataPath + str))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.dataPath + str, FileMode.Open);
            save = (SaveTactic)binaryFormatter.Deserialize(fileStream); 
            fileStream.Close();
            if (save.TrackNum == 1)
                SceneManager.LoadScene(2);
            else if (save.TrackNum == 2)
                SceneManager.LoadScene(3);
            else if (save.TrackNum == 3)
                SceneManager.LoadScene(5);
            else
                SceneManager.LoadScene(5);
            LoadNum = 1;
        }
    }


    public void Load1()
    {
        LoadGame("/Save1.txt");
    }
    public void Load2()
    {
        LoadGame("/Save2.txt");
    }
    public void Load3()
    {
        LoadGame("/Save3.txt");
    }
    public void Load4()
    {
        LoadGame("/Save4.txt");
    }

    public static void ResaveCondition()
    {
        SaveCondition saveCondition = new SaveCondition
        {
            Save1Track = SaveConditionManager.Save1Track,
            Save2Track = SaveConditionManager.Save2Track,
            Save3Track = SaveConditionManager.Save3Track,
            Save4Track = SaveConditionManager.Save4Track
        };

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath +  "/saveCondition.txt");
        binaryFormatter.Serialize(fileStream, saveCondition);
        fileStream.Close();
    }


    public void Delete1()
    {
        if (File.Exists(Application.dataPath +  "/Save1.txt"))
        {
            File.Delete(Application.dataPath + "/Save1.txt");
            SaveConditionManager.Save1Track = 0;
            ResaveCondition();
        }
    }

    public void Delete2()
    {
        if (File.Exists(Application.dataPath +  "/Save2.txt"))
        {
            File.Delete(Application.dataPath + "/Save2.txt");
            SaveConditionManager.Save2Track = 0;
            ResaveCondition();
        }
    }

    public void Delete3()
    {
        if (File.Exists(Application.dataPath + "/Save3.txt"))
        {
            File.Delete(Application.dataPath + "/Save3.txt");
            SaveConditionManager.Save3Track = 0;
            ResaveCondition();
        }
    }

    public void Delete4()
    {
        if (File.Exists(Application.dataPath + "/Save4.txt"))
        {
            File.Delete(Application.dataPath + "/Save4.txt");
            SaveConditionManager.Save4Track = 0;
            ResaveCondition();
        }
    }
}
