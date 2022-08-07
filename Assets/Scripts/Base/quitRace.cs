using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class quitRace : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject NormalCam;
    public GameObject FarCam;
    public GameObject FPCam;
    private int CamMode;
    void Update () {
		if (Input.GetButtonDown ("Cancel")) {
            pausePanel.SetActive(true);
            /*
            CamMode = ViewModeManager.CamMode;
            if (CamMode == 0)
            {
                NormalCam.GetComponent<AudioListener>().enabled = false;
            }
            else if (CamMode == 1)
            {
                FarCam.GetComponent<AudioListener>().enabled = false;
            }
            else if (CamMode == 2)
            {
                FPCam.GetComponent<AudioListener>().enabled = false;
            }
            */
            Time.timeScale = 0;
        }
	}
}
