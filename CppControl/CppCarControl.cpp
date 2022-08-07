#include "pch.h"
#include "CppCarControl.h"
#include <stdio.h>
#include <iostream>
#include <string.h>
#include <queue>

double CruiseError;
double Addup_CruiseError = 0;
double Last_CruiseError = 0;

float steering;
float accel;
float footbrake;
float handbrake;

std::queue<float> q;


//Tactic每一帧会调用一次CarControlCpp()函数，修改此处的代码控制小车移动
//接口定义见CppCarControl.h文件
DLLForUnity_API void __stdcall CarControlCpp()
{
    //speed control
    double DreamSpeed;
    
    if (TacticAPI::Curvature() == 0) DreamSpeed = 25;
    else DreamSpeed = 3.5 / TacticAPI::Curvature();

    if (DreamSpeed > 25) DreamSpeed = 25;
    if (DreamSpeed <10) DreamSpeed = 10;

    accel = 0.1 * (DreamSpeed - double(TacticAPI::Speed()));
    footbrake = 0.1 * (DreamSpeed - double(TacticAPI::Speed()));

    //steering control
    CruiseError = TacticAPI::CruiseError();
    q.push(CruiseError);
    Addup_CruiseError += CruiseError * 0.01;
    if (q.size() == 10) {
        double tmp = q.front();
        q.pop();
        Addup_CruiseError -= tmp * 0.01;
    }
    steering = CruiseError * 0.06 + Addup_CruiseError*0.0015 + (CruiseError - Last_CruiseError)*2;
    
    handbrake = 0;

    Last_CruiseError = CruiseError;

    TacticAPI::CarMove(steering, accel, footbrake, handbrake);
}


//下为接口定义相关代码，无需阅读
void(*TacticAPI::CarMove)(float steering, float accel, float footbrake, float handbrake);

float(*TacticAPI::Speed)();
float(*TacticAPI::PositionX)();
float(*TacticAPI::PositionY)();
float(*TacticAPI::PositionZ)();
double(*TacticAPI::CruiseError)();
double(*TacticAPI::Curvature)();
float(*TacticAPI::AngleError)();

void DLLForUnity_API InitCarMoveDelegate(void (*GetCarMove)(float steering, float accel, float footbrake, float handbrake))
{
    TacticAPI::CarMove = GetCarMove;
}

void DLLForUnity_API InitSpeedDelegate(float (*callbackFloat)())
{
    TacticAPI::Speed = callbackFloat;
}
void DLLForUnity_API InitPositionXDelegate(float (*callbackFloat)())
{
    TacticAPI::PositionX = callbackFloat;
}
void DLLForUnity_API InitPositionYDelegate(float (*callbackFloat)())
{
    TacticAPI::PositionY = callbackFloat;
}
void DLLForUnity_API InitPositionZDelegate(float (*callbackFloat)())
{
    TacticAPI::PositionZ = callbackFloat;
}
void DLLForUnity_API InitCruiseErrorDelegate(double (*callbackdouble)())
{
    TacticAPI::CruiseError = callbackdouble;
}
void DLLForUnity_API InitCurvatureDelegate(double (*callbackdouble)())
{
    TacticAPI::Curvature = callbackdouble;
}
void DLLForUnity_API InitAngleErrorDelegate(float (*callbackFloat)())
{
    TacticAPI::AngleError = callbackFloat;
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



