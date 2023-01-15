/**
  * @file CarColorSetting.cs
  * @brief 根据用户的选择，修改车辆的颜色
  * @details 挂载该脚本的对象：RaceArea → CarColor
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;

public class CarColorSetting : MonoBehaviour {
    /// 各车身颜色的材质
    public Material[] material;
    /// 各车辆的车身
    public GameObject[] CarBody;

    Renderer rend;
    int CarImport;
    int PlayerNum;

    void Start () {
        PlayerNum = GameSetting.NumofPlayer;

        for(int i = 0; i < PlayerNum; i++)
        {
            SetCarColor(i);
        }
    }
    /**
     * @fn SetCarColor
     * @brief 设置车辆颜色
     * @param[in] Num 车辆编号
     */
    void SetCarColor(int Num)
    {
        CarImport = GameSetting.CarType[Num];
        rend = CarBody[Num].GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[CarImport];
    }
}
