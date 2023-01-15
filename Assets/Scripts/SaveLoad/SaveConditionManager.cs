/**
  * @file SaveConditionManager.cs
  * @brief 根据存档位使用情况，修改UI
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → Panel Save → SaveConditionManager \n
  * 若存档没有被使用，在仿真场景中查看该存档则需要显示Save按钮以供用户存档；\n
  * 在主菜单中查看该存档则不能有任何按钮。\n
  * 若存档已经被使用，在仿真场景中查看该存档则需要显示Save按钮和Load按钮，分别提供存档和读档的功能；\n
  * 在主菜单中查看该存档则需要显示Load按钮和Delete按钮，分别提供读档和删档功能。
  * @author 李雨航
  * @date 2022-01-06
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class SaveConditionManager : MonoBehaviour
{
    /// 存档1的赛道编号
    public static int Save1Track = 0;
    /// 存档2的赛道编号
    public static int Save2Track = 0;
    /// 存档3的赛道编号
    public static int Save3Track = 0;
    /// 存档4的赛道编号
    public static int Save4Track = 0;

    /// 存档1的赛道编号显示UI
    public GameObject Save1TrackDisplay;
    /// 存档1的赛道编号显示UI
    public GameObject Save2TrackDisplay;
    /// 存档1的赛道编号显示UI
    public GameObject Save3TrackDisplay;
    /// 存档1的赛道编号显示UI
    public GameObject Save4TrackDisplay;

    /// 存档1的按钮
    public GameObject Save1button;
    /// 存档1的按钮
    public GameObject Save2button;
    /// 存档1的按钮
    public GameObject Save3button;
    /// 存档1的按钮
    public GameObject Save4button;

    void Start()
    {
        SaveCondition saveCondition = new SaveCondition();
        if (!File.Exists(Application.dataPath + "/saveCondition.txt"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(Application.dataPath + "/saveCondition.txt");
            binaryFormatter.Serialize(fileStream, saveCondition);
            fileStream.Close();
        }
        else
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.dataPath + "/saveCondition.txt", FileMode.Open);
            saveCondition = (SaveCondition)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }

        Save1Track = saveCondition.Save1Track;
        Save2Track = saveCondition.Save2Track;
        Save3Track = saveCondition.Save3Track;
        Save4Track = saveCondition.Save4Track;
    }


    void Update()
    {
        if (Save1Track == 0)
        {
            Save1TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save1button.SetActive(false);
        }
        else
        {
            Save1TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save1button.SetActive(true);
        }

        if (Save2Track == 0)
        {
            Save2TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save2button.SetActive(false);
        }
        else
        {
            Save2TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save2button.SetActive(true);
        }

        if (Save3Track == 0)
        {
            Save3TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save3button.SetActive(false);
        }
        else
        {
            Save3TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save3button.SetActive(true);
        }

        if (Save4Track == 0)
        {
            Save4TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save4button.SetActive(false);
        }
        else
        {
            Save4TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save4button.SetActive(true);
        }
    }
    
}
