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
    // Update is called once per frame

    void Update()
    {
        Steer = CarUserControl.h;
        
        SteerWheel.transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Steer*-90);
        steerDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + Steer.ToString("#0.00");
    }
}
