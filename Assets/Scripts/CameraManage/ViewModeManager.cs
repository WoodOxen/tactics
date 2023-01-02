/**
  * @file ViewModeManager.cs
  * @brief 仿真时切换观测视角和切换所观测车辆的功能
  * @details  
  * 挂载该脚本的对象：RaceArea → ViewModeManager \n
  * 在仿真界面，用户按下c键可以切换视角，按下x键可以切换当前观察的车辆。\n
  * 关于c键和x键的输入，可以在Unity开发界面点击Edit → Project Settings → Input Manager参考。\n
  * 每辆车有四个摄像头，分别为普通视角、第一人称视角、远视角、俯视角；\n
  * @param ViewMode 当前视角，0、1、2、3分别对应主普通视角、第一人称视角、远视角、俯视角
  * @param CamNum 当前所观察的车辆编号
  * @author 李雨航
  * @date 2022-12-31
  */

using UnityEngine;
using System.Collections;
using TMPro;

public class ViewModeManager : MonoBehaviour {
    public GameObject[] NormalCam;
	public GameObject[] FarCam;
	public GameObject[] FPCam;
    public GameObject[] OverlookCam;
	public static int ViewMode = 0;//显示模式
    public static int CamNum = 0;//相机跟随的车号
    private int CamNum_last = 0;//之前相机跟随的车号
    private static int PlayerNum = 1;

    public GameObject CamNumDisplay;
    public GameObject steerDisplaybox;

    void Start()
    {
        PlayerNum = GameSetting.NumofPlayer;
        if (PlayerNum > 8) PlayerNum = 8;
        ViewMode = 0;
        CamNum = 0;
        CamNum_last = 0;
    }

    void Update () {
		if (Input.GetButtonDown ("ViewMode")) {
			ViewMode += 1;
			ViewMode = ViewMode % 4;
			StartCoroutine (ModeChange ());
		}
        if (Input.GetButtonDown("PlayerCamera"))
        {
            CamNum_last = CamNum;
            CamNum += 1;
            CamNum = CamNum % PlayerNum;

            CamNumDisplay.GetComponent<TextMeshProUGUI>().text = "P" + (CamNum + 1).ToString();
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (ViewMode == 0)
        {
            NormalCam[CamNum_last].SetActive(false);
            NormalCam[CamNum].SetActive(true); 
        }
        if (ViewMode == 1)
        {
            FPCam[CamNum_last].SetActive(false);
            FPCam[CamNum].SetActive(true);
        }
        if (ViewMode == 2)
        {
            FarCam[CamNum_last].SetActive(false);
            FarCam[CamNum].SetActive(true);
        }
        if (ViewMode == 3)
        {
            OverlookCam[CamNum_last].SetActive(false);
            OverlookCam[CamNum].SetActive(true);
        }
    }


    IEnumerator ModeChange(){
		yield return new WaitForSeconds (0.01f);
        
		if (ViewMode == 0) {
			NormalCam[CamNum].SetActive (true);
            OverlookCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(false);
        }
		if (ViewMode == 1) {
			FPCam[CamNum].SetActive (true);
            NormalCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(true);
        }
        if (ViewMode == 2) {
			FarCam[CamNum].SetActive (true);
            FPCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(false);
        }
        if (ViewMode == 3){
            OverlookCam[CamNum].SetActive(true);
            FarCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(false);
        }
    }
}
