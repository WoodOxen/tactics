using UnityEngine;
using System.Collections;

public class YellowScore : MonoBehaviour {


	void Update()
    {
		this.transform.Rotate(0,1,0,Space.Self);
	}

	void OnTriggerEnter(){
		ScoreMode.CurrentScore += 25;
		gameObject.SetActive (false);
	}
}
