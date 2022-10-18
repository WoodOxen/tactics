using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletePanelButton : MonoBehaviour
{
    private int trackNum;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
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
