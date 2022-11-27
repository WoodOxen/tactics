using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseButton : MonoBehaviour
{
    public GameObject pausePanel;
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
        pausePanel.SetActive(false);
    }
    public void SaveGame()
    {
        SavePanel.SetActive(true);
        pausePanel.SetActive(false);
        SaveButton.WhoCalloutSavePanel = 2;
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
