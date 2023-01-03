/**
  * @file quitRace.cs
  * @brief 在仿真场景下按下Esc时暂停仿真
  * @details 
  * 挂载该脚本的对象：RaceArea → QuitRace
  * @author 李雨航
  * @date 2023-12-31
  */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class quitRace : MonoBehaviour {

    public GameObject pausePanel;
    //public GameObject NormalCam;
    //public GameObject FarCam;
    //public GameObject FPCam;
    //private int CamMode;
    void Update () {
        if (Input.GetButtonDown ("Cancel")) {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
