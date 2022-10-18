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
	public static int[] LapCount = new int[4] { 0, 0, 0, 0 };

    public float rawTime;

    public static bool[] LapFlag = new bool[4] { true, true, true, true };

    void Start () {
		flag_firstlyEnter = 1;
		modeType = GameSetting.RaceMode;
        ModeSelection = GameSetting.RaceMode;
        for(int i = 0; i < 4; i++)
        {
            LapCount[i] = 0;
            LapFlag[i] = true;
        }
}
		
	void OnTriggerEnter(Collider collision){
		/*if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge") {
			return;
		}*/
        //记录四辆人工控制车通过终点线的情况
        if(collision.gameObject.tag == "Player2" && HalfPointTrigger.HalfFlag[1])
        {
            //Debug.Log(2);
            LapFlag[1] = true;
            HalfPointTrigger.HalfFlag[1] = false;
            LapCount[1] += 1;
        }
        else if (collision.gameObject.tag == "Player3" && HalfPointTrigger.HalfFlag[2])
        {
            //Debug.Log(3);
            LapFlag[2] = true;
            HalfPointTrigger.HalfFlag[2] = false;
            LapCount[2] += 1;
        }
        else if (collision.gameObject.tag == "Player4" && HalfPointTrigger.HalfFlag[3])
        {
            //Debug.Log(4);
            LapFlag[3] = true;
            HalfPointTrigger.HalfFlag[3] = false;
            LapCount[3] += 1;
        }
        else if (collision.gameObject.tag == "Player" && HalfPointTrigger.HalfFlag[0])
        {
            //Debug.Log(1);
            LapFlag[0] = true;
            HalfPointTrigger.HalfFlag[0] = false;
            LapCount[0] += 1;
        }
        else//其他AI车通过重点线，不做记录
        {
            return;
        }

        //巡线结束条件
        if ((ModeSelection == 2 && LapCount[0] == 1)|| LapCount[0] == 1) {
            RaceFinish.SetActive (true);
		}

    }
}
