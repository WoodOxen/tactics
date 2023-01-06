/**
  * @file GameSetting.cs
  * @brief 在TrackSelect界面按下不同按钮所执行的函数
  * @details 
  * 挂载该脚本的对象：TrackSelect → GameSettingManager \n
  * 该脚本储存着用户对仿真的各项设置。 \n
  * 除此之外，用户在进入TrackSelect场景后，还会调用该脚本的Start()函数，对部分参数进行初始化。 \n
  * 用户在进行部分设置后，需要通过PlayerPrefs类储存用户的历史选择。 \n
  * Monitor的设置是单独实现在MonitorSetting.cs里的。 \n
  * @param CarType 各车辆的颜色设置
  * @param RaceMode 仿真模式
  * @param trackNum 赛道编号
  * @param ControlMethod 各车辆的控制方式设置
  * @param NumofPlayer 车辆数目
  * @param PlayerNumofCarSelect 用户想要设置几号车辆的颜色
  * @param PlayerNumofControlMethod 用户想要设置几号车辆的控制方式
  * @author 李雨航
  * @date 2023-12-31
  */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSetting : MonoBehaviour {
    /// 车辆颜色1=red,2=blue,3=yellow,4=green 
    public static int[] CarType;
    /// 巡线模式1=time,2=score 
    public static int RaceMode;
    /// 赛道编号 
    public static int trackNum;
    /// 各车辆的控制方式 
    public static int []ControlMethod;
    /// 参与仿真的车辆数目 
    public static int NumofPlayer;
    
    /// 用户想要设置几号车辆的颜色 
    public static int PlayerNumofCarSelect;
    /// 用户想要设置几号车辆的控制方式 
    public static int PlayerNumofControlMethod;

    /// 提示用户对CarColor的设置不合理的文字信息UI 
    public GameObject Warning_CS;
    /// 提示用户对ControlMethod的设置不合理的文字信息UI 
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

    /**
     * @fn WhetherWarning
     * @brief 提示用户对CarColor和ControlMethod的设置不合理
     * @details 若用户对CarColor和ControlMethod的设置超过了其选择的车辆数目，则提示用户该车不会存在
     */
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

    /**
     * @fn MainMenu
     * @brief 回到主菜单
     */
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //TrackSelection
    //记录用户的历史选择到"SavedTrackNum"
    /**
     * @fn Track01
     * @brief 选择1号赛道
     */
    public void Track01()
    {
        GameSetting.trackNum = 1;
        PlayerPrefs.SetInt("SavedTrackNum", 1);
    }
    /**
     * @fn Track02
     * @brief 选择2号赛道
     */
    public void Track02()
    {
        GameSetting.trackNum = 2;
        PlayerPrefs.SetInt("SavedTrackNum", 2);
    }
    /**
     * @fn Track03
     * @brief 选择3号赛道
     */
    public void Track03()
    {
        GameSetting.trackNum = 3;
        PlayerPrefs.SetInt("SavedTrackNum", 3);
    }

    //CarSelection
    //记录用户的历史选择到"SavedCarType"
    /**
     * @fn SetPlayerNumofCarSelect
     * @brief 确定用户想要设置几号车辆的颜色
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户在设置车辆颜色时，可以通过dropdown(下拉式菜单)选择自己要设置几号车辆的颜色\n
     * 将该值存为PlayerNumofCarSelect参数
     */
    public void SetPlayerNumofCarSelect(int value)
    {
        PlayerNumofCarSelect = value;
        WhetherWarning();
    }
    /**
     * @fn RedCar
     * @brief 设置车辆颜色为红色
     * @details 设置第PlayerNumofCarSelect号车辆的颜色
     */
    public void RedCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":1");
        CarType[PlayerNumofCarSelect] = 1;
        PlayerPrefs.SetInt("SavedCarType"+PlayerNumofCarSelect.ToString(), 1);
    }
    /**
     * @fn BlueCar
     * @brief 设置车辆颜色为蓝色
     * @details 设置第PlayerNumofCarSelect号车辆的颜色
     */
    public void BlueCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":2");
        CarType[PlayerNumofCarSelect] = 2;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 2);
    }
    /**
     * @fn YellowCar
     * @brief 设置车辆颜色为黄色
     * @details 设置第PlayerNumofCarSelect号车辆的颜色
     */
    public void YellowCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":3");
        CarType[PlayerNumofCarSelect] = 3;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 3);
    }
    /**
     * @fn GreenCar
     * @brief 设置车辆颜色为绿色
     * @details 设置第PlayerNumofCarSelect号车辆的颜色
     */
    public void GreenCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":4");
        CarType[PlayerNumofCarSelect] = 4;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 4);
    }
    /**
     * @fn WhiteCar
     * @brief 设置车辆颜色为白色
     * @details 设置第PlayerNumofCarSelect号车辆的颜色
     */
    public void WhiteCar()
    {
        Debug.Log(PlayerNumofCarSelect.ToString() + ":0");
        CarType[PlayerNumofCarSelect] = 0;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 0);
    }
    /**
     * @fn BlackCar
     * @brief 设置车辆颜色为黑色
     * @details 设置第PlayerNumofCarSelect号车辆的颜色
     */
    public void BlackCar()
    {
        Debug.Log(PlayerNumofCarSelect.ToString() + ":5");
        CarType[PlayerNumofCarSelect] = 5;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 5);
    }

    //ModeSelection
    //记录用户的历史选择到"SavedRaceMode"
    /**
     * @fn TimeMode
     * @brief 设置仿真模式为竞速模式
     */
    public void TimeMode(){
        RaceMode = 1;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
    }
    /**
     * @fn ScoreMode
     * @brief 设置仿真模式为得分模式
     */
    public void ScoreMode(){
        RaceMode = 2;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);
    }

    //Number of Players
    //记录用户的历史选择到"NumofPlayer"
    /**
     * @fn OnePlayer
     * @brief 设置车辆数目为1
     */
    public void OnePlayer()
    {
        NumofPlayer = 1;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn TwoPlayer
     * @brief 设置车辆数目为2
     */
    public void TwoPlayer()
    {
        NumofPlayer = 2;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn ThreePlayer
     * @brief 设置车辆数目为3
     */
    public void ThreePlayer()
    {
        NumofPlayer = 3;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn FourPlayer
     * @brief 设置车辆数目为4
     */
    public void FourPlayer()
    {
        NumofPlayer = 4;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn FivePlayer
     * @brief 设置车辆数目为5
     */
    public void FivePlayer()
    {
        NumofPlayer = 5;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn SixPlayer
     * @brief 设置车辆数目为6
     */
    public void SixPlayer()
    {
        NumofPlayer = 6;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn SevenPlayer
     * @brief 设置车辆数目为7
     */
    public void SevenPlayer()
    {
        NumofPlayer = 7;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }
    /**
     * @fn EightPlayer
     * @brief 设置车辆数目为8
     */
    public void EightPlayer()
    {
        NumofPlayer = 8;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
        WhetherWarning();
    }

    //Image Quality
    //不记录用户的历史选择
    /**
     * @fn High
     * @brief 设置画面质量为高
     */
    public void High()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
    /**
     * @fn Medium
     * @brief 设置画面质量为中
     */
    public void Medium()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    /**
     * @fn Low
     * @brief 设置画面质量为低
     */
    public void Low()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    //ControlMethod
    //记录用户的历史选择到"SavedContorlMethod"
    /**
     * @fn SetPlayerNumofControlMethod
     * @brief 确定用户想要设置几号车辆的控制方式
     * @param[in] value 用户在相应的dropdown中选择的选项编号。
     * @details 用户在设置车辆控制方式时，可以通过dropdown(下拉式菜单)选择自己要设置几号车辆的控制方式\n
     * 将该值存为PlayerNumofControlMethod参数
     */
    public void SetPlayerNumofControlMethod(int value)
    {
        PlayerNumofControlMethod = value;
        WhetherWarning();
    }
    /**
     * @fn Keyboard
     * @brief 设置车辆控制方式为键盘控制
     * @details 设置第PlayerNumofControlMethod号车辆的控制方式
     */
    public void Keyboard()
    {
        ControlMethod[PlayerNumofControlMethod] = 1;
        PlayerPrefs.SetInt("SavedContorlMethod" + PlayerNumofControlMethod.ToString(), 1);
    }
    /**
     * @fn Script
     * @brief 设置车辆控制方式为代码控制
     * @details 设置第PlayerNumofControlMethod号车辆的控制方式
     */
    public void Script()
    {
        ControlMethod[PlayerNumofControlMethod] = 2;
        PlayerPrefs.SetInt("SavedContorlMethod" + PlayerNumofControlMethod.ToString(), 2);
    }

    //开始仿真
    /**
     * @fn Play
     * @brief 开始仿真
     */
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
