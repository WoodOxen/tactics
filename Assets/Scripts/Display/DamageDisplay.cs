using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField] public int CarNum;
    public GameObject damageDisplay;
    static public float[] ExtentOfDamage = new float[4] { 0, 0, 0, 0 };
    static public int[] CollisionNum = new int[4] { 0, 0, 0, 0 };
    void Update()
    {
        damageDisplay.GetComponent<TextMeshProUGUI>().text = "" + ExtentOfDamage[CarNum].ToString("#0.00");
    }
}
