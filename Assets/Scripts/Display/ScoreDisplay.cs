using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static int[] Score = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public GameObject CurrentScoreDisplay;
    [SerializeField] public int CarNum;

    void Update()
    {
        CurrentScoreDisplay.GetComponent<TextMeshProUGUI>().text = "" + Score[CarNum];
    }
}
