using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class CppCarControl : MonoBehaviour
{
    [SerializeField] public int CarNum;
    public GameObject TheCar;
    public static float[] steering = new float[4] { 0, 0, 0, 0 };
    public static float[] accel = new float[4] { 0, 0, 0, 0 };
    public static float[] footbrake = new float[4] { 0, 0, 0, 0 };
    public static float[] handbrake = new float[4] { 0, 0, 0, 0 };
    private CarController m_Car;

    void Start()
    {
        m_Car = TheCar.GetComponent<CarController>();
    }

    void Update()
    {
        //CppControl.CarControlCpp();
        //CarUserControl.h = steering[CarNum];
        //CarUserControl2.h = steering[CarNum];
        //CarUserControl3.h = steering[CarNum];
        //CarUserControl4.h = steering[CarNum];
        m_Car.Move(steering[CarNum], accel[CarNum], footbrake[CarNum], handbrake[CarNum]);

        //CppControl.InitCSharpDelegate(CppControl.LogMessageFromCpp);
    }

}

/*
namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CppCarControl : MonoBehaviour
    {
        [SerializeField] public int CarNum;
        private CarController m_Car; // the car controller we want to use
        public static float[] steering = new float[4] { 0, 0, 0, 0 };
        public static float[] accel = new float[4] { 0, 0, 0, 0 };
        public static float[] footbrake = new float[4] { 0, 0, 0, 0 };
        public static float[] handbrake = new float[4] { 0, 0, 0, 0 };
        //public static int CarNum_Control;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            CppControl.CarControlCpp();
            //CarUserControl.h = steering[CarNum];
            //CarUserControl2.h = steering[CarNum];
            //CarUserControl3.h = steering[CarNum];
            //CarUserControl4.h = steering[CarNum];
            m_Car.Move(steering[CarNum], accel[CarNum], footbrake[CarNum], handbrake[CarNum]);

            //CppControl.InitCSharpDelegate(CppControl.LogMessageFromCpp);
        }
    }
}*/
