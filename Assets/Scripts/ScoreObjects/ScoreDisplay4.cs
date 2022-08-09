using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay4 : MonoBehaviour
{
    //public GameObject CurrentScoreDisplay1;
    //public GameObject CurrentScoreDisplay2;
    //public GameObject CurrentScoreDisplay3;
    public GameObject CurrentScoreDisplay4;

    void Update()
    {
        //CurrentScoreDisplay1.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore1;
        //CurrentScoreDisplay2.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore2;
        //CurrentScoreDisplay3.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore3;
        CurrentScoreDisplay4.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore4;
    }
}
