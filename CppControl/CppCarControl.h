#pragma once
#define DLLForUnity_API _declspec(dllexport)
//#define UnityLog(acStr)  char acLogStr[512] = { 0 }; sprintf_s(acLogStr, "%s",acStr); Debug::Log(acLogStr,strlen(acStr));

//C++ Call C#

EXTERN_C class TacticAPI
{
//接口定义
public:
	//传递四个参数(steering、accel、footbrake，handbrake)控制小车移动
	static void (*CarMove)(int CarNum, float steering, float accel, float footbrake, float handbrake);

	static float (*speed)(int CarNum); //返回小车速度
	static float (*acc)(int CarNum);//返回小车加速度
	static float (*midline)(int CarNum, float k, int index); //返回小车沿中心线k米处的道路中心坐标
	static float (*cruise_error)(int CarNum); //返回小车距离赛道中心线的距离
	static float (*curvature)(int CarNum); //返回前方赛道中心线的曲率
	static float (*yaw)(int CarNum); //返回小车方向和赛道中心线方向的偏差
	static float (*yawrate)(int CarNum); //返回小车角速度
	static int (*player_num)(); //返回小车数量
	static float (*width)();//返回道路宽度
};

void CarControli(int i);

//下为接口定义相关代码，无需阅读
//C# Call C++

EXTERN_C void DLLForUnity_API InitSpeedDelegate(float (*callbackFloat)(int CarNum));
EXTERN_C void DLLForUnity_API InitAccDelegate(float (*callbackFloat)(int CarNum));
//EXTERN_C void DLLForUnity_API InitPositionXDelegate(float (*callbackFloat)(int CarNum));
//EXTERN_C void DLLForUnity_API InitPositionYDelegate(float (*callbackFloat)(int CarNum));
//EXTERN_C void DLLForUnity_API InitPositionZDelegate(float (*callbackFloat)(int CarNum));
EXTERN_C void DLLForUnity_API InitCruiseErrorDelegate(float (*callbackFloat)(int CarNum));
EXTERN_C void DLLForUnity_API InitCurvatureDelegate(float (*callbackFloat)(int CarNum));
EXTERN_C void DLLForUnity_API InitAngleErrorDelegate(float (*callbackFloat)(int CarNum));
EXTERN_C void DLLForUnity_API InitYawrateDelegate(float (*callbackFloat)(int CarNum));
EXTERN_C void DLLForUnity_API InitPlayerNumDelegate(int (*callbackint)());
EXTERN_C void DLLForUnity_API InitMidlineDelegate(float (*callbackfloat)(int CarNum, float k, int index));
EXTERN_C void DLLForUnity_API InitWidthDelegate(float (*callbackfloat)());
EXTERN_C void DLLForUnity_API InitCarMoveDelegate(void (*GetCarMove)(int CarNum, float steering, float accel, float footbrake, float handbrake));

EXTERN_C DLLForUnity_API void __stdcall CarControlCpp();
EXTERN_C DLLForUnity_API void __stdcall InitializeCppControl();
/*
EXTERN_C class Debug
{
	public:
		static void (*Log)(char* message, int iSize);
};
//EXTERN_C void DLLForUnity_API InitCSharpDelegate(void (*Log)(char* message, int iSize));
*/

