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
    private static CruiseData[] cruiseDatas = new CruiseData[8];

    void Start()
    {
        for (int i = 0; i < GameSetting.NumofPlayer; i++)
        {
            TheCarController[i] = TheCar[i].GetComponent<CarController>();
            cruiseDatas[i] = TheCar[i].GetComponent<CruiseData>();
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
    public delegate float FloatDelegate2(int CarNum, float k, int index);
    public delegate float FloatDelegate3();
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
    /**
     * @fn InitYawrateDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆角速度的api
     */
    [DllImport("CppControl")]
    public static extern void InitYawrateDelegate(FloatDelegate callbackfloat);
    /**
     * @fn InitMidlineDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆前方路标点的api
     */
    [DllImport("CppControl")]
    public static extern void InitMidlineDelegate(FloatDelegate2 callbackfloat);
    /**
     * @fn InitWidthDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取道路宽度的api
     */
    [DllImport("CppControl")]
    public static extern void InitWidthDelegate(FloatDelegate3 callbackfloat);
    /**
     * @fn InitAccDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化获取车辆加速度的api
     */
    [DllImport("CppControl")]
    public static extern void InitAccDelegate(FloatDelegate callbackfloat);

    //定义callback类型
    public delegate void CarMoveDelegate(int CarNum, float steering, float accel, float footbrake, float handbrake);
    /**
     * @fn InitCarMoveDelegate
     * @brief 该函数在Cpp文件中编写，仿真开始时在StartManager.cs中调用，初始化传输车辆控制参数的api
     */
    [DllImport("CppControl")]
    public static extern void InitCarMoveDelegate(CarMoveDelegate GetCarMove);

    //C# Function for C++'s call
    /**
     * @fn CallbackPlayerNumFromCpp
     * @brief 在cpp代码中，使用TacticAPI::player_num()可调用该函数
     * @return int 车辆数目
     */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static int CallbackPlayerNumFromCpp()
    {
        return GameSetting.NumofPlayer;
    }
    /**
    * @fn CallbackSpeedFromCpp
    * @brief 在cpp代码中，使用TacticAPI::speed(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆的速度
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackSpeedFromCpp(int CarNum)
    {
        return GetRaceData.speed[CarNum];
    }
    /**
    * @fn CallbackCruiseErrorFromCpp
    * @brief 在cpp代码中，使用TacticAPI::cruise_error(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆距道路中线距离
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCruiseErrorFromCpp(int CarNum)
    {
        //return CruiseData.DistanceError[CarNum];
        return GetRaceData.distance_error[CarNum];
    }
    /**
    * @fn CallbackCurvatureFromCpp
    * @brief 在cpp代码中，使用TacticAPI::curvature(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆前方道路的曲率
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCurvatureFromCpp(int CarNum)
    {
        //return CruiseData.Curvature[CarNum];
        return GetRaceData.curvature[CarNum];
    }
    /**
    * @fn CallbackAngleErrorFromCpp
    * @brief 在cpp代码中，使用TacticAPI::yaw(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆与道路中线的角度偏差
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackAngleErrorFromCpp(int CarNum)
    {
        //return CruiseData.AngleError[CarNum];
        return GetRaceData.yaw[CarNum];
    }
    /**
    * @fn CallbackYawrateFromCpp
    * @brief 在cpp代码中，使用TacticAPI::yawrate(int CarNum)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆的角速度
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackYawrateFromCpp(int CarNum)
    {
        //return CruiseData.AngleError[CarNum];
        return GetRaceData.yawrate[CarNum];
    }
    /**
    * @fn CallbackWidthFromCpp
    * @brief 在cpp代码中，使用TacticAPI::width()可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 道路宽度
    */
    [MonoPInvokeCallback(typeof(FloatDelegate3))]
    public static float CallbackWidthFromCpp()
    {
        return GetRaceData.width;
    }
    /**
    * @fn CallbackAccFromCpp
    * @brief 在cpp代码中，使用TacticAPI::acc()可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号车辆的加速度
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackAccFromCpp(int CarNum)
    {
        return GetRaceData.acc[CarNum];
    }
    /**
    * @fn CallbackAngleErrorFromCpp
    * @brief 在cpp代码中，使用TacticAPI::midline(int CarNum,float k,int index)可调用该函数
    * @param[in] CarNum 车辆编号
    * @return float 第CarNum号在道路中线前方k米处的相对于当前车辆坐标系的坐标
    */
    [MonoPInvokeCallback(typeof(FloatDelegate2))]
    public static float CallbackMidlineFromCpp(int CarNum, float k, int index)
    {
        Vector3 WP = cruiseDatas[CarNum].GetWPkRelative(k);
        float ans = 0;
        if (index == 0)
            ans = WP.x;
        else if (index == 1)
            ans = WP.z;
        else if (index == 2)
            ans = WP.y;
        else
            ans = 0;
        return ans;
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
    public static void GetCarMoveFromCpp(int CarNum, float steering, float accel, float footbrake, float handbrake)
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
