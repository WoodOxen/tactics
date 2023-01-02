/**
  * @file quitGame.cs
  * @brief 在主菜单界面按下Esc时关闭仿真器
  * @details 
  * 挂载该脚本的对象：MainMenu → QuitGame
  * @author 李雨航
  * @date 2023-12-31
  */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class quitGame : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			Application.Quit ();
		}
	}
}
