/**
  * @file LapNumDisplay.cs
  * @brief 巡线时在窗口右上角显示当前视角对应车辆的已行驶圈数
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UIRight → PanelRight → LapNumDisplayManager \n
  * @param CarNum 当前观察的车辆编号
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapNumDisplay : MonoBehaviour
{
    public GameObject LapCountDisplay;
    private int CarNum;
    void Start()
    {
        CarNum = ViewModeManager.CamNum;
    }

    void Update()
    {
        CarNum = ViewModeManager.CamNum;
        LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount[CarNum];
    }
}
