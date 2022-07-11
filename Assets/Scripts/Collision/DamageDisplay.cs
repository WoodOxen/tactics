using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    public GameObject damageDisplay;
    static public float ExtentOfDamage;
    static public int CollisionNum;
    void Update()
    {
        damageDisplay.GetComponent<Text>().text = "" + ExtentOfDamage;
    }
}
