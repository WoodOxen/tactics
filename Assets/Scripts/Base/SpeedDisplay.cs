using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedDisplay : MonoBehaviour
{
    public GameObject[] TheCar;
    public static float[] speed;
    private Vector3 velocity;
    private int PlayerNum;
    private int TotalPlayerNum;
    public GameObject speedDisplaybox;

    //debug”√
    //public GameObject speedDisplaybox2;
    //public GameObject speedDisplaybox3;
    //public GameObject speedDisplaybox4;
    //public static float[] accelDebug;

    void Start()
    {
        speed = new float[4] { 0, 0, 0, 0 };
        //accelDebug = new float[4] { 0, 0, 0, 0 };
    }


    void FixedUpdate()
    {
        ///*
        PlayerNum = ViewModeManager.CamNum;
        TotalPlayerNum = GameSetting.NumofPlayer;
        for (int i = 0; i < TotalPlayerNum; i++)
        {
            velocity = TheCar[i].GetComponent<Rigidbody>().velocity;
            speed[i] = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
        }

        speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + speed[PlayerNum].ToString("#0.00");
        //speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + speed[0].ToString("#0.00");
        //speedDisplaybox2.GetComponent<TextMeshProUGUI>().text = "" + speed[1].ToString("#0.00");
        //*/

        //accelDebug[0] = CallCppControl.accel[0];
        //speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + accelDebug[0].ToString("#0.00");
        //accelDebug[1] = CallCppControl.accel[1];
        //speedDisplaybox2.GetComponent<TextMeshProUGUI>().text = "" + accelDebug[1].ToString("#0.00");
        //accelDebug[2] = CallCppControl.accel[2];
        //speedDisplaybox3.GetComponent<TextMeshProUGUI>().text = "" + accelDebug[2].ToString("#0.00");
        //accelDebug[3] = CallCppControl.accel[3];
        //speedDisplaybox4.GetComponent<TextMeshProUGUI>().text = "" + accelDebug[3].ToString("#0.00");

    }
}
