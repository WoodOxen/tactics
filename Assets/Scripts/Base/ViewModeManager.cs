using UnityEngine;
using System.Collections;

public class ViewModeManager : MonoBehaviour {

	public GameObject NormalCam;
	public GameObject FarCam;
	public GameObject FPCam;
	public static int CamMode = 0;
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("ViewMode")) {
			CamMode += 1;
			CamMode = CamMode % 3;
			StartCoroutine (ModeChange ());
		}
	}

	IEnumerator ModeChange(){
		yield return new WaitForSeconds (0.01f);
		if (CamMode == 0) {
			NormalCam.SetActive (true);
			FPCam.SetActive (false);
		}
		if (CamMode == 1) {
			FarCam.SetActive (true);
			NormalCam.SetActive (false);
		}
		if (CamMode == 2) {
			FPCam.SetActive (true);
			FarCam.SetActive (false);
		}
	}
}
