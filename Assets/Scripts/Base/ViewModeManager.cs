using UnityEngine;
using System.Collections;

public class ViewModeManager : MonoBehaviour {

	public GameObject NormalCam;
	public GameObject FarCam;
	public GameObject FPCam;
    public GameObject OverlookCam;
	public static int CamMode = 0;
    public GameObject steerDisplaybox;
    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown ("ViewMode")) {
			CamMode += 1;
			CamMode = CamMode % 4;
			StartCoroutine (ModeChange ());
		}
	}

	IEnumerator ModeChange(){
		yield return new WaitForSeconds (0.01f);
		if (CamMode == 0) {
			NormalCam.SetActive (true);
			FPCam.SetActive (false);
            FarCam.SetActive(false);
            OverlookCam.SetActive(false);
            steerDisplaybox.SetActive(false);
        }
		if (CamMode == 1) {
			FPCam.SetActive (true);
			FarCam.SetActive (false);
            NormalCam.SetActive(false);
            OverlookCam.SetActive(false);
            steerDisplaybox.SetActive(true);
        }
        if (CamMode == 2) {
			FarCam.SetActive (true);
			NormalCam.SetActive (false);
            FPCam.SetActive(false);
            OverlookCam.SetActive(false);
            steerDisplaybox.SetActive(false);
        }
        if (CamMode == 3)
        {
            OverlookCam.SetActive(true);
            FarCam.SetActive(false);
            NormalCam.SetActive(false);
            FPCam.SetActive(false);
            steerDisplaybox.SetActive(false);
        }
    }
}
