/**
  * @file CallCppControl.cs
  * @brief 调用外部cpp代码，控制车辆运行
  * @details  
  * 挂载该脚本的对象：RaceArea → CppControl \n
  * 为保证仿真确定性，不使用Update()函数而使用FixedUpdate()函数。\n
  * 仿真开始时，在Start()内会调用CppControl.InitializeCppControl()，进行仿真初始化。\n
  * 每次在FixedUpdate()中调用CppControl.CarControlCpp()函数。\n
  * InitializeCppControl()函数和CarControlCpp()函数定义在CppControl.cs脚本中，但实际内容在外部cpp代码中实现。\n
  * 用户在CarControlCpp()中编写代码进行运算，将运算得到的控制参数（即steering、accel、footbrake、handbrake）通过CarMove函数传递到CppControl.cs脚本中的steering[]、accel[]、footbrake[]、handbrake[]数组中，再在CppControl.cs脚本中使用CarController.Move函数控制车辆运行。
  * @param steering 各个车辆输入的方向盘转角
  * @param accel 各个车辆输入的油门值
  * @param footbrake 各个车辆输入的脚刹值
  * @param handbrake 各个车辆输入的手刹值
  * @author 李雨航
  * @date 2022-12-31
  */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CallCppControl : MonoBehaviour
{
    /// 各车辆
    public GameObject[] TheCar;
    /// 输入给各车辆的steer
    public static float[] steering = new float[8] { 0, 0, 0, 0 ,0, 0, 0, 0 };
    /// 输入给各车辆的accel
    public static float[] accel = new float[8] { 0, 0, 0, 0 ,0, 0, 0, 0 };
    /// 输入给各车辆的footbrake
    public static float[] footbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 输入给各车辆的handbrake
    public static float[] handbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

    private int playNum;
    private CarController[] m_Car = new CarController[8];
    private int[] ControlMethod = new int[8] { 0, 0, 0, 0, 2, 2, 2, 2 };



    void Start()
    {
        steering = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        accel = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        footbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        handbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        CppControl.InitializeCppControl();
        ///*
        playNum = GameSetting.NumofPlayer;
        for(int i = 0;i < playNum;i++)
        {
            m_Car[i] = TheCar[i].GetComponent<CarController>();
            ControlMethod[i] = GameSetting.ControlMethod[i];
        }//*/
    }

    void FixedUpdate()
    {
        CppControl.CarControlCpp();
        ///*
        for (int i = 0; i < playNum; i++)
        {
            if (ControlMethod[i] == 2)
            {
                m_Car[i].Move(steering[i], accel[i], footbrake[i], handbrake[i]);
                RecordControllerOutput.steer[i].Add(steering[i]);
                RecordControllerOutput.accel[i].Add(accel[i]);
                RecordControllerOutput.footbrake[i].Add(footbrake[i]);
                RecordControllerOutput.handbrake[i].Add(handbrake[i]);
            }
        }
        //*/
    }
}
