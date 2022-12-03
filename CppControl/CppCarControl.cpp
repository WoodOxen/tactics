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

//Tactic在Race开始时会调用InitializeCppControl()函数，可以自此处做一些Cpp代码的初始化工作
DLLForUnity_API void __stdcall InitializeCppControl() {
    PlayerNum = TacticAPI::PlayerNum();
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
    for (int i = 0; i < 8; i++) {
        CarControli(i);
    }
}

void CarControli(int i) {
    int CarNum = i;

    //speed control
    float DreamSpeed;

    if (TacticAPI::Curvature(CarNum) == 0) DreamSpeed = 25;
    else DreamSpeed = 3.5 / TacticAPI::Curvature(CarNum);
    if (DreamSpeed > 25) DreamSpeed = 25;
    if (DreamSpeed < 10) DreamSpeed = 10;
    accel[CarNum] = 0.1 * (DreamSpeed - TacticAPI::Speed(CarNum));
    footbrake[CarNum] = 0.1 * (DreamSpeed - TacticAPI::Speed(CarNum));

    //steering control
    CruiseError[CarNum] = TacticAPI::CruiseError(CarNum);
    Addup_CruiseError[CarNum] += CruiseError[CarNum] * 0.01;
    if (Addup_CruiseError[CarNum] > 200) Addup_CruiseError[CarNum] = 200;
    else if(Addup_CruiseError[CarNum] < -200) Addup_CruiseError[CarNum] = -200;

    steering[CarNum] = CruiseError[CarNum] * 0.06 + Addup_CruiseError[CarNum] * 0.0015 + (CruiseError[CarNum] - Last_CruiseError[CarNum]) * 3;
    handbrake[CarNum] = 0;

    Last_CruiseError[CarNum] = CruiseError[CarNum];

    TacticAPI::CarMove(steering[CarNum], accel[CarNum], footbrake[CarNum], handbrake[CarNum], CarNum);
    //TacticAPI::CarMove(0,1,0,0, CarNum);
}




//下为接口定义相关代码，无需阅读
void(*TacticAPI::CarMove)(float steering, float accel, float footbrake, float handbrake,int CarNum);

float(*TacticAPI::Speed)(int CarNum);
//float(*TacticAPI::PositionX)(int CarNum);
//float(*TacticAPI::PositionY)(int CarNum);
//float(*TacticAPI::PositionZ)(int CarNum);
float(*TacticAPI::CruiseError)(int CarNum);
float(*TacticAPI::Curvature)(int CarNum);
float(*TacticAPI::AngleError)(int CarNum);
int(*TacticAPI::PlayerNum)();

void DLLForUnity_API InitCarMoveDelegate(void (*GetCarMove)(float steering, float accel, float footbrake, float handbrake,int CarNum))
{
    TacticAPI::CarMove = GetCarMove;
}

void DLLForUnity_API InitSpeedDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::Speed = callbackFloat;
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
    TacticAPI::CruiseError = callbackFloat;
}
void DLLForUnity_API InitCurvatureDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::Curvature = callbackFloat;
}
void DLLForUnity_API InitAngleErrorDelegate(float (*callbackFloat)(int CarNum))
{
    TacticAPI::AngleError = callbackFloat;
}

void DLLForUnity_API InitPlayerNumDelegate(int (*callbackint)())
{
    TacticAPI::PlayerNum = callbackint;
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



