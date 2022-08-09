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
        switch (CarNum)
        {
            case 0:
                LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount1;
                break;
            case 1:
                LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount2;
                break;
            case 2:
                LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount3;
                break;
            case 3:
                LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount4;
                break;
        }
    }
}
