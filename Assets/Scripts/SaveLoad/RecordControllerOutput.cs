/**
  * @file RecordControllerOutput.cs
  * @brief 使用动态数组ArrayList储存对各个小车输出的控制参数
  * @details  
  * 挂载该脚本的对象：RaceArea → RecordOutputofController\n
  * @author 李雨航
  * @date 2022-01-06
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordControllerOutput : MonoBehaviour
{
    public static ArrayList[] steer = new ArrayList[8];
    public static ArrayList[] accel = new ArrayList[8];
    public static ArrayList[] footbrake = new ArrayList[8];
    public static ArrayList[] handbrake = new ArrayList[8];

    void Start()
    {
        for(int i =0;i < GameSetting.NumofPlayer; i++)
        {
            steer[i] = new ArrayList(10000);
            accel[i] = new ArrayList(10000);
            footbrake[i] = new ArrayList(10000);
            handbrake[i] = new ArrayList(10000);
        }
    }
}
