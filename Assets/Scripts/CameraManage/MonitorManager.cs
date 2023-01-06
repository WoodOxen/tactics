/**
  * @file MonitorManager.cs
  * @brief 仿真时在屏幕上方添加小窗口显示监视器中的画面
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → Monitors → MonitorManager \n
  * 根据MonitorSetting.cs中保存的用户对监视器的设置添加监视器窗口
  * @author 李雨航
  * @date 2022-12-31
  */


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorManager : MonoBehaviour
{
    /// 监视器窗口UI
    public GameObject[] MonitorPanel;
    /// 监视器图象
    public GameObject[] MonitorImage;
    /// 监视器文字UI
    public GameObject[] MonitorDisplay;

    /// 监视器摄像头(主视角)
    public GameObject[] Cam_MainView;
    /// 监视器摄像头(俯视角)
    public GameObject[] Cam_LookDown;

    /// 主视角的监视图象
    public Material[] Mat_MainView;
    /// 俯视角的监视图象
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
