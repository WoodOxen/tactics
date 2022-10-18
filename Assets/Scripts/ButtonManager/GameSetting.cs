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

    public GameObject CSDropDown1;
    public GameObject CSDropDown2;
    public GameObject CSDropDown3;
    public GameObject CSDropDown4;//CarSelection部分的四个DropDown

    public GameObject CMDropDown1;
    public GameObject CMDropDown2;
    public GameObject CMDropDown3;
    public GameObject CMDropDown4;//ControlMethod部分的四个DropDown


    void Start()
    {
        //初始化
        CarType = new int[5];
        ControlMethod = new int[5];
        PlayerNumofCarSelect = 0;
        PlayerNumofControlMethod = 0;

        //根据用户上次的设置，对部分参数进行初始化；如果没有用户上次设置的记录，则使用默认值
        if (PlayerPrefs.HasKey("NumofPlayer")) NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
        else NumofPlayer = 1;

        if (PlayerPrefs.HasKey("SavedCarType0")) CarType[0] = PlayerPrefs.GetInt("SavedCarType0");
        else CarType[0] = 0;
        if (PlayerPrefs.HasKey("SavedCarType1")) CarType[1] = PlayerPrefs.GetInt("SavedCarType1");
        else CarType[1] = 0;
        if (PlayerPrefs.HasKey("SavedCarType2")) CarType[2] = PlayerPrefs.GetInt("SavedCarType2");
        else CarType[2] = 0;
        if (PlayerPrefs.HasKey("SavedCarType3")) CarType[3] = PlayerPrefs.GetInt("SavedCarType3");
        else CarType[3] = 0;

        if (PlayerPrefs.HasKey("SavedContorlMethod0")) ControlMethod[0] = PlayerPrefs.GetInt("SavedContorlMethod0");
        else ControlMethod[0] = 1;
        if (PlayerPrefs.HasKey("SavedContorlMethod1")) ControlMethod[1] = PlayerPrefs.GetInt("SavedContorlMethod1");
        else ControlMethod[1] = 1;
        if (PlayerPrefs.HasKey("SavedContorlMethod2")) ControlMethod[2] = PlayerPrefs.GetInt("SavedContorlMethod2");
        else ControlMethod[2] = 1;
        if (PlayerPrefs.HasKey("SavedContorlMethod3")) ControlMethod[3] = PlayerPrefs.GetInt("SavedContorlMethod3");
        else ControlMethod[3] = 1;

        if (PlayerPrefs.HasKey("SavedRaceMode")) RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
        else RaceMode = 1;
        if (PlayerPrefs.HasKey("SavedTrackNum")) trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        else trackNum = 3;
    }
    void Update()
    {
        //根据用户选择的NumofPlayer，SetActive对应的DropDown
        //例如，当用户选择两辆车参与仿真（NumofPlayer=2），那么需要让用户可以分别设置两辆车的颜色和控制方式，
        //因此在CarSelection和ControlMethod两处的DropDown需要提供Player1和Player2两个选项，需要SetActive对应的DropDown
        if (NumofPlayer == 2)
        {
            CSDropDown1.SetActive(false);
            CSDropDown2.SetActive(true);
            CSDropDown3.SetActive(false);
            CSDropDown4.SetActive(false);
            CMDropDown1.SetActive(false);
            CMDropDown2.SetActive(true);
            CMDropDown3.SetActive(false);
            CMDropDown4.SetActive(false);
        }
        else if (NumofPlayer == 3)
        {
            CSDropDown1.SetActive(false);
            CSDropDown2.SetActive(false);
            CSDropDown3.SetActive(true);
            CSDropDown4.SetActive(false);
            CMDropDown1.SetActive(false);
            CMDropDown2.SetActive(false);
            CMDropDown3.SetActive(true);
            CMDropDown4.SetActive(false);
        }
        else if (NumofPlayer == 4)
        {
            CSDropDown1.SetActive(false);
            CSDropDown2.SetActive(false);
            CSDropDown3.SetActive(false);
            CSDropDown4.SetActive(true);
            CMDropDown1.SetActive(false);
            CMDropDown2.SetActive(false);
            CMDropDown3.SetActive(false);
            CMDropDown4.SetActive(true);
        }
        else
        {
            CSDropDown1.SetActive(true);
            CSDropDown2.SetActive(false);
            CSDropDown3.SetActive(false);
            CSDropDown4.SetActive(false);
            CMDropDown1.SetActive(true);
            CMDropDown2.SetActive(false);
            CMDropDown3.SetActive(false);
            CMDropDown4.SetActive(false);
        }
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
    }
    public void TwoPlayer()
    {
        NumofPlayer = 2;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
    }
    public void ThreePlayer()
    {
        NumofPlayer = 3;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
    }
    public void FourPlayer()
    {
        NumofPlayer = 4;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
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
