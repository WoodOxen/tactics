using UnityEngine;
using System.Collections;

public class RedScore : MonoBehaviour {

	void Update()
	{
		this.transform.Rotate(0, 1, 0, Space.Self);
	}

	void OnTriggerEnter(){
		GameModeManager.CurrentScore += 100;
		gameObject.SetActive (false);
	}
}
