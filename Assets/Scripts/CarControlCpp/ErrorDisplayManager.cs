using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorDisplayManager : MonoBehaviour
{
    public GameObject ErrorDisplaybox;
    private int PlayerNum;
    private double CruiseError;

    //public GameObject ErrorDisplaybox2;
    //public GameObject ErrorDisplaybox3;
    //public GameObject ErrorDisplaybox4;

    void Update()
    {
        PlayerNum = ViewModeManager.CamNum;
        CruiseError = CruiseData.DistanceError[PlayerNum];
        ErrorDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
        /*
        //debug”√
        CruiseError = CruiseData.DistanceError[0];
        ErrorDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
        CruiseError = CruiseData.DistanceError[1];
        ErrorDisplaybox2.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
        CruiseError = CruiseData.DistanceError[2];
        ErrorDisplaybox3.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
        CruiseError = CruiseData.DistanceError[3];
        ErrorDisplaybox4.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
        */
    }
}
