using UnityEngine;
using System.Collections;
using TMPro;

public class ViewModeManager : MonoBehaviour {
    //public GameObject[] TheCar;

    public GameObject[] NormalCam;
	public GameObject[] FarCam;
	public GameObject[] FPCam;
    public GameObject[] OverlookCam;
	public static int ViewMode = 0;//显示模式
    public static int CamNum = 0;//相机跟随的车号
    private int CamNum_last = 0;//之前相机跟随的车号
    public static int PlayerNum = 1;

    public GameObject CamNumDisplay;
    public GameObject steerDisplaybox;
    // Update is called once per frame

    void Start()
    {
        PlayerNum = GameSetting.NumofPlayer;
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
            CamNumDisplay.GetComponent<TextMeshProUGUI>().text = "P" + (CamNum+1).ToString();
            //TheCar[CamNum_last].GetComponent<AudioListener>().enabled = false;
            //TheCar[CamNum].GetComponent<AudioListener>().enabled = true;
            CamNum = CamNum % PlayerNum;
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
			//FPCam[CamNum].SetActive (false);
            //FarCam[CamNum].SetActive(false);
            OverlookCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(false);
        }
		if (ViewMode == 1) {
			FPCam[CamNum].SetActive (true);
			//FarCam[CamNum].SetActive (false);
            NormalCam[CamNum].SetActive(false);
            //OverlookCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(true);
        }
        if (ViewMode == 2) {
			FarCam[CamNum].SetActive (true);
			//NormalCam[CamNum].SetActive (false);
            FPCam[CamNum].SetActive(false);
            //OverlookCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(false);
        }
        if (ViewMode == 3)
        {
            OverlookCam[CamNum].SetActive(true);
            FarCam[CamNum].SetActive(false);
            //NormalCam[CamNum].SetActive(false);
            //FPCam[CamNum].SetActive(false);
            steerDisplaybox.SetActive(false);
        }
    }
}
