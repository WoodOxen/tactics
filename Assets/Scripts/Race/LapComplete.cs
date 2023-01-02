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
    public static int[] LapCount = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

    public float rawTime;

    public static bool[] LapFlag = new bool[8] { true, true, true, true, true, true, true, true };

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
        //记录1号车通过终点线的情况
        if (collision.gameObject.tag == "Player" && HalfPointTrigger.HalfFlag[0])
        {
            //Debug.Log(1);
            LapFlag[0] = true;
            HalfPointTrigger.HalfFlag[0] = false;
            LapCount[0] += 1;
        }
        //记录2~8号车通过终点线的情况
        for (int i = 1; i < GameSetting.NumofPlayer; i++)
        {
            if (collision.gameObject.tag == "Player"+(i+1).ToString() && HalfPointTrigger.HalfFlag[i])
            {
                //Debug.Log(i+1);
                LapFlag[i] = true;
                HalfPointTrigger.HalfFlag[i] = false;
                LapCount[i] += 1;
            }
        }

        //巡线结束条件
        if ((ModeSelection == 2 && LapCount[0] == 1)|| LapCount[0] == 1) {
            RaceFinish.SetActive (true);
        }

    }
}
