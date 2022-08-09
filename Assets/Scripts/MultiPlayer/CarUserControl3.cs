using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl3 : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public static float h;
        public static float v;
        public static float handbrake;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            h = CrossPlatformInputManager.GetAxis("Horizontal3");
            v = CrossPlatformInputManager.GetAxis("Vertical3");
#if !MOBILE_INPUT
            handbrake = CrossPlatformInputManager.GetAxis("R");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
