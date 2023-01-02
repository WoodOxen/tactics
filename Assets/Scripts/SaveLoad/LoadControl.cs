using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class LoadControl : MonoBehaviour
{
    [SerializeField] public int CarNum;
    private CarController m_Car; // the car controller we want to use

    private float steering;
    private float accel;
    private float footbrake;
    private float handbrake;
    private int i;

    public static int count;
    public GameObject RaceFinish;

    private void Awake()
    {
        m_Car = GetComponent<CarController>();
        i = 0;
    }


    private void FixedUpdate()
    {
        if (i < count)
        {
            steering = LoadButton.save.steer[CarNum, i];
            accel = LoadButton.save.accel[CarNum, i];
            footbrake = LoadButton.save.footbrake[CarNum, i];
            handbrake = LoadButton.save.handbrake[CarNum, i];
            m_Car.Move(steering, accel, footbrake, handbrake);
            i = i + 1;
        }
        else
        {
            RaceFinish.SetActive(true);
        }
    }
}
