using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SteerDisplay : MonoBehaviour
{
    public GameObject TheCar;
    private float Steer;
    
    public GameObject SteerWheel;
    public GameObject steerDisplaybox;

    private int PlayerNum;
    // Update is called once per frame

    void Update()
    {
        PlayerNum = ViewModeManager.CamNum;
        switch (PlayerNum)
        {
            case 0:
                Steer = CarUserControl.h;
                break;
            case 1:
                Steer = CarUserControl2.h;
                break;
            case 2:
                Steer = CarUserControl3.h;
                break;
            case 3:
                Steer = CarUserControl4.h;
                break;
        }
        SteerWheel.transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Steer*-90);
        steerDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + Steer.ToString("#0.00");
    }
}
