using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using TMPro;

public class StartManager : MonoBehaviour {

	public GameObject CountDown;
	public AudioSource GetReady;
	public AudioSource GoAudio;
	public AudioSource BGM01;
	public GameObject CarControl;
	public GameObject LapTimer;
    
    public GameObject ModeManager;
    public GameObject ViewModeManager;
    public GameObject LapCompleteTrigger;
    public GameObject LapHalf;
    public GameObject CarColor;

    public GameObject SpeedDisplayManager;
    public GameObject SteerDisplayManager;
    public GameObject ErrorDisplayManager;
    public GameObject RecordOutputManager;

    public GameObject[] TheCar;

    private int LoadNum;

    private void CppApiInitialize()
    {
        //cpp接口初始化
        CppControl.InitSpeedDelegate(CppControl.CallbackSpeedFromCpp);
        CppControl.InitPositionXDelegate(CppControl.CallbackPositionXFromCpp);
        CppControl.InitPositionYDelegate(CppControl.CallbackPositionYFromCpp);
        CppControl.InitPositionZDelegate(CppControl.CallbackPositionZFromCpp);
        CppControl.InitCruiseErrorDelegate(CppControl.CallbackCruiseErrorFromCpp);
        CppControl.InitAngleErrorDelegate(CppControl.CallbackAngleErrorFromCpp);
        CppControl.InitCurvatureDelegate(CppControl.CallbackCurvatureFromCpp);
        CppControl.InitCarMoveDelegate(CppControl.GetCarMoveFromCpp);
        CppControl.InitPlayerNumDelegate(CppControl.CallbackPlayerNumFromCpp);
    }

    void Start () {
        CppApiInitialize();

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
                CurrentScore.Score[i] = 0;
            }
        }

        for(int i = 0; i < 4; i++)
        {
            CallCppControl.steering[i] = 0;
            CallCppControl.accel[i] = 0;
            CallCppControl.footbrake[i] = 0;
            CallCppControl.handbrake[i] = 0;
        }

        CarColor.SetActive(true);//设置车辆颜色
        ModeManager.SetActive(true);//设置不同模式下的UI
        ViewModeManager.SetActive(true);//开启切换视角相关的代码
        RecordOutputManager.SetActive(true);//开启记录控制器输出相关的代码

        StartCoroutine (CountdownStart ());//执行倒计时程序
    }
     private void loadBefore()//在巡线开始倒计时前可以读档的参数
    {
        //初始化+获取存档
        GameSetting.ControlMethod = new int[5];
        GameSetting.CarType = new int[5];

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
