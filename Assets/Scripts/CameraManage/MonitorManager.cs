using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorManager : MonoBehaviour
{
    //监视器UI
    public GameObject[] MonitorPanel;
    public GameObject[] MonitorImage;
    public GameObject[] MonitorDisplay;

    //监视器摄像头
    public GameObject[] Cam_MainView;
    public GameObject[] Cam_LookDown;

    //监视器图象
    public Material[] Mat_MainView;
    public Material[] Mat_LookDown;

    private int NumofMonitor = 0;
    private int[] MonitorObject = new int[3] { 0, 0, 0 };
    private int[] MonitorPerspective = new int[3] { 0, 0, 0 };

    void Start()
    {
        NumofMonitor = MonitorSetting.NumofMonitor;
        for(int i = 0; i < 3; i++)
        {
            MonitorObject[i] = MonitorSetting.MonitorObject[i];
            MonitorPerspective[i] = MonitorSetting.MonitorPerspective[i];
            MonitorDisplay[i].GetComponent<TextMeshProUGUI>().text = "P" + (MonitorObject[i] + 1).ToString();
        }

        //依据用户设置的监视器数量，激活监视器UI和监视摄像头
        for (int i = 0; i < NumofMonitor; i++)
        {
            SetActiveMonitor(i);
        }
    }

    void SetActiveMonitor(int i)
    {
        MonitorPanel[i].SetActive(true);
        if (MonitorPerspective[i] == 1)
        {
            Cam_LookDown[MonitorObject[i]].SetActive(true);
            MonitorImage[i].GetComponent<Image>().material = Mat_LookDown[MonitorObject[i]];
        }
        else
        {
            Cam_MainView[MonitorObject[i]].SetActive(true);
            MonitorImage[i].GetComponent<Image>().material = Mat_MainView[MonitorObject[i]];
        }
    }

}
