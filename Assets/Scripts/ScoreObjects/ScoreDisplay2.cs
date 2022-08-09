using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay2 : MonoBehaviour
{
    //public GameObject CurrentScoreDisplay1;
    public GameObject CurrentScoreDisplay2;
    //public GameObject CurrentScoreDisplay3;
    //public GameObject CurrentScoreDisplay4;

    void Update()
    {
        //CurrentScoreDisplay1.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore1;
        CurrentScoreDisplay2.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore2;
    }
}
