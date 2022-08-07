using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private int trackNum;

	public void PlayGame(){
        LoadButton.LoadNum = 0;
        SceneManager.LoadScene (1);
	}

	public void QuickStart(){
        LoadButton.LoadNum = 0;
        GameSetting.NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
        GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
        GameSetting.CarType = new int[5];
        GameSetting.CarType[0] = PlayerPrefs.GetInt("SavedCarType0");
        GameSetting.CarType[1] = PlayerPrefs.GetInt("SavedCarType1");
        GameSetting.CarType[2] = PlayerPrefs.GetInt("SavedCarType2");
        GameSetting.CarType[3] = PlayerPrefs.GetInt("SavedCarType3");
        GameSetting.ControlMethod[0] = PlayerPrefs.GetInt("SavedContorlMethod0");
        GameSetting.ControlMethod[1] = PlayerPrefs.GetInt("SavedContorlMethod1");
        GameSetting.ControlMethod[2] = PlayerPrefs.GetInt("SavedContorlMethod2");
        GameSetting.ControlMethod[3] = PlayerPrefs.GetInt("SavedContorlMethod3");
        GameSetting.NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
            SceneManager.LoadScene(5);

    }

    public void Retry()
    {
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
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


	//buttons in track selection
	public void Track01(){
        GameSetting.trackNum = 1;
        PlayerPrefs.SetInt("SavedTrackNum", 1);
        //SceneManager.LoadScene (2);
	}
	public void Track02(){
        GameSetting.trackNum = 2;
        PlayerPrefs.SetInt("SavedTrackNum", 2);
        //SceneManager.LoadScene (3);
	}
	public void Track03(){
        GameSetting.trackNum = 3;
        PlayerPrefs.SetInt("SavedTrackNum", 3);
        //SceneManager.LoadScene(5);
	}
    /*
	public void NeverTouch(){
		CashDisplay.TotalCash += 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);
	}
	public void ResetBuy(){
		PlayerPrefs.SetInt ("GreenBought", 0);
		PlayerPrefs.SetInt ("YellowBought", 0);
		PlayerPrefs.SetInt ("Track02Bought", 0);
	}
    */
}
