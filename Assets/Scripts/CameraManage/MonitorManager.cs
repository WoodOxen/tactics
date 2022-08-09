using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorManager : MonoBehaviour
{
    public GameObject Monitor1Panel;
    public GameObject Monitor2Panel;
    public GameObject Monitor3Panel;
    public GameObject Monitor1Image;
    public GameObject Monitor2Image;
    public GameObject Monitor3Image;

    private Material[,] Cam;
    public Material Cam1_1;
    public Material Cam1_2;
    public Material Cam2_1;
    public Material Cam2_2;
    public Material Cam3_1;
    public Material Cam3_2;
    public Material Cam4_1;
    public Material Cam4_2;

    private int NumofMonitor = 0;
    private int Monitor1Object = 0;
    private int Monitor2Object = 0;
    private int Monitor3Object = 0;
    private int Monitor1Perspective = 0;
    private int Monitor2Perspective = 0;
    private int Monitor3Perspective = 0;

    public GameObject display1;
    public GameObject display2;
    public GameObject display3;

    void Start()
    {
        NumofMonitor = MonitorSetting.NumofMonitor;
        Monitor1Object = MonitorSetting.Monitor1Object;
        Monitor2Object = MonitorSetting.Monitor2Object;
        Monitor3Object = MonitorSetting.Monitor3Object;
        Monitor1Perspective = MonitorSetting.Monitor1Perspective;
        Monitor2Perspective = MonitorSetting.Monitor2Perspective;
        Monitor3Perspective = MonitorSetting.Monitor3Perspective;

        Cam = new Material[4, 2];
        Cam[0, 0] = Cam1_1;
        Cam[0, 1] = Cam1_2;
        Cam[1, 0] = Cam2_1;
        Cam[1, 1] = Cam2_2;
        Cam[2, 0] = Cam3_1;
        Cam[2, 1] = Cam3_2;
        Cam[3, 0] = Cam4_1;
        Cam[3, 1] = Cam4_2;

        display1.GetComponent<TextMeshProUGUI>().text = "P" + (Monitor1Object + 1).ToString();
        display2.GetComponent<TextMeshProUGUI>().text = "P" + (Monitor2Object + 1).ToString();
        display3.GetComponent<TextMeshProUGUI>().text = "P" + (Monitor3Object + 1).ToString();

        if (NumofMonitor > 0)
        {
            Monitor1Panel.SetActive(true);
            Monitor1Image.GetComponent<Image>().material = Cam[Monitor1Object, Monitor1Perspective];
        }
        if (NumofMonitor > 1)
        {
            Monitor2Panel.SetActive(true);
            Monitor2Image.GetComponent<Image>().material = Cam[Monitor2Object, Monitor2Perspective];
        }
        if (NumofMonitor > 2)
        {
            Monitor3Panel.SetActive(true);
            Monitor3Image.GetComponent<Image>().material = Cam[Monitor3Object, Monitor3Perspective];
        }     
    }

}
