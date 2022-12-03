using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonitorSetting : MonoBehaviour
{
    public static int NumofMonitor = 0;
    public static int[] MonitorObject = new int[3] { 0, 0, 0 };
    public static int[] MonitorPerspective = new int[3] { 0, 0, 0 };

    public GameObject DropdowmMonitorNum;
    public GameObject[] DropdowmMonitorObject;
    public GameObject[] DropdowmMonitorPerspective;

    void Start()
    {
        //读取历史记录
        if (PlayerPrefs.HasKey("NumofMonitor")) NumofMonitor = PlayerPrefs.GetInt("NumofMonitor");
        else NumofMonitor = 0;

        for(int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.HasKey("Monitor"+i.ToString()+ "Object"))
                MonitorObject[i-1] = PlayerPrefs.GetInt("Monitor" + i.ToString() + "Object");
            else MonitorObject[i-1] = 0;

            if (PlayerPrefs.HasKey("Monitor" + i.ToString() +"Perspective"))
                MonitorPerspective[i-1] = PlayerPrefs.GetInt("Monitor" + i.ToString() + "Perspective");
            else MonitorPerspective[i-1] = 0;
        }

        //默认按照历史记录设置监视器
        DropdowmMonitorNum.GetComponent<TMP_Dropdown>().value = NumofMonitor;
        for (int i = 0; i < 3; i++)
        {
            DropdowmMonitorObject[i].GetComponent<TMP_Dropdown>().value = MonitorObject[i];
            DropdowmMonitorPerspective[i].GetComponent<TMP_Dropdown>().value = MonitorPerspective[i];
        }
    }

    public void SetNumofMonitor(int value)
    {
        NumofMonitor = value;
        if(NumofMonitor > 3 || NumofMonitor < 0) NumofMonitor = 0;
        PlayerPrefs.SetInt("NumofMonitor", NumofMonitor);
    }

    public void SetMonitor1Object(int value)
    {
        MonitorObject[0] = value;
        if (MonitorObject[0] > 7 || MonitorObject[0] < 0) MonitorObject[0] = 0;
        PlayerPrefs.SetInt("Monitor1Object", MonitorObject[0]);
    }

    public void SetMonitor2Object(int value)
    {
        MonitorObject[1] = value;
        if (MonitorObject[1] > 7 || MonitorObject[1] < 0) MonitorObject[1] = 0;
        PlayerPrefs.SetInt("Monitor2Object", MonitorObject[1]);
    }

    public void SetMonitor3Object(int value)
    {
        MonitorObject[2] = value;
        if (MonitorObject[2] > 7 || MonitorObject[2] < 0) MonitorObject[2] = 0;
        PlayerPrefs.SetInt("Monitor3Object", MonitorObject[2]);
    }

    public void SetMonitor1Perspective(int value)
    {
        MonitorPerspective[0] = value;
        if (MonitorPerspective[0] != 0 && MonitorPerspective[0] != 1) MonitorPerspective[0] = 0;
        PlayerPrefs.SetInt("Monitor1Perspective", MonitorPerspective[0]);
    }

    public void SetMonitor2Perspective(int value)
    {
        MonitorPerspective[1] = value;
        if (MonitorPerspective[1] != 0 && MonitorPerspective[1] != 1) MonitorPerspective[1] = 0;
        PlayerPrefs.SetInt("Monitor2Perspective", MonitorPerspective[1]);
    }

    public void SetMonitor3Perspective(int value)
    {
        MonitorPerspective[2] = value;
        if (MonitorPerspective[2] != 0 && MonitorPerspective[2] != 1) MonitorPerspective[2] = 0;
        PlayerPrefs.SetInt("Monitor3Perspective", MonitorPerspective[2]);
    }

}
