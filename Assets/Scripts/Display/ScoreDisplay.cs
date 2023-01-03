/**
  * @file ScoreDisplay.cs
  * @brief ScoreMode仿真过程中，储存各个车辆的得分并在在窗口左上角显示各车辆的得分
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UILeft → ScoreModeDisplay → ScoreModeDisplay \n
  * @param CarNum 表示该脚本需要显示几号车辆的得分。若脚本是显示一号车辆得分的UI的组件，该值则设为0；若脚本是显示二号车辆得分的UI的组件，该值则设为1……以此类推。
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static int[] Score = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public GameObject CurrentScoreDisplay;
    [SerializeField] public int CarNum;

    void Update()
    {
        CurrentScoreDisplay.GetComponent<TextMeshProUGUI>().text = "" + Score[CarNum];
    }
}
