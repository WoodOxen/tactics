/**
  * @file SpeedDisplay.cs
  * @brief 获取每辆车的行驶速度，并显示在屏幕下方的UI上
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UIBottom → SpeedDisplay → SpeedDisplayManager \n
  * Cpp代码获取速度值是从该脚本中的Speed数组中获取，为保证仿真确定性，速度值刷新采用FixedUpdate函数
  * @param Speed 储存各车辆的行驶速度，但屏幕下方只显示当前视角跟随的车辆的速度值
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedDisplay : MonoBehaviour
{
    /// 各车辆
    //public GameObject[] TheCar;
    /// 各车辆速度
    //public static float[] speed;
    //private Vector3 velocity;
    private int PlayerNum;
    //private int TotalPlayerNum;
    /// 速度显示UI
    public GameObject speedDisplaybox;

    void Start()
    {
        //speed = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        //accelDebug = new float[4] { 0, 0, 0, 0 };
    }


    void Update()
    {
        //PlayerNum：当前相机跟随的车辆编号；TotalPlayerNum：总车辆数
        PlayerNum = ViewModeManager.CamNum;
        //TotalPlayerNum = GameSetting.NumofPlayer;
        /*
        for (int i = 0; i < TotalPlayerNum; i++)
        {
            velocity = TheCar[i].GetComponent<Rigidbody>().velocity;
            speed[i] = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
            //Debug.Log(string.Format("Speed {0} {1}: {2}", CallCppControl.a, i,speed[i]));
        }*/
        speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + GetRaceData.speed[PlayerNum].ToString("#0.00");
    }
}
