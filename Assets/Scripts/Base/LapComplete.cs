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
    private int ModeSelection;

    public int modeType;
	public int flag_firstlyEnter;
	public int LapCount=0;
	public float rawTime;

	void Start () {
		flag_firstlyEnter = 1;
		modeType = GameSetting.RaceMode;
        ModeSelection = GameSetting.RaceMode;
    }
		
	void OnTriggerEnter(Collider collision){
		/*if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge") {
			return;
		}*/
        if(collision.gameObject.tag != "Player")
        {
            return;
        }

		LapCount += 1;
        LapCountDisplay.GetComponent<Text>().text = "" + LapCount;
        if ((ModeSelection == 2 && LapCount == 1)|| LapCount == 2) {
            RaceFinish.SetActive (true);
		}

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);

        /*
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
        */


    }
}
