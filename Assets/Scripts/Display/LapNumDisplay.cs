using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapNumDisplay : MonoBehaviour
{
    public GameObject LapCountDisplay;
    private int CarNum;
    void Start()
    {
        CarNum = ViewModeManager.CamNum;
    }

    void Update()
    {
        CarNum = ViewModeManager.CamNum;
        LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount[CarNum];
    }
}
