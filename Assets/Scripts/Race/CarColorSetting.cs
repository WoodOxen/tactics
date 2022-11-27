using UnityEngine;
using System.Collections;

public class CarColorSetting : MonoBehaviour {

	public GameObject RedBody;
	public GameObject BlueBody;
	public GameObject YellowBody;
	public GameObject GreenBody;
	public GameObject WhiteBody;
    public GameObject BlackBody;

    public GameObject RedBody2;
    public GameObject BlueBody2;
    public GameObject YellowBody2;
    public GameObject GreenBody2;
    public GameObject WhiteBody2;
    public GameObject BlackBody2;

    public GameObject RedBody3;
    public GameObject BlueBody3;
    public GameObject YellowBody3;
    public GameObject GreenBody3;
    public GameObject WhiteBody3;
    public GameObject BlackBody3;

    public GameObject RedBody4;
    public GameObject BlueBody4;
    public GameObject YellowBody4;
    public GameObject GreenBody4;
    public GameObject WhiteBody4;
    public GameObject BlackBody4;

    public int CarImport;
    private int PlayerNum;

	// Use this for initialization
	void Start () { 
        if (!GameSetting.InitializeFlag)
        {
            //正常运行时GameSetting.InitializeFlag均为true
            //在调试时可能直接在巡线场景开始运行，因此需要在这里进行部分初始化操作
            Debug.Log("InitializeFlag=true");
            GameSetting.InitializeFlag = true;
            GameSetting.CarType = new int[5];
            GameSetting.ControlMethod = new int[5];

            //根据用户上次的设置，对部分参数进行初始化；如果没有用户上次设置的记录，则使用默认值
            if (PlayerPrefs.HasKey("NumofPlayer")) GameSetting.NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
            else GameSetting.NumofPlayer = 1;

            if (PlayerPrefs.HasKey("SavedCarType0")) GameSetting.CarType[0] = PlayerPrefs.GetInt("SavedCarType0");
            else GameSetting.CarType[0] = 0;
            if (PlayerPrefs.HasKey("SavedCarType1")) GameSetting.CarType[1] = PlayerPrefs.GetInt("SavedCarType1");
            else GameSetting.CarType[1] = 0;
            if (PlayerPrefs.HasKey("SavedCarType2")) GameSetting.CarType[2] = PlayerPrefs.GetInt("SavedCarType2");
            else GameSetting.CarType[2] = 0;
            if (PlayerPrefs.HasKey("SavedCarType3")) GameSetting.CarType[3] = PlayerPrefs.GetInt("SavedCarType3");
            else GameSetting.CarType[3] = 0;

            if (PlayerPrefs.HasKey("SavedContorlMethod0")) GameSetting.ControlMethod[0] = PlayerPrefs.GetInt("SavedContorlMethod0");
            else GameSetting.ControlMethod[0] = 1;
            if (PlayerPrefs.HasKey("SavedContorlMethod1")) GameSetting.ControlMethod[1] = PlayerPrefs.GetInt("SavedContorlMethod1");
            else GameSetting.ControlMethod[1] = 1;
            if (PlayerPrefs.HasKey("SavedContorlMethod2")) GameSetting.ControlMethod[2] = PlayerPrefs.GetInt("SavedContorlMethod2");
            else GameSetting.ControlMethod[2] = 1;
            if (PlayerPrefs.HasKey("SavedContorlMethod3")) GameSetting.ControlMethod[3] = PlayerPrefs.GetInt("SavedContorlMethod3");
            else GameSetting.ControlMethod[3] = 1;

            if (PlayerPrefs.HasKey("SavedRaceMode")) GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
            else GameSetting.RaceMode = 1;
            if (PlayerPrefs.HasKey("SavedTrackNum")) GameSetting.trackNum = PlayerPrefs.GetInt("SavedTrackNum");
            else GameSetting.trackNum = 3;
        }

        PlayerNum = GameSetting.NumofPlayer;
        //Set P1 CarColor
        CarImport = GameSetting.CarType[0];
        if (CarImport == 1) RedBody.SetActive(true);
        else if (CarImport == 2) BlueBody.SetActive(true);
        else if (CarImport == 3) YellowBody.SetActive(true);
        else if (CarImport == 4) GreenBody.SetActive(true);
        else if (CarImport == 5) BlackBody.SetActive(true);
        else WhiteBody.SetActive(true);

        if (PlayerNum > 1)
        {
            //Set P2 CarColor
            CarImport = GameSetting.CarType[1];
            if (CarImport == 1) RedBody2.SetActive(true);
            else if (CarImport == 2) BlueBody2.SetActive(true);
            else if (CarImport == 3) YellowBody2.SetActive(true);
            else if (CarImport == 4) GreenBody2.SetActive(true);
            else if (CarImport == 5) BlackBody2.SetActive(true);
            else WhiteBody2.SetActive(true);
        }
        if (PlayerNum > 2)
        {
            //Set P3 CarColor
            CarImport = GameSetting.CarType[2];
            if (CarImport == 1) RedBody3.SetActive(true);
            else if (CarImport == 2) BlueBody3.SetActive(true);
            else if (CarImport == 3) YellowBody3.SetActive(true);
            else if (CarImport == 4) GreenBody3.SetActive(true);
            else if (CarImport == 5) BlackBody3.SetActive(true);
            else WhiteBody3.SetActive(true);
        }
        if(PlayerNum > 3)
        {
            //Set P3 CarColor
            CarImport = GameSetting.CarType[3];
            if (CarImport == 1) RedBody4.SetActive(true);
            else if (CarImport == 2) BlueBody4.SetActive(true);
            else if (CarImport == 3) YellowBody4.SetActive(true);
            else if (CarImport == 4) GreenBody4.SetActive(true);
            else if (CarImport == 5) BlackBody4.SetActive(true);
            else WhiteBody4.SetActive(true);
        }
    }
}
