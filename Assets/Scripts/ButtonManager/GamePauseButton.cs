using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseButton : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject NormalCam;
    public GameObject FarCam;
    public GameObject FPCam;
    public GameObject SavePanel;
    private int CamMode;
    private int trackNum;

    public void BacktoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ContinueRace()
    {
        Time.timeScale = 1;
        /*
        CamMode = ViewModeManager.ViewMode;
        if (CamMode == 0)
        {
            NormalCam.GetComponent<AudioListener>().enabled = true;
        }
        else if (CamMode == 1)
        {
            FarCam.GetComponent<AudioListener>().enabled = true;
        }
        else if (CamMode == 2)
        {
            FPCam.GetComponent<AudioListener>().enabled = true;
        }
        */
        pausePanel.SetActive(false);
    }
    public void SaveGame()
    {
        SavePanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
            SceneManager.LoadScene(5);
    }
}
