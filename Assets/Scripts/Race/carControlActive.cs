using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class carControlActive : MonoBehaviour {

	public GameObject CarControl1;
    public GameObject CarControl2;
    public GameObject CarControl3;
    public GameObject CarControl4;
    public GameObject CallCppControl;

    private int PlayerNum;

    void Start()
    {
        PlayerNum = GameSetting.NumofPlayer;

        if (GameSetting.ControlMethod[0] == 2)
            CallCppControl.SetActive(true); 
        else
            CarControl1.GetComponent<CarUserControl>().enabled = true;

        if (PlayerNum > 1)
        {
            if (GameSetting.ControlMethod[1] == 2)
                CallCppControl.SetActive(true);
            else
                CarControl2.GetComponent<CarUserControl>().enabled = true;
        }

        if (PlayerNum > 2)
        {
            if (GameSetting.ControlMethod[2] == 2)
                CallCppControl.SetActive(true);
            else
                CarControl3.GetComponent<CarUserControl>().enabled = true;
        }

        if (PlayerNum > 3)
        {
            if (GameSetting.ControlMethod[3] == 2)
                CallCppControl.SetActive(true);
            else
                CarControl4.GetComponent<CarUserControl>().enabled = true;
        }
    }
}
