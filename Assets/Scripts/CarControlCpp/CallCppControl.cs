using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CallCppControl : MonoBehaviour
{
    public static int a = 0;
    public GameObject[] TheCar;
    public static float[] steering = new float[5] { 0, 0, 0, 0 ,0};
    public static float[] accel = new float[5] { 0, 0, 0, 0 ,0};
    public static float[] footbrake = new float[5] { 0, 0, 0, 0,0 };
    public static float[] handbrake = new float[5] { 0, 0, 0, 0,0 };
    private int playNum;
    private CarController[] m_Car = new CarController[4];
    private int[] ControlMethod = new int[4] { 0, 0, 0, 0 };



    void Start()
    {
        a = 0;
        steering = new float[5] { 0, 0, 0, 0, 0 };
        accel = new float[5] { 0, 0, 0, 0, 0 };
        footbrake = new float[5] { 0, 0, 0, 0, 0 };
        handbrake = new float[5] { 0, 0, 0, 0, 0 };
        CppControl.InitializeCppControl();
        playNum = GameSetting.NumofPlayer;
        for(int i = 0;i < playNum;i++)
        {
            m_Car[i] = TheCar[i].GetComponent<CarController>();
            ControlMethod[i] = GameSetting.ControlMethod[i];
            //steering[i] = 0;
            //accel[i] = 0;
            //footbrake[i] = 0;
            //handbrake[i] = 0;
        }
        
    }

    void FixedUpdate()
    {
        a++;
        
        CppControl.CarControlCpp();
        for (int i = 0; i < playNum; i++)
        {
            if (ControlMethod[i] == 2)
            {
                m_Car[i].Move(steering[i], accel[i], footbrake[i], handbrake[i]);
                Debug.Log(string.Format("CarMove {0} {1}: {2} {3}", a,i,steering[i], accel[i]));
            } 
        }
        //StartCoroutine(AfterFixedUpdate());
    }

    IEnumerator AfterFixedUpdate()
    {
        yield return new WaitForFixedUpdate();
        //yield return new WaitForSeconds(0.01f);
        CppControl.CarControlCpp();
        
    }


}
