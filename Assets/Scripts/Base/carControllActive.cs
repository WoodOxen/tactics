using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class carControllActive : MonoBehaviour {

	public GameObject CarControl1;
    public GameObject CarControl2;
    public GameObject CarControl3;
    public GameObject CarControl4;
    public GameObject CallCppControl;
    private int PlayerNum;

    void Start()
    {
        PlayerNum = GameSetting.NumofPlayer;

        CarControl1.GetComponent<CarController>().enabled = true;
        if (GameSetting.ControlMethod[0] == 2)
            CallCppControl.SetActive(true);
        //CarControl1.GetComponent<CppCarControl>().enabled = true;
        else
            CarControl1.GetComponent<CarUserControl>().enabled = true;
        CarControl1.GetComponent<CarAudio>().enabled = true;

        if (PlayerNum > 1)
        {
            CarControl2.GetComponent<CarController>().enabled = true;
            if (GameSetting.ControlMethod[1] == 2)
                CallCppControl.SetActive(true);
            //CarControl2.GetComponent<CppCarControl>().enabled = true;
            else
                CarControl2.GetComponent<CarUserControl2>().enabled = true;
            CarControl2.GetComponent<CarAudio>().enabled = true;
        }

        if (PlayerNum > 2)
        {
            CarControl3.GetComponent<CarController>().enabled = true;
            if (GameSetting.ControlMethod[2] == 2)
                CallCppControl.SetActive(true);
            //CarControl3.GetComponent<CppCarControl>().enabled = true;
            else
                CarControl3.GetComponent<CarUserControl3>().enabled = true;
            CarControl3.GetComponent<CarAudio>().enabled = true;
        }

        if (PlayerNum > 3)
        {
            CarControl4.GetComponent<CarController>().enabled = true;
            if (GameSetting.ControlMethod[3] == 2)
                CallCppControl.SetActive(true);
            //CarControl4.GetComponent<CppCarControl>().enabled = true;
            else
                CarControl4.GetComponent<CarUserControl4>().enabled = true;
            CarControl4.GetComponent<CarAudio>().enabled = true;
        }
    }
}
