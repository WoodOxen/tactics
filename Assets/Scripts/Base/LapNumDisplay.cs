using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapNumDisplay : MonoBehaviour
{
    public GameObject LapCountDisplay;
    void Update()
    {
        LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount1;
    }
}
