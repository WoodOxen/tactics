using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedDisplay : MonoBehaviour
{
    public GameObject[] TheCar;
    public static float[] speed = new float[4];
    private Vector3 velocity;
    private int PlayerNum;
    public GameObject speedDisplaybox;
    // Update is called once per frame
    void Update()
    {
        PlayerNum = ViewModeManager.CamNum;
        for(int i = 0; i < 4; i++)
        {
            velocity = TheCar[i].GetComponent<Rigidbody>().velocity;
            speed[i] = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
        }
        speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + speed[PlayerNum].ToString("#0.00");
    }
}
