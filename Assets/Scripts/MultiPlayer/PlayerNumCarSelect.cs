using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNumCarSelect : MonoBehaviour
{

    void Start()
    {
        //GameObject.Find("Dropdown").GetComponent<Dropdown>().onValueChanged.AddListener(ConsoleResult);
    }


    /// <summary>
    /// 输出结果 —— 添加监听事件时要注意，需要绑定动态方法
    /// </summary>
    public void ConsoleResultCS(int value)
    {
        switch (value)
        {
            case 0:
                //Debug.Log(0);
                GameSetting.PlayerNumofCarSelect = 0;
                break;
            case 1:
                //Debug.Log(1);
                GameSetting.PlayerNumofCarSelect = 1;
                break;
            case 2:
                //Debug.Log(2);
                GameSetting.PlayerNumofCarSelect = 2;
                break; 
            case 3:
                //Debug.Log(3);
                GameSetting.PlayerNumofCarSelect = 3;
                break;
            default:
                Debug.Log(4);
                GameSetting.PlayerNumofCarSelect = 0;
                break;
        }
    }

    public void ConsoleResultCM(int value)
    {
        switch (value)
        {
            case 0:
                //Debug.Log(0);
                GameSetting.PlayerNumofControlMethod = 0;
                break;
            case 1:
                //Debug.Log(1);
                GameSetting.PlayerNumofControlMethod = 1;
                break;
            case 2:
                //Debug.Log(2);
                GameSetting.PlayerNumofControlMethod = 2;
                break;
            case 3:
                //Debug.Log(3);
                GameSetting.PlayerNumofControlMethod = 3;
                break;
            default:
                Debug.Log(4);
                GameSetting.PlayerNumofCarSelect = 0;
                break;
        }
    }

}


