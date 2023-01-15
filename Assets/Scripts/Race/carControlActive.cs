/**
  * @file carControlActive.cs
  * @brief 根据用户的选择，开启每辆车的控制代码
  * @details
  * 如果本次运行为读档，则需要复现存档中的仿真结果，需要开启所有Car的LoadControl组件；\n
  * 如果本次运行不是读档，则需要判断：\n
  * 如果某辆车的ControlMethod为1，则为键盘控制，需要开启对应Car的CarUserControl组件；\n
  * 如果某辆车的ControlMethod为2，则需要Cpp代码控制，将CallCppControl对象setActive，以此来调用Cpp代码。
  * @author 李雨航
  * @date 2022-01-06
  */


using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class carControlActive : MonoBehaviour {
    /// 各车辆
    public GameObject[] Car;
    /// 实现Cpp控制功能的GameObject
    public GameObject CallCppControl;

    private int PlayerNum;
    /**
     * @fn CariControlActive
     * @brief 设置第i辆车的控制方法(KeyBoard or CppSripts)
     * @param[in] Num 车辆编号
     */
    void CariControlActive(int i)
    {
        if (GameSetting.ControlMethod[i] == 2)
            CallCppControl.SetActive(true);
        else
            Car[i].GetComponent<CarControlKeyBoard>().enabled = true;
    }

    void Start()
    {
        PlayerNum = GameSetting.NumofPlayer;

        if(LoadButton.LoadNum != 0)//此次运行为读档复现
        {
            for(int i = 0; i < PlayerNum; i++)
            {
                Car[i].GetComponent<LoadControl>().enabled = true;
            }
        }
        else//此次运行为正常运行
        {
            for(int i = 0; i < PlayerNum && i < 4; i++)
            {
                CariControlActive(i);
            }
            if (PlayerNum > 4)//5~8号车只能用代码控制
                CallCppControl.SetActive(true);
        }
    }
}
