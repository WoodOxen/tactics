using UnityEngine;
using System.Collections;

public class BlueScore : MonoBehaviour {

	void OnTriggerEnter(){
		ScoreMode.CurrentScore += 50;
		gameObject.SetActive (false);
	}
}
