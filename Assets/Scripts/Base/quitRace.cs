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
            Time.timeScale = 0;
        }
	}
}
