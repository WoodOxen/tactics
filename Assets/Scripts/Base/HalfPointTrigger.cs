using UnityEngine;
using System.Collections;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;
    public static bool HalfFlag1 = false;
    public static bool HalfFlag2 = false;
    public static bool HalfFlag3 = false;
    public static bool HalfFlag4 = false;

    void OnTriggerEnter(Collider collision)
    {
        //排除AI车和其他空气墙碰撞的情况
        if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge"){
            return;
        }
        //记录四辆人工操控车通过半途检查点的情况
        if (collision.gameObject.tag == "Player" && LapComplete.LapFlag1)
        {
            //Debug.Log(1);
            HalfFlag1 = true;
            LapComplete.LapFlag1 = false;
        }
        if (collision.gameObject.tag == "Player2" && LapComplete.LapFlag2)
        {
            //Debug.Log(2);
            HalfFlag2 = true;
            LapComplete.LapFlag2 = false;
        }
        if (collision.gameObject.tag == "Player3" && LapComplete.LapFlag3)
        {
            //Debug.Log(3);
            HalfFlag3 = true;
            LapComplete.LapFlag3 = false;
        }
        if (collision.gameObject.tag == "Player4" && LapComplete.LapFlag4)
        {
            //Debug.Log(4);
            HalfFlag4 = true;
            LapComplete.LapFlag4 = false;
        }

        //LapCompleteTrig.SetActive (true);
        //HalfLapTrig.SetActive (false);
    }
}
