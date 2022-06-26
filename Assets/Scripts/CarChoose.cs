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
		Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void BlueCar(){
		CarType = 2;
		Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void YellowCar(){
		CarType = 3;
		Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void GreenCar(){
		CarType = 4;
		Modewindow.SetActive(true);
		Carwindow.SetActive (false);
	}

	public void TimeMode(){
		RaceMode = 1;
		Trackwindow.SetActive(true);
		Modewindow.SetActive (false);
	}
	public void ScoreMode(){
		RaceMode = 2;
		Trackwindow.SetActive(true);
		Modewindow.SetActive (false);
	}

	public void ReSet(){
		Trackwindow.SetActive(false);
		Modewindow.SetActive (false);
		Carwindow.SetActive (true);
	}
}
