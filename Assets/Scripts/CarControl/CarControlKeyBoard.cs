/**
  * @file CarControlKeyBoard.cs
  * @brief 实现车辆的键盘控制
  * @details  
  * 挂载该脚本的对象：RaceArea → Car \n
  * 该代码是根据Unity自带的代码CarUserControl.cs修改的。
  * @param CarNum表示该脚本控制的是几号车辆。若脚本为一号车辆的组件，则将该值设为0；若脚本为二号车辆的组件，则将该值设为1……以此类推。
  * @param h 各个车辆水平方向的输入(方向盘转角）
  * @param v 各个车辆垂直方向的输入(油门和脚刹）
  * @param handbrake 各个车辆输入的手刹值
  * @author 李雨航
  * @date 2023-01-01
  */


using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarControlKeyBoard : MonoBehaviour
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
        if (CarNum == 0)
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

        RecordControllerOutput.steer[CarNum].Add(h[CarNum]);
        RecordControllerOutput.accel[CarNum].Add(v[CarNum]);
        RecordControllerOutput.footbrake[CarNum].Add(v[CarNum]);
        RecordControllerOutput.handbrake[CarNum].Add(handbrake[CarNum]);

        m_Car.Move(h[CarNum], v[CarNum], v[CarNum], handbrake[CarNum]);
#else
            m_Car.Move(h, v, v, 0f);
#endif
    }
}
