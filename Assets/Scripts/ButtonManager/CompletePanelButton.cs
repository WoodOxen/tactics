using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletePanelButton : MonoBehaviour
{
    private int trackNum;
    public GameObject SavePanel;
    public GameObject CompletePanel;

    public void SaveGame()
    {
        SavePanel.SetActive(true);
        CompletePanel.SetActive(false);
        SaveButton.WhoCalloutSavePanel = 1;
    }

    public void MainMenu()
    {
        for (int i = 0; i < 4; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        for (int i = 0; i < 4; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
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
