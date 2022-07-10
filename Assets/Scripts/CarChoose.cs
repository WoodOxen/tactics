using UnityEngine;
using System.Collections;

public class CarChoose : MonoBehaviour {

	public static int CarType;//1=red,2=blue,3=yellow,4=green
	public static int RaceMode;//1=time,2=score
	public GameObject Trackwindow;
	public GameObject Carwindow;
	public GameObject Modewindow;

	// Use this for initialization
	public void RedCar(){
		CarType = 1;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void BlueCar(){
		CarType = 2;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void YellowCar(){
		CarType = 3;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void GreenCar(){
		CarType = 4;
        PlayerPrefs.SetInt("SavedCarType", CarType);
        Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void TimeMode(){
		RaceMode = 1;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
        Trackwindow.SetActive(true);
		Modewindow.SetActive (false);
	}
	public void ScoreMode(){
		RaceMode = 2;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
        Trackwindow.SetActive(true);
		Modewindow.SetActive (false);
	}

	public void ReSet(){
        PlayerPrefs.SetInt("SavedCarType", 0);
        Trackwindow.SetActive(false);
		Modewindow.SetActive (false);
		Carwindow.SetActive (true);
	}
}
