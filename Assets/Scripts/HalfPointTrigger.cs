using UnityEngine;
using System.Collections;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	void OnTriggerEnter(){
		LapCompleteTrig.SetActive (true);
		HalfLapTrig.SetActive (false);
	}
}
