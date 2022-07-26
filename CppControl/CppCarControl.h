#pragma once
#define DLLForUnity_API _declspec(dllexport)
//#define UnityLog(acStr)  char acLogStr[512] = { 0 }; sprintf_s(acLogStr, "%s",acStr); Debug::Log(acLogStr,strlen(acStr));

//C++ Call C#

EXTERN_C class TacticAPI
{
//接口定义
public:
	static float (*Speed)(); //返回小车速度
	static float (*PositionX)(); //返回小车X坐标
	static float (*PositionY)(); //返回小车Y坐标
	static float (*PositionZ)(); //返回小车Z坐标
	static double (*CruiseError)(); //返回小车距离赛道中心线的距离
	static void (*CarMove)(float steering, float accel, float footbrake, float handbrake); //传递四个参数(steering、accel、footbrake，handbrake)控制小车移动
	static double (*Curvature)(); //返回前方赛道中心线的曲率
	static float (*AngleError)(); //返回小车方向和赛道中心线方向的偏差
};


//下为接口定义相关代码，无需阅读
//C# Call C++

EXTERN_C void DLLForUnity_API InitSpeedDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitPositionXDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitPositionYDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitPositionZDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitCruiseErrorDelegate(double (*callbackdouble)());
EXTERN_C void DLLForUnity_API InitCurvatureDelegate(double (*callbackdouble)());
EXTERN_C void DLLForUnity_API InitAngleErrorDelegate(float (*callbackFloat)());

EXTERN_C void DLLForUnity_API InitCarMoveDelegate(void (*GetCarMove)(float steering, float accel, float footbrake, float handbrake));

EXTERN_C DLLForUnity_API void __stdcall CarControlCpp();

/*
EXTERN_C class Debug
{
	public:
		static void (*Log)(char* message, int iSize);
};
//EXTERN_C void DLLForUnity_API InitCSharpDelegate(void (*Log)(char* message, int iSize));
*/

