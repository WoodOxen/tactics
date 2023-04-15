/**
  * @file StartManager.cs
  * @brief 控制巡线开始
  * @details  
  * 挂载该脚本的对象：RaceArea → StartManager\n
  * 需要完成以下操作：\n
  * - 初始化Cpp接口；
  * - 判断本次运行是否需要读档
  *  - 如果需要读档，则根据存档里的数据设置相应的参数；
  *  - 如果不需要读档，则只需要进行一些初始化操作；
  *  .
  * - 开启设置车辆颜色的代码；（CarColor.SetActive(true)）
  * - 开启设置不同巡线模式下UI的代码；（ModeManager.SetActive(true)）
  * - 开启切换视角功能；（ViewModeManager.SetActive(true)）
  * - 开启车辆控制的相关代码；（CarControl.SetActive (true);）
  * - 开启计时；（LapTimer.SetActive (true)）
  * - 开启车辆Speed、Steer、CruiseError的实时显示；
  * - 巡线开始前的倒计时；
  * .
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using TMPro;

public class StartManager : MonoBehaviour {
    /// 倒计时的UI 
    public GameObject CountDown;
    /// 倒计时音效 
    public AudioSource GetReady;
    /// 比赛开始音效 
    public AudioSource GoAudio;
    /// 背景音乐(暂时禁用) 
    public AudioSource BGM01;

    /// 开启各车辆控制代码的GameObject 
    public GameObject CarControl;
    /// 开启巡线计时的GameObject 
    public GameObject LapTimer;
    /// 根据仿真模式修改UI的GameObject 
    public GameObject ModeManager;
    /// 实现更换观测视角功能的GameObject 
    public GameObject ViewModeManager;
    /// 起点线触发器 
    public GameObject LapCompleteTrigger;
    /// 半途检查点触发器 
    public GameObject LapHalf;
    /// 修改各车辆颜色的GameObject 
    public GameObject CarColor;

    /// 控制显示速度的GameObject 
    public GameObject SpeedDisplayManager;
    /// 控制显示方向盘转角的GameObject 
    public GameObject SteerDisplayManager;
    /// 控制显示巡线误差的GameObject 
    public GameObject ErrorDisplayManager;
    /// 记录仿真过程中输入给车辆的控制参数的GameObject 
    public GameObject RecordOutputManager;

    /// 各车辆 
    public GameObject[] TheCar;

    private int LoadNum;

    private void RaceInitialize()
    {
        //cpp接口初始化
        CppControl.InitSpeedDelegate(CppControl.CallbackSpeedFromCpp);
        //CppControl.InitPositionXDelegate(CppControl.CallbackPositionXFromCpp);
        //CppControl.InitPositionYDelegate(CppControl.CallbackPositionYFromCpp);
        //CppControl.InitPositionZDelegate(CppControl.CallbackPositionZFromCpp);
        CppControl.InitCruiseErrorDelegate(CppControl.CallbackCruiseErrorFromCpp);
        CppControl.InitAngleErrorDelegate(CppControl.CallbackAngleErrorFromCpp);
        CppControl.InitCurvatureDelegate(CppControl.CallbackCurvatureFromCpp);
        CppControl.InitCarMoveDelegate(CppControl.GetCarMoveFromCpp);
        CppControl.InitPlayerNumDelegate(CppControl.CallbackPlayerNumFromCpp);
        CppControl.InitYawrateDelegate(CppControl.CallbackYawrateFromCpp);
        CppControl.InitMidlineDelegate(CppControl.CallbackMidlineFromCpp);
        CppControl.InitWidthDelegate(CppControl.CallbackWidthFromCpp);
        CppControl.InitAccDelegate(CppControl.CallbackAccFromCpp);

        if (!GameSetting.InitializeFlag)
        {
            //正常运行时GameSetting.InitializeFlag均为true
            //在调试时可能直接在巡线场景开始运行，因此需要在这里进行部分初始化操作
            GameSetting.InitializeFlag = true;
            GameSetting.CarType = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            GameSetting.ControlMethod = new int[8] { 0, 0, 0, 0, 2, 2, 2, 2 };

            //根据用户上次的设置，对部分参数进行初始化；如果没有用户上次设置的记录，则使用默认值
            if (PlayerPrefs.HasKey("NumofPlayer")) GameSetting.NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
            else GameSetting.NumofPlayer = 1;

            for (int i = 0; i < 8; i++)
            {
                if (PlayerPrefs.HasKey("SavedCarType" + i.ToString())) GameSetting.CarType[i] = PlayerPrefs.GetInt("SavedCarType" + i.ToString());
                else GameSetting.CarType[i] = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                if (PlayerPrefs.HasKey("SavedContorlMethod" + i.ToString())) GameSetting.ControlMethod[i] = PlayerPrefs.GetInt("SavedContorlMethod" + i.ToString());
                else GameSetting.ControlMethod[i] = 1;
            }

            if (PlayerPrefs.HasKey("SavedRaceMode")) GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
            else GameSetting.RaceMode = 1;
            if (PlayerPrefs.HasKey("SavedTrackNum")) GameSetting.trackNum = PlayerPrefs.GetInt("SavedTrackNum");
            else GameSetting.trackNum = 3;
        }
    }

    void Start () {
        RaceInitialize();

        LoadNum = LoadButton.LoadNum;
        if (LoadNum != 0)//若LoadNum != 0，则需要读取LoadNum号存档
        {
            //一些在巡线开始前就可加载的内容
            loadBefore();
        }
        else//否则不需要读档，进行一些基础的初始化
        {
            for (int i = 0; i < 4; i++)
            {
                ScoreDisplay.Score[i] = 0;
            }
        }
        /*
        for(int i = 0; i < 4; i++)
        {
            CallCppControl.steering[i] = 0;
            CallCppControl.accel[i] = 0;
            CallCppControl.footbrake[i] = 0;
            CallCppControl.handbrake[i] = 0;
        }*/

        CarColor.SetActive(true);//设置车辆颜色
        ModeManager.SetActive(true);//设置不同模式下的UI
        ViewModeManager.SetActive(true);//开启切换视角相关的代码
        RecordOutputManager.SetActive(true);//开启记录控制器输出相关的代码

        StartCoroutine (CountdownStart ());//执行倒计时程序
    }
     private void loadBefore()//在巡线开始倒计时前可以读档的参数
    {
        //初始化+获取存档
        GameSetting.ControlMethod = new int[8];
        GameSetting.CarType = new int[8];

        SaveTactic save = LoadButton.save;
        GameSetting.NumofPlayer = save.PlayNum;
        GameSetting.RaceMode = save.GameMode;
        GameSetting.trackNum = save.TrackNum;
        LoadControl.count = save.count;
        //设置参数
        for (int i = 0; i < GameSetting.NumofPlayer; i++)
        {
            GameSetting.ControlMethod[i] = save.ControlMethod[i];
            GameSetting.CarType[i] = save.CarColor[i];

            //历史残留代码
            //存档功能由“在仿真中途存档，读档后从该状态继续运行”改为“读档时复现存档中的仿真内容”
            //因此下列代码暂时废弃
            //DamageDisplay.ExtentOfDamage[i] = save.ExtentOfDamage[i];
            //DamageDisplay.CollisionNum[i] = save.CollisionNum[i];
            //TheCar[i].GetComponent<Transform>().eulerAngles = new Vector3(save.Angle[i,0], save.Angle[i,1], save.Angle[i,2]);
            //TheCar[i].GetComponent<Transform>().position = new Vector3(save.Position[i,0], save.Position[i,1], save.Position[i,2]);
            //HalfPointTrigger.HalfFlag[i] = save.HalfFlag[i];
            //LapComplete.LapFlag[i] = !save.HalfFlag[i];
            //LapComplete.LapCount[i] = save.lapNum[i];
        }
        /*
        if (save.GameMode == 2)
        {
            CurrentScore.Score[0] = save.score[0];
            CurrentScore.Score[1] = save.score[1];
            CurrentScore.Score[2] = save.score[2];
            CurrentScore.Score[3] = save.score[3];
        }
        else
        {
            LapTimeManager.MinuteCount = save.min;
            LapTimeManager.SecondCount = save.sec;
            LapTimeManager.MilliCount = save.milli;
        }
        */
    }

    /*
    //历史残留代码
    //存档功能由“在仿真中途存档，读档后从该状态继续运行”改为“读档时复现存档中的仿真内容”
    //因此下列代码暂时废弃
    private void loadAfter()//巡线开始倒计时后再读档的参数
    {
        if (LoadNum != 0)//若LoadNum != 0则表示需要读档
        {
            SaveTactic save = LoadButton.save;
            for(int i = 0; i < 4; i++)
            {
                //TheCar[i].GetComponent<Rigidbody>().velocity = new Vector3(save.Speed[i,0], save.Speed[i,1], save.Speed[i,2]);
                //CarUserControl.h[i] = save.steer[i];
                //CarUserControl.v[i] = save.accel[i];
                //CarUserControl.v[i] = save.footbrake[i];
                //CarUserControl.handbrake[i] = save.handbrake[i];
            }
        }
    }*/

    //巡线开始时的倒数321程序，执行完成后调用loadAfter()函数
    IEnumerator CountdownStart(){
        yield return new WaitForSeconds (0.5f);
        CountDown.GetComponent<TextMeshProUGUI> ().text = "3";
        GetReady.Play ();
        CountDown.SetActive (true);
        yield return new WaitForSeconds (1);
        CountDown.SetActive (false);
        CountDown.GetComponent<TextMeshProUGUI> ().text = "2";
        GetReady.Play ();
        CountDown.SetActive (true);
        yield return new WaitForSeconds (1);
        CountDown.SetActive (false);
        CountDown.GetComponent<TextMeshProUGUI> ().text = "1";
        GetReady.Play ();
        CountDown.SetActive (true);
        yield return new WaitForSeconds (1);
        CountDown.SetActive (false);
        GoAudio.Play ();
        //BGM01.Play ();//若需要播放关卡BGM，则取消这行的注释

        //开启Speed、Steer、CruiseError的显示
        SpeedDisplayManager.SetActive(true);
        SteerDisplayManager.SetActive(true);
        ErrorDisplayManager.SetActive(true);

        LapTimer.SetActive(true);
        CarControl.SetActive(true);

        //loadAfter();
    }
}
