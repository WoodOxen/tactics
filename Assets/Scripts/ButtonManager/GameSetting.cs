using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSetting : MonoBehaviour {

	public static int[] CarType;//车辆颜色1=red,2=blue,3=yellow,4=green
    public static int RaceMode;//巡线模式1=time,2=score
    public static int trackNum;//赛道编号
    public static int []ControlMethod;//各车辆的控制方式
    public static int NumofPlayer;//参与仿真的车辆数目

    public static int PlayerNumofCarSelect;//用户想要设置几号车辆的颜色
    public static int PlayerNumofControlMethod;//用户想要设置几号车辆的控制方式

    public GameObject Warning_CS;
    public GameObject Warning_CM;


    public static bool InitializeFlag = false;

    void Start()
    {
        //初始化
        InitializeFlag = true;
        CarType = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        ControlMethod = new int[8] { 0, 0, 0, 0, 2, 2, 2, 2 };
        PlayerNumofCarSelect = 0;
        PlayerNumofControlMethod = 0;

        //根据用户上次的设置，对部分参数进行初始化；如果没有用户上次设置的记录，则使用默认值
        if (PlayerPrefs.HasKey("NumofPlayer")) NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
        else NumofPlayer = 1;

        for(int i = 0;i < 8;i++)
        {
            if (PlayerPrefs.HasKey("SavedCarType"+i.ToString())) CarType[i] = PlayerPrefs.GetInt("SavedCarType" + i.ToString());
            else CarType[i] = 0;
        }
        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.HasKey("SavedContorlMethod" + i.ToString())) ControlMethod[i] = PlayerPrefs.GetInt("SavedContorlMethod" + i.ToString());
            else ControlMethod[i] = 1;
        }
        
        if (PlayerPrefs.HasKey("SavedRaceMode")) RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
        else RaceMode = 1;
        if (PlayerPrefs.HasKey("SavedTrackNum")) trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        else trackNum = 3;
    }
    void WhetherWarning()
    {
        //若用户对CarColor和ControlMethod的设置超过了其选择的车辆数目，则提示用户该车不会存在
        if (PlayerNumofControlMethod >= NumofPlayer)
            Warning_CM.SetActive(true);
        else Warning_CM.SetActive(false);

        if (PlayerNumofCarSelect >= NumofPlayer)
            Warning_CS.SetActive(true);
        else Warning_CS.SetActive(false);
    }

    //回到主菜单
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //TrackSelection
    //记录用户的历史选择到"SavedTrackNum"
    public void Track01()
    {
        GameSetting.trackNum = 1;
        PlayerPrefs.SetInt("SavedTrackNum", 1);
    }
    public void Track02()
    {
        GameSetting.trackNum = 2;
        PlayerPrefs.SetInt("SavedTrackNum", 2);
    }
    public void Track03()
    {
        GameSetting.trackNum = 3;
        PlayerPrefs.SetInt("SavedTrackNum", 3);
    }

    //CarSelection
    //记录用户的历史选择到"SavedCarType"
    public void SetPlayerNumofCarSelect(int value)
    {
        PlayerNumofCarSelect = value;
        WhetherWarning();
    }
    public void RedCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":1");
        CarType[PlayerNumofCarSelect] = 1;
        PlayerPrefs.SetInt("SavedCarType"+PlayerNumofCarSelect.ToString(), 1);
	}
	public void BlueCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":2");
        CarType[PlayerNumofCarSelect] = 2;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 2);
    }
    public void YellowCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":3");
        CarType[PlayerNumofCarSelect] = 3;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 3);
    }
    public void GreenCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":4");
        CarType[PlayerNumofCarSelect] = 4;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 4);
    }
    public void WhiteCar()
    {
        Debug.Log(PlayerNumofCarSelect.ToString() + ":0");
        CarType[PlayerNumofCarSelect] = 0;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 0);
    }
    public void BlackCar()
    {
        Debug.Log(PlayerNumofCarSelect.ToString() + ":5");
        CarType[PlayerNumofCarSelect] = 5;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 5);
    }

    //ModeSelection
    //记录用户的历史选择到"SavedRaceMode"
    public void TimeMode(){
		RaceMode = 1;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
	}
	public void ScoreMode(){
		RaceMode = 2;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
	}

    //Number of Players
    //记录用户的历史选择到"NumofPlayer"
    public void OnePlayer()
    {
        NumofPlayer = 1;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void TwoPlayer()
    {
        NumofPlayer = 2;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void ThreePlayer()
    {
        NumofPlayer = 3;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void FourPlayer()
    {
        NumofPlayer = 4;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void FivePlayer()
    {
        NumofPlayer = 5;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void SixPlayer()
    {
        NumofPlayer = 6;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void SevenPlayer()
    {
        NumofPlayer = 7;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    public void EightPlayer()
    {
        NumofPlayer = 8;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }

    //Image Quality
    //不记录用户的历史选择
    public void High()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    public void Low()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    //ControlMethod
    //记录用户的历史选择到"SavedContorlMethod"
    public void SetPlayerNumofControlMethod(int value)
    {
        PlayerNumofControlMethod = value;
        WhetherWarning();
    }
    public void Keyboard()
    {
        ControlMethod[PlayerNumofControlMethod] = 1;
        PlayerPrefs.SetInt("SavedContorlMethod" + PlayerNumofControlMethod.ToString(), 1);
    }
    public void Script()
    {
        ControlMethod[PlayerNumofControlMethod] = 2;
        PlayerPrefs.SetInt("SavedContorlMethod" + PlayerNumofControlMethod.ToString(), 2);
    }

    //开始仿真
    public void Play(){
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
        {
            trackNum = 3;
            SceneManager.LoadScene(5);
        }
            
    }
}
