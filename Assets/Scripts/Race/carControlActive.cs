using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class carControlActive : MonoBehaviour {

    public GameObject[] Car;
    public GameObject CallCppControl;

    private int PlayerNum;

    void CariControlActive(int i)
    {
        if (GameSetting.ControlMethod[i] == 2)
            CallCppControl.SetActive(true);
        else
            Car[i].GetComponent<CarControlKeyBoard>().enabled = true;
    }

    void Start()
    {
        PlayerNum = GameSetting.NumofPlayer;

        if(LoadButton.LoadNum != 0)//此次运行为读档复现
        {
            for(int i = 0; i < PlayerNum; i++)
            {
                Car[i].GetComponent<LoadControl>().enabled = true;
            }
        }
        else//此次运行为正常运行
        {
            for(int i = 0; i < PlayerNum && i < 4; i++)
            {
                CariControlActive(i);
            }
            if (PlayerNum > 4)//5~8号车只能用代码控制
                CallCppControl.SetActive(true);
        }
    }
}
