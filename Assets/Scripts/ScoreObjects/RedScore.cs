using UnityEngine;
using System.Collections;

public class RedScore : MonoBehaviour {

	void OnTriggerEnter(){
		ScoreMode.CurrentScore += 100;
		gameObject.SetActive (false);
	}
}
