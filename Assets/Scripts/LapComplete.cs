using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	public GameObject MinuteNow;
	public GameObject SecondNow;
	public GameObject MilliNow;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;
	public GameObject LapCountDisplay;

	public GameObject RaceFinish;


	public int modeType;
	public int flag_firstlyEnter;
	public int LapCount=0;
	public float rawTime;

	void Start () {
		flag_firstlyEnter = 1;
		modeType = CarChoose.RaceMode;
	}
		
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge") {
			return;
		}

		LapCount += 1;

		if (LapCount == 2) {
			RaceFinish.SetActive (true);
		}
		/*if (LapTimeManager.SecondCount <= 9) {
			SecondDisplay.GetComponent<Text> ().text = "0" + LapTimeManager.SecondCount + ".";
		} else {
			SecondDisplay.GetComponent<Text> ().text = "" + LapTimeManager.SecondCount + ".";
		}

		if (LapTimeManager.MinuteCount <= 9) {
			MinuteDisplay.GetComponent<Text> ().text = "0" + LapTimeManager.MinuteCount + ".";
		} else {
			MinuteDisplay.GetComponent<Text> ().text = "" + LapTimeManager.MinuteCount + ".";
		}

		MilliDisplay.GetComponent<Text> ().text = "" + LapTimeManager.MilliCount;
		*/

		rawTime = PlayerPrefs.GetFloat ("RAWTIME");
		if (LapTimeManager.rawtime <= rawTime || flag_firstlyEnter == 1) {
			MinuteDisplay.GetComponent<Text> ().text = MinuteNow.GetComponent<Text> ().text;
			SecondDisplay.GetComponent<Text> ().text = SecondNow.GetComponent<Text> ().text;
			MilliDisplay.GetComponent<Text> ().text = MilliNow.GetComponent<Text> ().text;
			PlayerPrefs.SetInt ("MinSave", LapTimeManager.MinuteCount);
			PlayerPrefs.SetInt ("SecSave", LapTimeManager.SecondCount);
			PlayerPrefs.SetFloat ("MilliSave", LapTimeManager.MilliCount);
			PlayerPrefs.SetFloat ("RAWTIME", LapTimeManager.rawtime);
			flag_firstlyEnter = 0;
		}

		LapCountDisplay.GetComponent<Text> ().text = "" + LapCount;

		LapTimeManager.rawtime = 0;
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;

		HalfLapTrig.SetActive (true);
		LapCompleteTrig.SetActive (false);

	}
}
