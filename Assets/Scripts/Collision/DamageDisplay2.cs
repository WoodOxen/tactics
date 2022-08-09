using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay2 : MonoBehaviour
{
    public GameObject damageDisplay;
    static public float ExtentOfDamage = 0;
    static public int CollisionNum = 0;
    void Update()
    {
        damageDisplay.GetComponent<TextMeshProUGUI>().text = "" + ExtentOfDamage.ToString("#0.00");
    }
}
