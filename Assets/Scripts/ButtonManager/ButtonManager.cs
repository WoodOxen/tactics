using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private int trackNum;

	public void GameSet(){
        LoadButton.LoadNum = 0;
        SceneManager.LoadScene (1);
	}

	public void QuickStart(){
        LoadButton.LoadNum = 0;

        GameSetting.CarType = new int[5];
        GameSetting.ControlMethod = new int[5];

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
