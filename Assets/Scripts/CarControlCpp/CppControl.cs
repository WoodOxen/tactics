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

    /*
    //定义callback类型
    public delegate void LogDelegate(IntPtr message, int iSize);

    [DllImport("CppControl")]
    public static extern void InitCSharpDelegate(LogDelegate log);

    //C# Function for C++'s call
    [MonoPInvokeCallback(typeof(LogDelegate))]
    public static void LogMessageFromCpp(IntPtr message, int iSize)
    {
        Debug.Log(Marshal.PtrToStringAnsi(message, iSize));
    }
    */
    //定义callback类型
    public delegate float FloatDelegate(int CarNum);
    public delegate double doubleDelegate(int CarNum);

    [DllImport("CppControl")]
    public static extern void InitSpeedDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPositionXDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPositionYDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitPositionZDelegate(FloatDelegate callbackFloat);
    [DllImport("CppControl")]
    public static extern void InitCruiseErrorDelegate(doubleDelegate callbackdouble);
    [DllImport("CppControl")]
    public static extern void InitCurvatureDelegate(doubleDelegate callbackdouble);
    [DllImport("CppControl")]
    public static extern void InitAngleErrorDelegate(FloatDelegate callbackFloat);

    //定义callback类型
    public delegate void CarMoveDelegate(float steering, float accel, float footbrake, float handbrake, int CarNum);

    [DllImport("CppControl")]
    public static extern void InitCarMoveDelegate(CarMoveDelegate GetCarMove);

    //C# Function for C++'s call
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackSpeedFromCpp(int CarNum)
    {
        return SpeedDisplay.speed[CarNum];
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackPositionXFromCpp(int CarNum)
    {
        return MiniMap2.CarPosition[CarNum].x;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackPositionYFromCpp(int CarNum)
    {
        return MiniMap2.CarPosition[CarNum].y;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackPositionZFromCpp(int CarNum)
    {
        return MiniMap2.CarPosition[CarNum].z;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static double CallbackCruiseErrorFromCpp(int CarNum)
    {
        return CruiseData.DistanceError[CarNum];
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static double CallbackCurvatureFromCpp(int CarNum)
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
