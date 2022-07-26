using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSetting : MonoBehaviour {

	public static int CarType;//1=red,2=blue,3=yellow,4=green
	public static int RaceMode;//1=time,2=score
	public GameObject Trackwindow;
	public GameObject Carwindow;
	public GameObject Modewindow;
    public static int trackNum;
    public static int ControlMethod;
    

    // Use this for initialization
    public void RedCar(){
		CarType = 1;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        //Modewindow.SetActive(true);
		//Carwindow.SetActive (false);
	}

	public void BlueCar(){
		CarType = 2;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        //Modewindow.SetActive(true);
		//Carwindow.SetActive (false);
	}

	public void YellowCar(){
		CarType = 3;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        //Modewindow.SetActive(true);
		//Carwindow.SetActive (false);
	}

	public void GreenCar(){
		CarType = 4;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        //Modewindow.SetActive(true);
		//Carwindow.SetActive (false);
	}

	public void TimeMode(){
		RaceMode = 1;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
        //Trackwindow.SetActive(true);
		//Modewindow.SetActive (false);
	}
	public void ScoreMode(){
		RaceMode = 2;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
        //Trackwindow.SetActive(true);
		//Modewindow.SetActive (false);
	}

    public void High()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    public void Low()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    public void Keyboard()
    {
        ControlMethod = 1;
        PlayerPrefs.SetInt("SavedContorlMethod", ControlMethod);
    }

    public void Script()
    {
        ControlMethod = 2;
        PlayerPrefs.SetInt("SavedContorlMethod", ControlMethod);
    }

    public void Play(){
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
            SceneManager.LoadScene(5);
        //Trackwindow.SetActive(false);
        //Modewindow.SetActive (false);
        //Carwindow.SetActive (true);
    }
}
