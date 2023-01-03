/**
  * @file MiniMap.cs
  * @brief 控制小地图的车辆标识位置和方向
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → UIRight → MiniMap → MarkPlayerCar \n
  * @param CarNum 该脚本控制的是几号车的小地图标志
  * @param CarPosition 记录各个车辆的位置
  * @param MarkX 第CarNum号车辆的小地图标志的X坐标，根据位置关系等比例缩放得到
  * @param MarkY 第CarNum号车辆的小地图标志的Y坐标，根据位置关系等比例缩放得到
  * @author 李雨航
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject TheCar;
    public static Vector3[] CarPosition = new Vector3[4];
    private float MarkX;
    private float MarkY;
    [SerializeField] public int CarNum;
    void Update()
    {
        CarPosition[CarNum] = TheCar.GetComponent<Transform>().position;
        MarkX = -50+(CarPosition[CarNum].z - 1)*100/563;
        MarkY = 50-(CarPosition[CarNum].x - 411)*100/528;
        transform.GetComponent<RectTransform>().localPosition = new Vector3(MarkX, MarkY, 0);
        transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,-90-TheCar.transform.eulerAngles.y);
    }
}
