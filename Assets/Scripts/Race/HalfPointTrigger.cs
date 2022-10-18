using UnityEngine;
using System.Collections;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;
    public static bool[] HalfFlag = new bool[4] { false , false, false, false};

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
        if (collision.gameObject.tag == "Player2" && LapComplete.LapFlag[1])
        {
            //Debug.Log(2);
            HalfFlag[1] = true;
            LapComplete.LapFlag[1] = false;
        }
        if (collision.gameObject.tag == "Player3" && LapComplete.LapFlag[2])
        {
            //Debug.Log(3);
            HalfFlag[2] = true;
            LapComplete.LapFlag[2] = false;
        }
        if (collision.gameObject.tag == "Player4" && LapComplete.LapFlag[3])
        {
            //Debug.Log(4);
            HalfFlag[3] = true;
            LapComplete.LapFlag[3] = false;
        }

        //LapCompleteTrig.SetActive (true);
        //HalfLapTrig.SetActive (false);
    }
}
