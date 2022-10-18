using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SteerDisplay : MonoBehaviour
{
    private float Steer;
    
    public GameObject SteerWheel;
    public GameObject steerDisplaybox;

    private int PlayerNum;

    void FixedUpdate()
    {
        PlayerNum = ViewModeManager.CamNum;//当前视角跟随的车辆编号
        if(GameSetting.ControlMethod[PlayerNum] == 1)//Keyboard
        {
            Steer = CarUserControl.h[PlayerNum];
        }
        else//ScriptControl
        {
            Steer = CallCppControl.steering[PlayerNum];
        }
        
        SteerWheel.transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Steer*-90);
        steerDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + Steer.ToString("#0.00");
    }
}
