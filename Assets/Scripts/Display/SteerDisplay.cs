/**
  * @file SteerDisplay.cs
  * @brief 获取每辆车的方向盘转角，并显示在屏幕下方的UI上
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UIBottom → SteerDisplay → SteerDisplayManager \n
  * 在第一人称视角模式下，除了显示方向盘转角数值，还会显示方向盘的贴图。\n
  * 和SpeedDisplay.cs不同（有一个Speed数组，分别储存每辆车的速度），只有一个steer参数储存当前视角所跟随车辆的方向盘转角。
  * @param steer 当前视角所跟随车辆的方向盘转角
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SteerDisplay : MonoBehaviour
{
    private float Steer;
    
    public GameObject SteerWheel;
    public GameObject steerDisplaybox;

    private int PlayerNum;

    void FixedUpdate()
    {
        PlayerNum = ViewModeManager.CamNum;//当前视角跟随的车辆编号
        if(GameSetting.ControlMethod[PlayerNum] == 1)//Keyboard
        {
            Steer = CarControlKeyBoard.h[PlayerNum];
        }
        else//ScriptControl
        {
            Steer = CallCppControl.steering[PlayerNum];
        }
        
        SteerWheel.transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Steer*-90);
        steerDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + Steer.ToString("#0.00");
    }
}
