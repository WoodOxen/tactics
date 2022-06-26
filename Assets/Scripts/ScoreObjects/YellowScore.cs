using UnityEngine;
using System.Collections;

public class YellowScore : MonoBehaviour {

	void OnTriggerEnter(){
		ScoreMode.CurrentScore += 25;
		gameObject.SetActive (false);
	}
}
