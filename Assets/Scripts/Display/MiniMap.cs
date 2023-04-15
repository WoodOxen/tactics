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
    public GameObject MiniMapImage;
    public GameObject RaceAreaTerrain;
    /// 第CarNum号车辆
    public GameObject[] TheCars;
    public GameObject[] TheMarks;
    /// 各个车辆的位置
    private float MarkX;
    private float MarkY;
    private float length_minimap;
    private float width_minimap;
    private float length_terrain;
    private float width_terrain;
    private int car_num;

    void Start()
    {
        car_num = GameSetting.NumofPlayer;
        if (car_num > 4) car_num = 4;
        length_minimap = MiniMapImage.GetComponent<RectTransform>().rect.height;
        width_minimap = MiniMapImage.GetComponent<RectTransform>().rect.width;
        length_terrain = RaceAreaTerrain.GetComponent<Terrain>().terrainData.size.z;
        width_terrain = RaceAreaTerrain.GetComponent<Terrain>().terrainData.size.x;
    }

    void Update()
    {
        for(int i = 0;i < car_num; i++)
        {
            PosMarki(i);
        }
    }

    void PosMarki(int i)
    {
        Vector3 CarPosition = TheCars[i].GetComponent<Transform>().position;
        MarkY = -length_minimap/2 + (CarPosition.z) * length_minimap / length_terrain;
        MarkX = -width_minimap/2 + (CarPosition.x) * width_minimap / width_terrain;
        TheMarks[i].transform.GetComponent<RectTransform>().localPosition = new Vector3(MarkX, MarkY, 0);
        TheMarks[i].transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -TheCars[i].transform.eulerAngles.y);

    }
}
