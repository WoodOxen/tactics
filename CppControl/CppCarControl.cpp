#include "pch.h"
#include "CppCarControl.h"
#include <stdio.h>
#include <iostream>
#include <string.h>
#include <queue>

float CruiseError[8] = { 0,0,0,0,0,0,0,0 };
float Addup_CruiseError[8] = { 0,0,0,0,0,0,0,0 };
float Last_CruiseError[8] = { 0,0,0,0,0,0,0,0 };

float steering[8] = { 0,0,0,0,0,0,0,0 };
float accel[8] = { 0,0,0,0,0,0,0,0 };
float footbrake[8] = { 0,0,0,0,0,0,0,0 };
float handbrake[8] = { 0,0,0,0,0,0,0,0 };


int PlayerNum;

//Tactic在Race开始时会调用InitializeCppControl()函数，可以在此处做一些Cpp代码的初始化工作
DLLForUnity_API void __stdcall InitializeCppControl() {
    PlayerNum = TacticAPI::player_num();
    for (int i = 0; i < 8; i++) {
        CruiseError[i] = 0;
        Addup_CruiseError[i] = 0;
        Last_CruiseError[i] = 0;
        steering[i] = 0;
        accel[i] = 0;
        footbrake[i] = 0;
        handbrake[i] = 0;
    }
}

//Tactic每一帧会调用一次CarControlCpp()函数，修改此处的代码控制小车移动
//接口定义见CppCarControl.h文件
DLLForUnity_API void __stdcall CarControlCpp()
{
    CarControli(0);
    CarControli(1);
    CarControli(2);
    CarControli(3);
    CarControli(4);
    CarControli(5);
    CarControli(6);
    CarControli(7);
}

void CarControli(int i) {
    int CarNum = i;

    //speed control
    float DreamSpeed;

    if (TacticAPI::curvature(CarNum) == 0) DreamSpeed = 25;
    else DreamSpeed = 0.35 / TacticAPI::curvature(CarNum);
    if (DreamSpeed > 25) DreamSpeed = 25;
    if (DreamSpeed < 10) DreamSpeed = 10;
    accel[CarNum] = 0.1 * (DreamSpeed - TacticAPI::speed(CarNum));
    footbrake[CarNum] = 0.1 * (DreamSpeed - TacticAPI::speed(CarNum));

    //steering control
    CruiseError[CarNum] = TacticAPI::cruise_error(CarNum);
    Addup_CruiseError[CarNum] += CruiseError[CarNum] * 0.01;
    if (Addup_CruiseError[CarNum] > 200) Addup_CruiseError[CarNum] = 200;
    else if(Addup_CruiseError[CarNum] < -200) Addup_CruiseError[CarNum] = -200;

    steering[CarNum] = CruiseError[CarNum] * 0.06 + Addup_CruiseError[CarNum] * 0.0015 + (CruiseError[CarNum] - Last_CruiseError[CarNum]) * 3;
    handbrake[CarNum] = 0;

    Last_CruiseError[CarNum] = CruiseError[CarNum];

    TacticAPI::CarMove(CarNum, steering[CarNum], accel[CarNum], footbrake[CarNum], handbrake[CarNum]);
    //TacticAPI::CarMove(0,1,0,0, CarNum);
}




//下为接口定义相关代码，无需阅读
void(*TacticAPI::CarMove)(int CarNum, float steering, float accel, float footbrake, float handbrake);

float(*TacticAPI::speed)(int CarNum);
float(*TacticAPI::acc)(int CarNum);
//float(*TacticAPI::PositionX)(int CarNum);
//float(*TacticAPI::PositionY)(int CarNum);
//float(*TacticAPI::PositionZ)(int CarNum);
float(*TacticAPI::cruise_error)(int CarNum);
float(*TacticAPI::curvature)(int CarNum);
float(*TacticAPI::yaw)(int CarNum);
float(*TacticAPI::yawrate)(int CarNum);
float(*TacticAPI::midline)(int CarNum, float k, int index);
int(*TacticAPI::player_num)();
float(*TacticAPI::width)();

void DLLForUnity_API InitCarMoveDelegate(void (*GetCarMove)(int CarNum, float steering, float accel, float footbrake, float handbrake))
{
    TacticAPI::CarMove = GetCarMove;
}

void DLLForUnity_API InitSpeedDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::speed = callbackFloat;
}
void DLLForUnity_API InitAccDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::acc = callbackFloat;
}
/*
void DLLForUnity_API InitPositionXDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::PositionX = callbackFloat;
}
void DLLForUnity_API InitPositionYDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::PositionY = callbackFloat;
}
void DLLForUnity_API InitPositionZDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::PositionZ = callbackFloat;
}
*/
void DLLForUnity_API InitCruiseErrorDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::cruise_error = callbackFloat;
}
void DLLForUnity_API InitCurvatureDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::curvature = callbackFloat;
}
void DLLForUnity_API InitAngleErrorDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::yaw = callbackFloat;
}
void DLLForUnity_API InitYawrateDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::yawrate = callbackFloat;
}
void DLLForUnity_API InitPlayerNumDelegate(int (*callbackint)())
{
    TacticAPI::player_num = callbackint;
}

void DLLForUnity_API InitMidlineDelegate(float (*callbackfloat)(int CarNum, float k, int index))
{
    TacticAPI::midline = callbackfloat;
}
void DLLForUnity_API InitWidthDelegate(float (*callbackfloat)())
{
    TacticAPI::width = callbackfloat;
}
/*
void(*Debug::Log)(char* message, int iSize);

void DLLForUnity_API InitCSharpDelegate(void(*Log)(char* message, int iSize)) 
{
    Debug::Log = Log;
    //int speedtmp = int(TacticAPI::Speed());
    //std::string num_str(std::to_string(speed));
    //std::array<char, 10> str_tmp;
    UnityLog("Cpp Message:Log has initialized");
    //char acLogStr[20];
    //sprintf_s(acLogStr, sizeof(acLogStr), "%d", speedtmp);
    //Debug::Log(acLogStr, strlen(acLogStr));
}
*/



