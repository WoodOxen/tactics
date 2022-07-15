using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private int trackNum;

	public void PlayGame(){
		SceneManager.LoadScene (1);
	}

	public void QuickStart(){
        GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
        GameSetting.CarType = PlayerPrefs.GetInt("SavedCarType");
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
        PlayerPrefs.SetInt("SavedTrackNum", 1);
        //SceneManager.LoadScene (2);
	}
	public void Track02(){
        PlayerPrefs.SetInt("SavedTrackNum", 2);
        //SceneManager.LoadScene (3);
	}
	public void Track03(){
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
