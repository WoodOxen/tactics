using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class RaceFinish : MonoBehaviour {

	public GameObject PlayerCar;
	public GameObject CompleteTrig;
	public AudioSource FinishBGM;
	public GameObject FinishCam;
	public GameObject DrivingCam;
	public GameObject levelBGM;
	public GameObject CarOthers;

	// Use this for initialization
	void Start() {
		PlayerCar.SetActive (false);
		CompleteTrig.SetActive (false);
		CarOthers.SetActive (false);
		//CarController.m_Topspeed = 0.0f;
		PlayerCar.GetComponent<CarAudio> ().enabled = false;
		PlayerCar.GetComponent<CarController> ().enabled = false;
		PlayerCar.GetComponent<CarUserControl> ().enabled = false;

		CashDisplay.TotalCash += 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);

		DrivingCam.SetActive (false);
		PlayerCar.SetActive (true);
		FinishCam.SetActive (true);
		levelBGM.SetActive (false);
		FinishBGM.Play ();
		StartCoroutine (EndofRace ());
	}

	IEnumerator EndofRace(){
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene (0);
	}
	

}
