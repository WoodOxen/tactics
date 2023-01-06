/**
  * @file LapComplete.cs
  * @brief 检测车辆是否通过起点
  * @details
  * 挂载该脚本的对象：RaceArea → LapCompleteTrigger\n
  * 该脚本与HalfPointTrigger.cs配合使用。\n
  * 判断车辆是否行驶完了一圈。\n
  * 车辆通过终点检查点时，若检测到之前已经通过了半途检查点（HalfFlag为true），\n
  * 则判断该车行驶完了一圈，圈数＋1，并设置对应的HalfFlag和LapFlag，开始下一圈的计数。\n
  * 若车辆行驶的圈数达到目标圈数，巡线结束，将RaceFinish对象SetActive。
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LapComplete : MonoBehaviour {
    /// 起点\终点触发器
    public GameObject LapCompleteTrig;
    /// 半途检查点触发器
    public GameObject HalfLapTrig;
    /// 实现巡线结束功能的GameObject
    public GameObject RaceFinish;
    private int ModeSelection;

    //public int modeType;
    //public int flag_firstlyEnter;

    /// 各车辆的圈数
    public static int[] LapCount = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 各车辆通过起点线的情况
    public static bool[] LapFlag = new bool[8] { true, true, true, true, true, true, true, true };

    void Start () {
        //flag_firstlyEnter = 1;
        //modeType = GameSetting.RaceMode;
        ModeSelection = GameSetting.RaceMode;
        for(int i = 0; i < 4; i++)
        {
            LapCount[i] = 0;
            LapFlag[i] = true;
        }
}
        
    void OnTriggerEnter(Collider collision){
        /*if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge") {
            return;
        }*/
        //记录1号车通过终点线的情况
        if (collision.gameObject.tag == "Player" && HalfPointTrigger.HalfFlag[0])
        {
            //Debug.Log(1);
            LapFlag[0] = true;
            HalfPointTrigger.HalfFlag[0] = false;
            LapCount[0] += 1;
        }
        //记录2~8号车通过终点线的情况
        for (int i = 1; i < GameSetting.NumofPlayer; i++)
        {
            if (collision.gameObject.tag == "Player"+(i+1).ToString() && HalfPointTrigger.HalfFlag[i])
            {
                //Debug.Log(i+1);
                LapFlag[i] = true;
                HalfPointTrigger.HalfFlag[i] = false;
                LapCount[i] += 1;
            }
        }

        //巡线结束条件
        if (((ModeSelection == 2) && (LapCount[0] == 1))|| LapCount[0] == 1) {
            RaceFinish.SetActive (true);
        }

    }
}
