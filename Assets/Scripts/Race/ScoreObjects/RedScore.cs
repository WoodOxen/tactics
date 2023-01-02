/**
  * @file RedScore.cs
  * @brief 车辆触碰到红色宝石后加分
  * @details  
  * 挂载该脚本的对象：RaceArea → ScoreObjects → RedScore \n 
  * 在ScoreMode仿真中，赛道上会有红色宝石 \n
  * Update函数功能：宝石会以一定的角速度自转 \n
  * OnTriggerEnter函数功能：当车辆触碰到红色宝石后，给该车辆加分
  * @author 李雨航
  * @date 2022-12-31
  */

using UnityEngine;
using System.Collections;

public class RedScore : MonoBehaviour {

	void Update()
	{
		this.transform.Rotate(0, 1, 0, Space.Self);
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")//触碰该宝石的是否是1号车辆（tag为“Player”,这个是Unity自带的不能改）
        {
            ScoreDisplay.Score[0] += 100;
            gameObject.SetActive(false);
        }
        for (int i = 2; i <= GameSetting.NumofPlayer; i++)//触碰该宝石的是否是2~8号车辆
        {
            if (collision.gameObject.tag == "Player" + i.ToString())
            {
                ScoreDisplay.Score[i - 1] += 100;
                gameObject.SetActive(false);
            }
        }
    }
}
