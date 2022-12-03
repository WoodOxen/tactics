using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CppControl
{

    //CarControlCpp、InitializeCppControl函数在Cpp文件中编写
    [DllImport("CppControl")]
    public static extern void CarControlCpp();
    [DllImport("CppControl")]
    public static extern void InitializeCppControl();

    //定义callback类型
    public delegate float FloatDelegate(int CarNum);
    public delegate double doubleDelegate(int CarNum);
    public delegate int intDelegate();

    [DllImport("CppControl")]
    public static extern void InitSpeedDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPositionXDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPositionYDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPositionZDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitCruiseErrorDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitCurvatureDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitAngleErrorDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPlayerNumDelegate(intDelegate callbackint);

    //定义callback类型
    public delegate void CarMoveDelegate(float steering, float accel, float footbrake, float handbrake, int CarNum);

    [DllImport("CppControl")]
    public static extern void InitCarMoveDelegate(CarMoveDelegate GetCarMove);

    //C# Function for C++'s call
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static int CallbackPlayerNumFromCpp()
    {
        return GameSetting.NumofPlayer;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackSpeedFromCpp(int CarNum)
    {
        return SpeedDisplay.speed[CarNum];
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCruiseErrorFromCpp(int CarNum)
    {
        return CruiseData.DistanceError[CarNum];
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCurvatureFromCpp(int CarNum)
    {
        return CruiseData.Curvature[CarNum];
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackAngleErrorFromCpp(int CarNum)
    {
        return CruiseData.AngleError[CarNum];
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static void GetCarMoveFromCpp(float steering, float accel, float footbrake, float handbrake, int CarNum)
    {
        CallCppControl.steering[CarNum] = steering;
        CallCppControl.accel[CarNum] = accel;
        CallCppControl.footbrake[CarNum] = footbrake;
        CallCppControl.handbrake[CarNum] = handbrake;
    }
}
