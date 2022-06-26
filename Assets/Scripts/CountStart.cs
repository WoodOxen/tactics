using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class CountStart : MonoBehaviour {

	public GameObject CountDown;
	public AudioSource GetReady;
	public AudioSource GoAudio;
	public AudioSource BGM01;
	public GameObject CarControl;
	public GameObject LapTimer;

	void Start () {
		PlayerPrefs.SetInt ("MinSave", 0);
		PlayerPrefs.SetInt ("SecSave", 0);
		PlayerPrefs.SetFloat ("MilliSave", 0);
		PlayerPrefs.SetFloat ("RAWTIME", 0);
		StartCoroutine (CountdownStart ());
	}

	IEnumerator CountdownStart(){
		yield return new WaitForSeconds (0.5f);
		CountDown.GetComponent<Text> ().text = "3";
		GetReady.Play ();
		CountDown.SetActive (true);
		yield return new WaitForSeconds (1);
		CountDown.SetActive (false);
		CountDown.GetComponent<Text> ().text = "2";
		GetReady.Play ();
		CountDown.SetActive (true);
		yield return new WaitForSeconds (1);
		CountDown.SetActive (false);
		CountDown.GetComponent<Text> ().text = "1";
		GetReady.Play ();
		CountDown.SetActive (true);
		yield return new WaitForSeconds (1);
		CountDown.SetActive (false);
		GoAudio.Play ();
		BGM01.Play ();
		LapTimer.SetActive (true);
		CarControl.SetActive (true);
	}
}
