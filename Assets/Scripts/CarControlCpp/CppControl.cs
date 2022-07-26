using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CppControl
{

    //CarControlCpp函数在Cpp文件中编写
    [DllImport("CppControl")]
    public static extern void CarControlCpp();

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
    public delegate float FloatDelegate();
    public delegate double doubleDelegate();

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
    public delegate void CarMoveDelegate(float steering, float accel, float footbrake, float handbrake);

    [DllImport("CppControl")]
    public static extern void InitCarMoveDelegate(CarMoveDelegate GetCarMove);

    //C# Function for C++'s call
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackSpeedFromCpp()
    {
        return SpeedDisplay.speed;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackPositionXFromCpp()
    {
        return MiniMap2.CarPosition.x;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackPositionYFromCpp()
    {
        return MiniMap2.CarPosition.y;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackPositionZFromCpp()
    {
        return MiniMap2.CarPosition.z;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static double CallbackCruiseErrorFromCpp()
    {
        return CruiseData.DistanceError;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static double CallbackCurvatureFromCpp()
    {
        return CruiseData.Curvature;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackAngleErrorFromCpp()
    {
        return CruiseData.AngleError;
    }

    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static void GetCarMoveFromCpp(float steering, float accel, float footbrake, float handbrake)
    {
        CppCarControl.steering = steering;
        CppCarControl.accel = accel;
        CppCarControl.footbrake = footbrake;
        CppCarControl.handbrake = handbrake;
    }
}
