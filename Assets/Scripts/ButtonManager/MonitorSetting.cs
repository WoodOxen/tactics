/**
  * @file MonitorSetting.cs
  * @brief 实现用户添加监视器的功能并储存用户对监视器的设置
  * @details 
  * 挂载该脚本的对象：TrackSelect → Canvas →ButtonPanel → Panel → AddMonotors → MonitorDropDownManager \n
  * 用户对监视器的设置包括：监视器数目（≤3）、监视器目标、监视器的监视角度。\n
  * 这些设置都是通过DropDown实现，而非Button。\n
  * 用户在进入TrackSelect场景后，会调用该脚本的Start()函数，根据用户的过往设置初始化相关的DropDown。\n
  * 之后在RaceArea场景中MonitorManager.cs脚本根据用户的设置对监视器进行初始化时，需要获取该脚本中储存的参数。
  * @param NumofMonitor 监视器数量
  * @param MonitorObject 监视对象
  * @param MonitorPerspective 监视角度
  * @author 李雨航
  * @date 2023-12-31
  */

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

    /**
     * @fn SetNumofMonitor
     * @brief 用户设置监视器数量
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置监视器数量，将该值存为NumofMonitor参数
     */
    public void SetNumofMonitor(int value)
    {
        NumofMonitor = value;
        if(NumofMonitor > 3 || NumofMonitor < 0) NumofMonitor = 0;
        PlayerPrefs.SetInt("NumofMonitor", NumofMonitor);
    }
    /**
     * @fn SetMonitor1Object
     * @brief 用户设置1号监视器的监视对象
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置1号监视器的监视对象，将该值存入MonitorObject[0]
     */
    public void SetMonitor1Object(int value)
    {
        MonitorObject[0] = value;
        if (MonitorObject[0] > 7 || MonitorObject[0] < 0) MonitorObject[0] = 0;
        PlayerPrefs.SetInt("Monitor1Object", MonitorObject[0]);
    }
    /**
     * @fn SetMonitor2Object
     * @brief 用户设置2号监视器的监视对象
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置2号监视器的监视对象，将该值存入MonitorObject[1]
     */
    public void SetMonitor2Object(int value)
    {
        MonitorObject[1] = value;
        if (MonitorObject[1] > 7 || MonitorObject[1] < 0) MonitorObject[1] = 0;
        PlayerPrefs.SetInt("Monitor2Object", MonitorObject[1]);
    }
    /**
     * @fn SetMonitor3Object
     * @brief 用户设置3号监视器的监视对象
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置3号监视器的监视对象，将该值存入MonitorObject[2]
     */
    public void SetMonitor3Object(int value)
    {
        MonitorObject[2] = value;
        if (MonitorObject[2] > 7 || MonitorObject[2] < 0) MonitorObject[2] = 0;
        PlayerPrefs.SetInt("Monitor3Object", MonitorObject[2]);
    }
    /**
     * @fn SetMonitor1Perspective
     * @brief 用户设置1号监视器的监视角度
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置1号监视器的监视角度，将该值存入MonitorPerspective[0]
     */
    public void SetMonitor1Perspective(int value)
    {
        MonitorPerspective[0] = value;
        if (MonitorPerspective[0] != 0 && MonitorPerspective[0] != 1) MonitorPerspective[0] = 0;
        PlayerPrefs.SetInt("Monitor1Perspective", MonitorPerspective[0]);
    }
    /**
     * @fn SetMonitor2Perspective
     * @brief 用户设置2号监视器的监视角度
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置2号监视器的监视角度，将该值存入MonitorPerspective[1]
     */
    public void SetMonitor2Perspective(int value)
    {
        MonitorPerspective[1] = value;
        if (MonitorPerspective[1] != 0 && MonitorPerspective[1] != 1) MonitorPerspective[1] = 0;
        PlayerPrefs.SetInt("Monitor2Perspective", MonitorPerspective[1]);
    }
    /**
     * @fn SetMonitor3Perspective
     * @brief 用户设置3号监视器的监视角度
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户可以通过dropdown(下拉式菜单)设置3号监视器的监视角度，将该值存入MonitorPerspective[2]
     */
    public void SetMonitor3Perspective(int value)
    {
        MonitorPerspective[2] = value;
        if (MonitorPerspective[2] != 0 && MonitorPerspective[2] != 1) MonitorPerspective[2] = 0;
        PlayerPrefs.SetInt("Monitor3Perspective", MonitorPerspective[2]);
    }

}
