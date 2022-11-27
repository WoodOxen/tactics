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

        if(LoadButton.LoadNum != 0)//此次运行为读档复现
        {
            CarControl1.GetComponent<LoadControl>().enabled = true;
            if (PlayerNum > 1) CarControl2.GetComponent<LoadControl>().enabled = true;
            if (PlayerNum > 2) CarControl3.GetComponent<LoadControl>().enabled = true;
            if (PlayerNum > 3) CarControl4.GetComponent<LoadControl>().enabled = true;
        }
        else//此次运行为正常运行
        {
            if (GameSetting.ControlMethod[0] == 2)
                CallCppControl.SetActive(true);
            else
                CarControl1.GetComponent<CarControlKeyBoard>().enabled = true;

            if (PlayerNum > 1)
            {
                if (GameSetting.ControlMethod[1] == 2)
                    CallCppControl.SetActive(true);
                else
                    CarControl2.GetComponent<CarControlKeyBoard>().enabled = true;
            }

            if (PlayerNum > 2)
            {
                if (GameSetting.ControlMethod[2] == 2)
                    CallCppControl.SetActive(true);
                else
                    CarControl3.GetComponent<CarControlKeyBoard>().enabled = true;
            }

            if (PlayerNum > 3)
            {
                if (GameSetting.ControlMethod[3] == 2)
                    CallCppControl.SetActive(true);
                else
                    CarControl4.GetComponent<CarControlKeyBoard>().enabled = true;
            }
        }
    }
}
