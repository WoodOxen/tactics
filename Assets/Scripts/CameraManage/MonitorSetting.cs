using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonitorSetting : MonoBehaviour
{
    public static int NumofMonitor = 0;
    public static int Monitor1Object = 0;
    public static int Monitor2Object = 0;
    public static int Monitor3Object = 0;
    public static int Monitor1Perspective = 0;
    public static int Monitor2Perspective = 0;
    public static int Monitor3Perspective = 0;

    public GameObject dropdown1;
    public GameObject dropdown2;
    public GameObject dropdown3;
    public GameObject dropdown4;
    public GameObject dropdown5;
    public GameObject dropdown6;
    public GameObject dropdown7;

    void Start()
    {
        if (PlayerPrefs.HasKey("NumofMonitor")) NumofMonitor = PlayerPrefs.GetInt("NumofMonitor");
        else NumofMonitor = 0;

        if (PlayerPrefs.HasKey("Monitor1Object")) Monitor1Object = PlayerPrefs.GetInt("Monitor1Object");
        else Monitor1Object = 0;

        if (PlayerPrefs.HasKey("Monitor2Object"))Monitor2Object = PlayerPrefs.GetInt("Monitor2Object");
        else Monitor2Object = 0;

        if (PlayerPrefs.HasKey("Monitor3Object")) Monitor3Object = PlayerPrefs.GetInt("Monitor3Object");
        else Monitor3Object = 0;

        if (PlayerPrefs.HasKey("Monitor1Perspective"))Monitor1Perspective = PlayerPrefs.GetInt("Monitor1Perspective");
        else  Monitor1Perspective = 0;

        if (PlayerPrefs.HasKey("Monitor2Perspective")) Monitor2Perspective = PlayerPrefs.GetInt("Monitor2Perspective");
        else Monitor2Perspective = 0;

        if (PlayerPrefs.HasKey("Monitor3Perspective")) Monitor3Perspective = PlayerPrefs.GetInt("Monitor3Perspective");
        else Monitor3Perspective = 0;

        dropdown1.GetComponent<TMP_Dropdown>().value = NumofMonitor;
        dropdown2.GetComponent<TMP_Dropdown>().value = Monitor1Object;
        dropdown3.GetComponent<TMP_Dropdown>().value = Monitor2Object;
        dropdown4.GetComponent<TMP_Dropdown>().value = Monitor3Object;
        dropdown5.GetComponent<TMP_Dropdown>().value = Monitor1Perspective;
        dropdown6.GetComponent<TMP_Dropdown>().value = Monitor2Perspective;
        dropdown7.GetComponent<TMP_Dropdown>().value = Monitor3Perspective;
    }

    public void SetNumofMonitor(int value)
    {
        switch (value)
        {
            case 0:
                NumofMonitor = 0;
                break;
            case 1:
                NumofMonitor = 1;
                break;
            case 2:
                NumofMonitor = 2;
                break;
            case 3:
                NumofMonitor = 3;
                break;
            default:
                NumofMonitor = 0;
                break;
        }
        PlayerPrefs.SetInt("NumofMonitor", NumofMonitor);
    }

    public void SetMonitor1Object(int value)
    {
        switch (value)
        {
            case 0:
                Monitor1Object = 0;
                break;
            case 1:
                Monitor1Object = 1;
                break;
            case 2:
                Monitor1Object = 2;
                break;
            case 3:
                Monitor1Object = 3;
                break;
            default:
                Monitor1Object = 0;
                break;
        }
        PlayerPrefs.SetInt("Monitor1Object", Monitor1Object);
    }

    public void SetMonitor2Object(int value)
    {
        switch (value)
        {
            case 0:
                Monitor2Object = 0;
                break;
            case 1:
                Monitor2Object = 1;
                break;
            case 2:
                Monitor2Object = 2;
                break;
            case 3:
                Monitor2Object = 3;
                break;
            default:
                Monitor2Object = 0;
                break;
        }
        PlayerPrefs.SetInt("Monitor2Object", Monitor2Object);
    }

    public void SetMonitor3Object(int value)
    {
        switch (value)
        {
            case 0:
                Monitor3Object = 0;
                break;
            case 1:
                Monitor3Object = 1;
                break;
            case 2:
                Monitor3Object = 2;
                break;
            case 3:
                Monitor3Object = 3;
                break;
            default:
                Monitor3Object = 0;
                break;
        }
        PlayerPrefs.SetInt("Monitor3Object", Monitor3Object);
    }

    public void SetMonitor1Perspective(int value)
    {
        switch (value)
        {
            case 0:
                Monitor1Perspective = 0;
                break;
            case 1:
                Monitor1Perspective = 1;
                break;
            default:
                Monitor1Perspective = 0;
                break;
        }
        PlayerPrefs.SetInt("Monitor1Perspective", Monitor1Perspective);
    }

    public void SetMonitor2Perspective(int value)
    {
        switch (value)
        {
            case 0:
                Monitor2Perspective = 0;
                break;
            case 1:
                Monitor2Perspective = 1;
                break;
            default:
                Monitor2Perspective = 0;
                break;
        }
        PlayerPrefs.SetInt("Monitor2Perspective", Monitor2Perspective);
    }

    public void SetMonitor3Perspective(int value)
    {
        switch (value)
        {
            case 0:
                Monitor3Perspective = 0;
                break;
            case 1:
                Monitor3Perspective = 1;
                break;
            default:
                Monitor3Perspective = 0;
                break;
        }
        PlayerPrefs.SetInt("Monitor3Perspective", Monitor3Perspective);
    }

}
