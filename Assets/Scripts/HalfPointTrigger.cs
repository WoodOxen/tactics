using UnityEngine;
using System.Collections;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "DreamCar01" || collision.gameObject.tag == "CarPosJudge"){
            return;
        }
        LapCompleteTrig.SetActive (true);
		HalfLapTrig.SetActive (false);
	}
}
