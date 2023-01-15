/**
  * @file LoadButton.cs
  * @brief 实现读档和删档功能
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → Panel Save → PanelRoll → Panel → Save Savebutton， \n
  * MainMenu → Canvas → Panel Load → PanelRoll → Panel → Save Button → Delbutton/Loadbutton \n
  * 在存档窗口按下Load按钮后，进入该存档对应的赛道场景中，并令参数LoadNum为对应的存档号（不等于0）。\n
  * 当LoadNum不等于0时，进入仿真场景后，StartManager.cs和carControlActive.cs脚本会读取对应的存档并进行相应的设置。\n
  * 在存档窗口按下Delete按钮后，删除对应存档，并修改档位使用情况。\n
  * @author 李雨航
  * @date 2022-01-06
  */

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

    /**
    * @fn Load1
    * @brief 一号档位的Load按钮
    */
    public void Load1()
    {
        LoadGame("/Save1.txt");
    }
    /**
    * @fn Load2
    * @brief 二号档位的Load按钮
    */
    public void Load2()
    {
        LoadGame("/Save2.txt");
    }
    /**
    * @fn Load3
    * @brief 三号档位的Load按钮
    */
    public void Load3()
    {
        LoadGame("/Save3.txt");
    }
    /**
    * @fn Load4
    * @brief 四号档位的Load按钮
    */
    public void Load4()
    {
        LoadGame("/Save4.txt");
    }
    /**
    * @fn ResaveCondition
    * @brief 刷新记录存档使用情况的文件
    */
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

    /**
    * @fn Delete1
    * @brief 一号档位的Delete按钮
    */
    public void Delete1()
    {
        if (File.Exists(Application.dataPath +  "/Save1.txt"))
        {
            File.Delete(Application.dataPath + "/Save1.txt");
            SaveConditionManager.Save1Track = 0;
            ResaveCondition();
        }
    }
    /**
    * @fn Delete2
    * @brief 二号档位的Delete按钮
    */
    public void Delete2()
    {
        if (File.Exists(Application.dataPath +  "/Save2.txt"))
        {
            File.Delete(Application.dataPath + "/Save2.txt");
            SaveConditionManager.Save2Track = 0;
            ResaveCondition();
        }
    }
    /**
    * @fn Delete3
    * @brief 三号档位的Delete按钮
    */
    public void Delete3()
    {
        if (File.Exists(Application.dataPath + "/Save3.txt"))
        {
            File.Delete(Application.dataPath + "/Save3.txt");
            SaveConditionManager.Save3Track = 0;
            ResaveCondition();
        }
    }
    /**
    * @fn Delete4
    * @brief 四号档位的Delete按钮
    */
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
