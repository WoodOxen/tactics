/**
  * @file DamageDisplay.cs
  * @brief 仿真过程中在窗口左上角显示各车辆的损伤程度。
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UILeft → ……DamageDisplay → DamageDisplayManager
  * @param ExtentOfDamage 各车辆的损伤程度
  * @param CollisionNum 各车辆的碰撞次数。
  * @param CarNum 该脚本要显示几号车辆的损伤值。若脚本是显示一号车辆损伤程度的UI的组件，该值则设为0；若脚本是显示二号车辆损伤程度的UI的组件，该值则设为1……以此类推。
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField] public int CarNum;
    public GameObject damageDisplay;
    static public float[] ExtentOfDamage = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    static public int[] CollisionNum = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    void Update()
    {
        damageDisplay.GetComponent<TextMeshProUGUI>().text = "" + ExtentOfDamage[CarNum].ToString("#0.00");
    }
}
