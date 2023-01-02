/**
  * @file CppControl.cs
  * @brief 实现Cpp代码和Unity的接口
  * @details  
  * 挂载该脚本的对象：无 \n
  * API的详细情况请参考CppControl.cs和CppCarControl.h中的定义。
  * @author 李雨航
  * @date 2023-01-01
  */


using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CppControl : MonoBehaviour
{
    public GameObject[] TheCar;
    private static CarController[] TheCarController = new CarController[8];

    void Start()
    {
        for (int i = 0; i < GameSetting.NumofPlayer; i++)
        {
            TheCarController[i] = TheCar[i].GetComponent<CarController>();
        }
    }

    //CarControlCpp、InitializeCppControl函数在Cpp文件中编写
    /**
     * @fn CarControlCpp
     * @brief 该函数在Cpp文件中编写，每个物理帧调用一次
     */
    [DllImport("CppControl")]
    public static extern void CarControlCpp();
    /**
     * @fn InitializeCppControl
     * @brief 该函数在Cpp文件中编写，仿真开始时调用，完成一些必要的初始化
     */
    [DllImport("CppControl")]
    public static extern void InitializeCppControl();

    //定义callback类型
    public delegate float FloatDelegate(int CarNum);
    public delegate double doubleDelegate(int CarNum);
    public delegate int intDelegate();

    /**
     * @fn InitSpeedDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆速度的api
     */
    [DllImport("CppControl")]
    public static extern void InitSpeedDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPositionXDelegate
     * @brief 该函数在Cpp文件中编写，暂时禁用
     */
    [DllImport("CppControl")]
    public static extern void InitPositionXDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPositionYDelegate
     * @brief 该函数在Cpp文件中编写，暂时禁用
     */
    [DllImport("CppControl")]
    public static extern void InitPositionYDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPositionZDelegate
     * @brief 该函数在Cpp文件中编写，暂时禁用
     */
    [DllImport("CppControl")]
    public static extern void InitPositionZDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitCruiseErrorDelegat
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆距道路中线距离的api
     */
    [DllImport("CppControl")]
    public static extern void InitCruiseErrorDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitCurvatureDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取前方道路曲率的api
     */
    [DllImport("CppControl")]
    public static extern void InitCurvatureDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitAngleErrorDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆和道路中线角度偏差的api
     */
    [DllImport("CppControl")]
    public static extern void InitAngleErrorDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPlayerNumDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆数目的api
     */
    [DllImport("CppControl")]
    public static extern void InitPlayerNumDelegate(intDelegate callbackint);


    //定义callback类型
    public delegate void CarMoveDelegate(float steering, float accel, float footbrake, float handbrake, int CarNum);
    /**
     * @fn InitCarMoveDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化传输车辆控制参数的api
     */
    [DllImport("CppControl")]
    public static extern void InitCarMoveDelegate(CarMoveDelegate GetCarMove);

    //C# Function for C++'s call
    /**
     * @fn CallbackPlayerNumFromCpp
     * @brief 在cpp代码中，使用TacticAPI::PlayerNum()可调用该函数
     * @return int 车辆数目
     */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static int CallbackPlayerNumFromCpp()
    {
        return GameSetting.NumofPlayer;
    }
    /**
    * @fn CallbackSpeedFromCpp
    * @brief 在cpp代码中，使用TacticAPI::Speed(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆的速度
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackSpeedFromCpp(int CarNum)
    {
        return SpeedDisplay.speed[CarNum];
    }
    /**
    * @fn CallbackCruiseErrorFromCpp
    * @brief 在cpp代码中，使用TacticAPI::CruiseError(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆距道路中线距离
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCruiseErrorFromCpp(int CarNum)
    {
        return CruiseData.DistanceError[CarNum];
    }
    /**
    * @fn CallbackCurvatureFromCpp
    * @brief 在cpp代码中，使用TacticAPI::Curvature(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆前方道路的曲率
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCurvatureFromCpp(int CarNum)
    {
        return CruiseData.Curvature[CarNum];
    }
    /**
    * @fn CallbackAngleErrorFromCpp
    * @brief 在cpp代码中，使用TacticAPI::AngleError(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆与道路中线的角度偏差
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackAngleErrorFromCpp(int CarNum)
    {
        return CruiseData.AngleError[CarNum];
    }
    /**
    * @fn GetCarMoveFromCpp
    * @brief 在cpp代码中，使用TacticAPI::CarMove(float steering, float accel, float footbrake, float handbrake, int CarNum)可调用该函数
    * @details 将需要输入给车辆的四个参数存入CallCppControl.cs，在CallCppControl.cs中再调用CarController的Move函数控制车辆移动
    * @param[in] CarNum 车辆编号
    * @param[in] steering 输入第CarNum号车辆的方向盘转角
    * @param[in] accel 输入第CarNum号车辆的油门值
    * @param[in] footbrake 输入第CarNum号车辆的脚刹值
    * @param[in] handbrake 输入第CarNum号车辆的手刹值
    * @return None
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static void GetCarMoveFromCpp(float steering, float accel, float footbrake, float handbrake, int CarNum)
    {
        //记录传递进来的四个参数
        CallCppControl.steering[CarNum] = steering;
        CallCppControl.accel[CarNum] = accel;
        CallCppControl.footbrake[CarNum] = footbrake;
        CallCppControl.handbrake[CarNum] = handbrake;
        //调用Move函数控制车辆移动
        /*
        if ((GameSetting.ControlMethod[CarNum] == 2) && (CarNum < GameSetting.NumofPlayer))
        {
            TheCarController[CarNum].Move(steering, accel, footbrake, handbrake);
            RecordControllerOutput.steer[CarNum].Add(steering);
            RecordControllerOutput.accel[CarNum].Add(accel);
            RecordControllerOutput.footbrake[CarNum].Add(footbrake);
            RecordControllerOutput.handbrake[CarNum].Add(handbrake);
        }*/
    }
}
