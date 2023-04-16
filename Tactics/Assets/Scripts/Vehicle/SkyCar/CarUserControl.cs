using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
//using UnityStandardAssets.Vehicles.Car;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        [SerializeField] public int CarNum;
        private CarController m_Car; // the car controller we want to use
        public static float[] h = new float[4] { 0, 0, 0, 0 };
        public static float[] v = new float[4] { 0, 0, 0, 0 };
        public static float[] handbrake = new float[4] { 0, 0, 0, 0 };
        private string CarNum_Char;
        private string Horizontal;
        private string Vertical;
        private string Jump;

        private void Awake()
        {
            m_Car = GetComponent<CarController>();
            CarNum_Char = CarNum.ToString();
            if(CarNum == 0)
            {
                Horizontal = "Horizontal";
                Vertical = "Vertical";
                Jump = "Jump";
            }
            else
            {
                Horizontal = "Horizontal" + CarNum_Char;
                Vertical = "Vertical" + CarNum_Char;
                Jump = "Jump" + CarNum_Char;
            }
    }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");

            h[CarNum] = CrossPlatformInputManager.GetAxis(Horizontal);
            v[CarNum] = CrossPlatformInputManager.GetAxis(Vertical);
#if !MOBILE_INPUT
            handbrake[CarNum] = CrossPlatformInputManager.GetAxis(Jump);
            m_Car.Move(h[CarNum], v[CarNum], v[CarNum], handbrake[CarNum]);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
