/**
  * @file HalfPointTrigger.cs
  * @brief 记录车辆是否已经行驶了半圈
  * @details
  * 挂载该脚本的对象：RaceArea → HalfPointTrigger\n
  * 该脚本和LapComplete.cs配合使用。\n
  * 若车辆没有经过半途的检查点，即使车辆经过终点线也不会被判断为行驶了一圈。\n
  * 每辆车对应一个叫HalfFlag的bool型变量，如果该车通过了半途的检查点则该变量值为true，否则为false。
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;

public class HalfPointTrigger : MonoBehaviour {
    /// 终点\起点触发器
    public GameObject LapCompleteTrig;
    /// 半途检查点触发器
    public GameObject HalfLapTrig;
    /// 各车辆通过半途检查点的情况
    public static bool[] HalfFlag = new bool[8] { false , false, false, false, false, false, false, false };

    void Start()
    {
        HalfFlag = new bool[8] { false, false, false, false, false, false, false, false };
    }

    void OnTriggerEnter(Collider collision)
    {
        //排除AI车和其他空气墙碰撞的情况
        if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge"){
            return;
        }
        //记录四辆人工操控车通过半途检查点的情况
        if (collision.gameObject.tag == "Player" && LapComplete.LapFlag[0])
        {
            //Debug.Log(1);
            HalfFlag[0] = true;
            LapComplete.LapFlag[0] = false;
        }
        for(int i = 1;i < GameSetting.NumofPlayer; i++)
        {
            if (collision.gameObject.tag == "Player"+(i+1).ToString() && LapComplete.LapFlag[i])
            {
                //Debug.Log(i+1);
                HalfFlag[i] = true;
                LapComplete.LapFlag[i] = false;
            }
        }

        //LapCompleteTrig.SetActive (true);
        //HalfLapTrig.SetActive (false);
    }
}
