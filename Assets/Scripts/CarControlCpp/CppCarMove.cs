using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CppCarMove : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public static float s;
        public static float a;
        public static float f;
        public static float h;
        [SerializeField] public int CarNum;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            s = CallCppControl.steering[CarNum];
            a = CallCppControl.accel[CarNum];
            f = CallCppControl.footbrake[CarNum];
#if !MOBILE_INPUT
            h = CallCppControl.handbrake[CarNum];
            m_Car.Move(s,a,f,h);
#else
            m_Car.Move(s,a,f,h);
#endif
        }
    }
}
