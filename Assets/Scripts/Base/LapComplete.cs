using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LapComplete : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	public GameObject MinuteNow;
	public GameObject SecondNow;
	public GameObject MilliNow;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;
	//public GameObject LapCountDisplay;

	public GameObject RaceFinish;
    private int ModeSelection;

    public int modeType;
	public int flag_firstlyEnter;
	public static int LapCount1 = 0;
    public static int LapCount2 = 0;
    public static int LapCount3 = 0;
    public static int LapCount4 = 0;
    public float rawTime;

    public static bool LapFlag1 = true;
    public static bool LapFlag2 = true;
    public static bool LapFlag3 = true;
    public static bool LapFlag4 = true;

    void Start () {
		flag_firstlyEnter = 1;
		modeType = GameSetting.RaceMode;
        ModeSelection = GameSetting.RaceMode;
        LapFlag1 = true;
        LapFlag2 = true;
        LapFlag3 = true;
        LapFlag4 = true;
        LapCount1 = 0;
        LapCount2 = 0;
        LapCount3 = 0;
        LapCount4 = 0;
}
		
	void OnTriggerEnter(Collider collision){
		/*if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge") {
			return;
		}*/
        //记录四辆人工控制车通过终点线的情况
        if(collision.gameObject.tag == "Player2" && HalfPointTrigger.HalfFlag2)
        {
            //Debug.Log(2);
            LapFlag2 = true;
            HalfPointTrigger.HalfFlag2 = false;
            LapCount2 += 1;
        }
        else if (collision.gameObject.tag == "Player3" && HalfPointTrigger.HalfFlag3)
        {
            //Debug.Log(3);
            LapFlag3 = true;
            HalfPointTrigger.HalfFlag3 = false;
            LapCount3 += 1;
        }
        else if (collision.gameObject.tag == "Player4" && HalfPointTrigger.HalfFlag4)
        {
            //Debug.Log(4);
            LapFlag4 = true;
            HalfPointTrigger.HalfFlag4 = false;
            LapCount4 += 1;
        }
        else if (collision.gameObject.tag == "Player" && HalfPointTrigger.HalfFlag1)
        {
            //Debug.Log(1);
            LapFlag1 = true;
            HalfPointTrigger.HalfFlag1 = false;
            LapCount1 += 1;
        }
        else//其他AI车通过重点线，不做记录
        {
            return;
        }

        //LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapCount;
        if ((ModeSelection == 2 && LapCount1 == 1)|| LapCount1 == 1) {
            RaceFinish.SetActive (true);
		}

        /*
         * 历史代码残留，用于显示Best Lap Time
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
