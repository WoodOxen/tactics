using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorDisplayManager : MonoBehaviour
{
    public GameObject ErrorDisplaybox;
    private int PlayerNum;
    private double CruiseError;

    void Update()
    {
        PlayerNum = ViewModeManager.CamNum;
        CruiseError = CruiseData.DistanceError[PlayerNum];
        /*switch (PlayerNum)
        {
            case 0:
                CruiseError = CruiseData.DistanceError;
                break;
            case 1:
                CruiseError = CruiseData2.DistanceError;
                break;
            case 2:
                CruiseError = CruiseData3.DistanceError;
                break;
            case 3:
                CruiseError = CruiseData4.DistanceError;
                break;
        }*/
        ErrorDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
    }
}
