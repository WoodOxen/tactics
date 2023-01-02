/**
  * @file GamePauseButton.cs
  * @brief 仿真暂停界面中按下不同按钮所执行的函数。
  * @details 
  * 挂载该脚本的对象：RaceArea → Canvas → Panel Pause → PauseButtonManager \n
  * - Continue按钮：ContinueRace()，继续仿真。
  * - Save and Load按钮：SaveGame()，打开存档读档窗口。
  * - Retry按钮：Retry()，重新开始。
  * - MainMenu按钮：BacktoMainMenu()，回到主菜单界面。
  * .
  * @author 李雨航
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseButton : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject SavePanel;
    private int CamMode;
    private int trackNum;

    /**
     * @fn BacktoMainMenu
     * @brief 返回主菜单
     * @details 释放本次仿真过程中记录车辆运行指令所耗费的内存，参考RecordControllerOutput.cs
     * @return None
     */
    public void BacktoMainMenu()
    {
        Time.timeScale = 1;
        //释放内存
        for (int i = 0; i < 4; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
        SceneManager.LoadScene(0);
    }
    /**
     * @fn ContinueRace
     * @brief 继续仿真
     * @return None
     */
    public void ContinueRace()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    /**
     * @fn SaveGame
     * @brief 打开存档窗口，同时关闭暂停窗口
     * @details 需要记录用户是在暂停界面呼出的存档窗口 \n
     * 若用户退出存档界面，则应该再次打开暂停窗口
     * @return None
     */
    public void SaveGame()
    {
        SavePanel.SetActive(true);
        pausePanel.SetActive(false);
        SaveButton.WhoCalloutSavePanel = 2;
    }
    /**
     * @fn Retry
     * @brief 重新仿真
     * @details 释放本次仿真过程中记录车辆运行指令所耗费的内存，参考RecordControllerOutput.cs \n
     * 重新载入仿真场景
     * @return None
     */
    public void Retry()
    {
        Time.timeScale = 1;
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        //释放内存
        for (int i = 0; i < 4; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
            SceneManager.LoadScene(5);
    }
}
