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

    void Start()
    {
        speed = new float[4] { 0, 0, 0, 0 };
        //accelDebug = new float[4] { 0, 0, 0, 0 };
    }


    void FixedUpdate()
    {
        //PlayerNum：当前相机跟随的车辆编号；TotalPlayerNum：总车辆数
        PlayerNum = ViewModeManager.CamNum;
        TotalPlayerNum = GameSetting.NumofPlayer;
        for (int i = 0; i < TotalPlayerNum; i++)
        {
            velocity = TheCar[i].GetComponent<Rigidbody>().velocity;
            speed[i] = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
            //Debug.Log(string.Format("Speed {0} {1}: {2}", CallCppControl.a, i,speed[i]));
        }
        speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + speed[PlayerNum].ToString("#0.00");
    }
}
