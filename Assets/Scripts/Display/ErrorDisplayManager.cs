/**
  * @file ErrorDisplayManager.cs
  * @brief 获取每辆车距离赛道中心线的距离，并显示在屏幕下方的UI上
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UIBottom → ErrorDisplay → ErrorDisplayManager \n
  * 和SpeedDisplay.cs不同（有一个Speed数组，分别储存每辆车的速度），只有一个CruiseError参数储存当前视角所跟随车辆的巡线误差。
  * @param CruiseError 当前视角所跟随车辆的巡线误差
  * @param PlayerNum 当前观察的车辆编号
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorDisplayManager : MonoBehaviour
{
    public GameObject ErrorDisplaybox;
    private int PlayerNum;
    private double CruiseError;

    void Update()
    {
        PlayerNum = ViewModeManager.CamNum;
        CruiseError = CruiseData.DistanceError[PlayerNum];
        ErrorDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
    }
}
