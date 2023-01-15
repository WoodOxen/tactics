/**
  * @file CompletePanelButton.cs
  * @brief 在仿真结束界面中按下不同按钮所执行的函数。
  * @details 
  * 挂载该脚本的对象：RaceArea → Canvas → Panel complete → CompletePanelButtonManager \n
  * @author 李雨航
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletePanelButton : MonoBehaviour
{
    private int trackNum;
    /// 存档窗口 
    public GameObject SavePanel;
    /// 仿真结束窗口 
    public GameObject CompletePanel;

    /**
     * @fn SaveGame
     * @brief 打开存档窗口，同时关闭结算窗口
     * @details 需要记录用户是在结算界面呼出的存档窗口 \n
     * 若用户退出存档界面，则应该再次打开结算窗口
     * @return None
     */
    public void SaveGame()
    {
        SavePanel.SetActive(true);
        CompletePanel.SetActive(false);
        SaveButton.WhoCalloutSavePanel = 1;
    }

    /**
     * @fn MainMenu
     * @brief 返回主菜单
     * @details 释放本次仿真过程中记录车辆运行指令所耗费的内存，参考RecordControllerOutput.cs
     * @return None
     */
    public void MainMenu()
    {
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
     * @fn Retry
     * @brief 重新仿真
     * @details 释放本次仿真过程中记录车辆运行指令所耗费的内存，参考RecordControllerOutput.cs \n
     * 重新载入仿真场景
     * @return None
     */
    public void Retry()
    {
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
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
