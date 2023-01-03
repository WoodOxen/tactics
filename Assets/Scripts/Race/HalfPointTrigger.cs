using UnityEngine;
using System.Collections;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;
    public static bool[] HalfFlag = new bool[8] { false , false, false, false, false, false, false, false };

    void Start()
    {
        HalfFlag = new bool[8] { false, false, false, false, false, false, false, false };
    }

    void OnTriggerEnter(Collider collision)
    {
        //排除AI车和其他空气墙碰撞的情况
        if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge"){
            return;
        }
        //记录四辆人工操控车通过半途检查点的情况
        if (collision.gameObject.tag == "Player" && LapComplete.LapFlag[0])
        {
            //Debug.Log(1);
            HalfFlag[0] = true;
            LapComplete.LapFlag[0] = false;
        }
        for(int i = 1;i < GameSetting.NumofPlayer; i++)
        {
            if (collision.gameObject.tag == "Player"+(i+1).ToString() && LapComplete.LapFlag[i])
            {
                //Debug.Log(i+1);
                HalfFlag[i] = true;
                LapComplete.LapFlag[i] = false;
            }
        }

        //LapCompleteTrig.SetActive (true);
        //HalfLapTrig.SetActive (false);
    }
}
