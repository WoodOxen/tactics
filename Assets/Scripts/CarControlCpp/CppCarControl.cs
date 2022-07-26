using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CppCarControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public static float steering;
        public static float accel;
        public static float footbrake;
        public static float handbrake;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            steering = 0f;
            accel = 0f;
            footbrake = 0f;
            handbrake = 0f;
            CppControl.CarControlCpp();
            CarUserControl.h = steering;
            m_Car.Move(steering, accel, footbrake, handbrake);

            //CppControl.InitCSharpDelegate(CppControl.LogMessageFromCpp);
        }
    }
}
