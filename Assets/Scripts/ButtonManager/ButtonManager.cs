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

        if (PlayerPrefs.HasKey("SavedCarType0")) GameSetting.CarType[0] = PlayerPrefs.GetInt("SavedCarType0");
        else GameSetting.CarType[0] = 0;
        if (PlayerPrefs.HasKey("SavedCarType1")) GameSetting.CarType[1] = PlayerPrefs.GetInt("SavedCarType1");
        else GameSetting.CarType[1] = 0;
        if (PlayerPrefs.HasKey("SavedCarType2")) GameSetting.CarType[2] = PlayerPrefs.GetInt("SavedCarType2");
        else GameSetting.CarType[2] = 0;
        if (PlayerPrefs.HasKey("SavedCarType3")) GameSetting.CarType[3] = PlayerPrefs.GetInt("SavedCarType3");
        else GameSetting.CarType[3] = 0;

        if (PlayerPrefs.HasKey("SavedContorlMethod0")) GameSetting.ControlMethod[0] = PlayerPrefs.GetInt("SavedContorlMethod0");
        else GameSetting.ControlMethod[0] = 1;
        if (PlayerPrefs.HasKey("SavedContorlMethod1")) GameSetting.ControlMethod[1] = PlayerPrefs.GetInt("SavedContorlMethod1");
        else GameSetting.ControlMethod[1] = 1;
        if (PlayerPrefs.HasKey("SavedContorlMethod2")) GameSetting.ControlMethod[2] = PlayerPrefs.GetInt("SavedContorlMethod2");
        else GameSetting.ControlMethod[2] = 1;
        if (PlayerPrefs.HasKey("SavedContorlMethod3")) GameSetting.ControlMethod[3] = PlayerPrefs.GetInt("SavedContorlMethod3");
        else GameSetting.ControlMethod[3] = 1;

        if (PlayerPrefs.HasKey("SavedRaceMode")) GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
        else GameSetting.RaceMode = 1;
        if (PlayerPrefs.HasKey("SavedTrackNum")) GameSetting.trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        else GameSetting.trackNum = 3;
        trackNum = GameSetting.trackNum;

        if (PlayerPrefs.HasKey("NumofMonitor")) MonitorSetting.NumofMonitor = PlayerPrefs.GetInt("NumofMonitor");
        else MonitorSetting.NumofMonitor = 0;
        if (PlayerPrefs.HasKey("Monitor1Object")) MonitorSetting.Monitor1Object = PlayerPrefs.GetInt("Monitor1Object");
        else MonitorSetting.Monitor1Object = 0;
        if (PlayerPrefs.HasKey("Monitor2Object")) MonitorSetting.Monitor2Object = PlayerPrefs.GetInt("Monitor2Object");
        else MonitorSetting.Monitor2Object = 0;
        if (PlayerPrefs.HasKey("Monitor3Object")) MonitorSetting.Monitor3Object = PlayerPrefs.GetInt("Monitor3Object");
        else MonitorSetting.Monitor3Object = 0;
        if (PlayerPrefs.HasKey("Monitor1Perspective")) MonitorSetting.Monitor1Perspective = PlayerPrefs.GetInt("Monitor1Perspective");
        else MonitorSetting.Monitor1Perspective = 0;
        if (PlayerPrefs.HasKey("Monitor2Perspective")) MonitorSetting.Monitor2Perspective = PlayerPrefs.GetInt("Monitor2Perspective");
        else MonitorSetting.Monitor2Perspective = 0;
        if (PlayerPrefs.HasKey("Monitor3Perspective")) MonitorSetting.Monitor3Perspective = PlayerPrefs.GetInt("Monitor3Perspective");
        else MonitorSetting.Monitor3Perspective = 0;

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
