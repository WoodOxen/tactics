/**
  * @file CameraStable.cs
  * @brief 稳定相机
  * @details  
  * 挂载该脚本的对象：RaceArea → Car → Cube \n
  * 相机为Cube的子对象，在Cube上附加该代码后， Cube在X方向和Z方向不偏转，相机的拍摄角度也因此稳定
  * @author 李雨航
  * @date 2022-12-31
  */

using UnityEngine;
using System.Collections;

public class CameraStable : MonoBehaviour {

	public GameObject TheCar;


	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (0, TheCar.transform.eulerAngles.y, 0);

	}
}
