/**
  * @file ButtonManager.cs
  * @brief MainMenu场景和Credit场景中按下不同按钮所执行的函数
  * @details  
  * 挂载该脚本的对象：MainMenu → Canvas → ButtonManager，Credit → ButtonManager \n
  * - MainMenu场景中：  
  *  - Start按钮：QuickStart()，沿用用户上次的设置（如果没有则用默认值）快速进行一次仿真；用户上次的设置通过PlayerPrefs类储存
  *  - GameSettings按钮：GameSet()，进入TrackSelect场景
  *  - Credits按钮：Credits()，进入Credit场景
  *  - Quit按钮：quit()，退出游戏
  *  - 主菜单中LoadGame按钮功能未在此文件中实现
  *  .
  * - Credit场景中:
  *  - MainMenu按钮：MainMenu()，回到主菜单。
  *  .
  * .
  * @author 李雨航
  * @date 2022-12-31
  */


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private int trackNum;

    /**
     * @fn GameSet
     * @brief 转到TrackSelect场景
     * @return None
     */
    public void GameSet(){
        LoadButton.LoadNum = 0;
        SceneManager.LoadScene (1);
    }

	public void QuickStart(){
        LoadButton.LoadNum = 0;

        GameSetting.CarType = new int[8];
        GameSetting.ControlMethod = new int[8];

        if (PlayerPrefs.HasKey("NumofPlayer")) GameSetting.NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
        else GameSetting.NumofPlayer = 1;

        for(int i = 0; i < 8; i++)
        {
            //读取历史的车辆颜色设置
            if (PlayerPrefs.HasKey("SavedCarType"+i.ToString()))
                GameSetting.CarType[i] = PlayerPrefs.GetInt("SavedCarType" + i.ToString());
            else GameSetting.CarType[i] = 0;

            //读取历史的车辆控制方法设置
            if (i >= 4)
            {
                GameSetting.ControlMethod[i] = 2;//5~8号车只能代码控制
            }
            else
            {
                if (PlayerPrefs.HasKey("SavedContorlMethod" + i.ToString()))
                    GameSetting.ControlMethod[i] = PlayerPrefs.GetInt("SavedContorlMethod" + i.ToString());
                else GameSetting.ControlMethod[i] = 1;
            }
        }

        //读取历史的赛道选择和模式选择
        if (PlayerPrefs.HasKey("SavedRaceMode")) GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
        else GameSetting.RaceMode = 1;
        if (PlayerPrefs.HasKey("SavedTrackNum")) GameSetting.trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        else GameSetting.trackNum = 3;
        trackNum = GameSetting.trackNum;

        //读取历史的监视器设置
        if (PlayerPrefs.HasKey("NumofMonitor")) MonitorSetting.NumofMonitor = PlayerPrefs.GetInt("NumofMonitor");
        else MonitorSetting.NumofMonitor = 0;
        for(int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.HasKey("Monitor" + i.ToString()+ "Object"))
                MonitorSetting.MonitorObject[i-1] = PlayerPrefs.GetInt("Monitor" + i.ToString() + "Object");
            else MonitorSetting.MonitorObject[i-1] = 0;
            if (PlayerPrefs.HasKey("Monitor" + i.ToString() + "Perspective"))
                MonitorSetting.MonitorPerspective[i-1] = PlayerPrefs.GetInt("Monitor" + i.ToString() + "Perspective");
            else MonitorSetting.MonitorPerspective[i-1] = 0;
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

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}

	public void quit(){
		Application.Quit ();
	}

	public void Credits(){
		SceneManager.LoadScene (4);
	}

}
