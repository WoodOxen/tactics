using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class quitGame : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			Application.Quit ();
		}
	}
}
