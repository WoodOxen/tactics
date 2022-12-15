using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CallCppControl : MonoBehaviour
{
    public GameObject[] TheCar;
    public static float[] steering = new float[8] { 0, 0, 0, 0 ,0, 0, 0, 0 };
    public static float[] accel = new float[8] { 0, 0, 0, 0 ,0, 0, 0, 0 };
    public static float[] footbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] handbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

    private int playNum;
    private CarController[] m_Car = new CarController[8];
    private int[] ControlMethod = new int[8] { 0, 0, 0, 0, 2, 2, 2, 2 };



    void Start()
    {
        steering = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        accel = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        footbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        handbrake = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        CppControl.InitializeCppControl();
        ///*
        playNum = GameSetting.NumofPlayer;
        for(int i = 0;i < playNum;i++)
        {
            m_Car[i] = TheCar[i].GetComponent<CarController>();
            ControlMethod[i] = GameSetting.ControlMethod[i];
        }//*/
    }

    void FixedUpdate()
    {
        CppControl.CarControlCpp();
        ///*
        for (int i = 0; i < playNum; i++)
        {
            if (ControlMethod[i] == 2)
            {
                m_Car[i].Move(steering[i], accel[i], footbrake[i], handbrake[i]);
                RecordControllerOutput.steer[i].Add(steering[i]);
                RecordControllerOutput.accel[i].Add(accel[i]);
                RecordControllerOutput.footbrake[i].Add(footbrake[i]);
                RecordControllerOutput.handbrake[i].Add(handbrake[i]);
            }
        }
        //*/
    }
}
