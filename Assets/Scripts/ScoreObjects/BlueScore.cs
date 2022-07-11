using UnityEngine;
using System.Collections;

public class BlueScore : MonoBehaviour {
	void Update()
	{
		this.transform.Rotate(0, 1, 0, Space.Self);
	}

	void OnTriggerEnter(){
		GameModeManager.CurrentScore += 50;
		gameObject.SetActive (false);
	}
}
