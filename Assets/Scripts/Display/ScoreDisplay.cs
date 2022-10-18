using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    public GameObject CurrentScoreDisplay;
    [SerializeField] public int CarNum;

    void Update()
    {
        CurrentScoreDisplay.GetComponent<TextMeshProUGUI>().text = "" + CurrentScore.Score[CarNum];
    }
}
