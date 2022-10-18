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
        ErrorDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
    }
}
