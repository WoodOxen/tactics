using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class quitRace : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			SceneManager.LoadScene (0);
		}
	}
}
