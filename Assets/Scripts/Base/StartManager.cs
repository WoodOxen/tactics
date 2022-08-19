using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

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

    public GameObject[] TheCar;

    private int LoadNum;

    void Start () {
        //cpp接口初始化
        CppControl.InitSpeedDelegate(CppControl.CallbackSpeedFromCpp);
        CppControl.InitPositionXDelegate(CppControl.CallbackPositionXFromCpp);
        CppControl.InitPositionYDelegate(CppControl.CallbackPositionYFromCpp);
        CppControl.InitPositionZDelegate(CppControl.CallbackPositionZFromCpp);
        CppControl.InitCruiseErrorDelegate(CppControl.CallbackCruiseErrorFromCpp);
        CppControl.InitAngleErrorDelegate(CppControl.CallbackAngleErrorFromCpp);
        CppControl.InitCurvatureDelegate(CppControl.CallbackCurvatureFromCpp);
        //CppControl.InitCSharpDelegate(CppControl.LogMessageFromCpp);
        CppControl.InitCarMoveDelegate(CppControl.GetCarMoveFromCpp);
        CppControl.InitPlayerNumDelegate(CppControl.CallbackPlayerNumFromCpp);



        LoadNum = LoadButton.LoadNum;
        if (LoadNum != 0)//需要读取LoadNum号存档
        {
            loadBefore();
        }
        else
        {
            GameModeManager.CurrentScore1 = 0;
            GameModeManager.CurrentScore2 = 0;
            GameModeManager.CurrentScore3 = 0;
            GameModeManager.CurrentScore4 = 0;
        }

        for(int i = 0; i < 4; i++)
        {
            CallCppControl.steering[i] = 0;
            CallCppControl.accel[i] = 0;
            CallCppControl.footbrake[i] = 0;
            CallCppControl.handbrake[i] = 0;
        }

        //SimulationSetting.SetActive(true);
        CarColor.SetActive(true);
        ModeManager.SetActive(true);
        ViewModeManager.SetActive(true);

        StartCoroutine (CountdownStart ());
    }
     private void loadBefore()
    {
        //初始化+获取存档
        GameSetting.ControlMethod = new int[5];
        GameSetting.CarType = new int[5];
        SaveTactic save = LoadButton.save;
        //设置参数
        for(int i = 0; i < 4; i++)
        {
            GameSetting.ControlMethod[i] = save.ControlMethod[i];
            TheCar[i].GetComponent<Transform>().eulerAngles = new Vector3(save.Angle[i,0], save.Angle[i,1], save.Angle[i,2]);
            TheCar[i].GetComponent<Transform>().position = new Vector3(save.Position[i,0], save.Position[i,1], save.Position[i,2]);
            GameSetting.CarType[i] = save.CarColor[i];
        }

        GameSetting.NumofPlayer = save.PlayNum;
        GameSetting.RaceMode = save.GameMode;
        GameSetting.trackNum = save.TrackNum;
        DamageDisplay1.ExtentOfDamage = save.ExtentOfDamage[0];
        DamageDisplay1.CollisionNum = save.CollisionNum[0];
        DamageDisplay2.ExtentOfDamage = save.ExtentOfDamage[1];
        DamageDisplay2.CollisionNum = save.CollisionNum[1];
        DamageDisplay3.ExtentOfDamage = save.ExtentOfDamage[2];
        DamageDisplay3.CollisionNum = save.CollisionNum[2];
        DamageDisplay4.ExtentOfDamage = save.ExtentOfDamage[3];
        DamageDisplay4.CollisionNum = save.CollisionNum[3];

        HalfPointTrigger.HalfFlag1 = save.HalfFlag[0];
        LapComplete.LapFlag1 = !save.HalfFlag[0];
        HalfPointTrigger.HalfFlag2 = save.HalfFlag[1];
        LapComplete.LapFlag2 = !save.HalfFlag[1];
        HalfPointTrigger.HalfFlag3 = save.HalfFlag[2];
        LapComplete.LapFlag3 = !save.HalfFlag[2];
        HalfPointTrigger.HalfFlag4 = save.HalfFlag[3];
        LapComplete.LapFlag4 = !save.HalfFlag[3];

        LapComplete.LapCount1 = save.lapNum[0];
        LapComplete.LapCount2 = save.lapNum[1];
        LapComplete.LapCount3 = save.lapNum[2];
        LapComplete.LapCount4 = save.lapNum[3];

        if (save.GameMode == 2)
        {
            GameModeManager.CurrentScore1 = save.score[0];
            GameModeManager.CurrentScore2 = save.score[1];
            GameModeManager.CurrentScore3 = save.score[2];
            GameModeManager.CurrentScore4 = save.score[3];
        }
        else
        {
            LapTimeManager.MinuteCount = save.min;
            LapTimeManager.SecondCount = save.sec;
            LapTimeManager.MilliCount = save.milli;
        }
    }

    private void loadAfter()
    {
        if (LoadNum != 0)
        {
            SaveTactic save = LoadButton.save;
            for(int i = 0; i < 4; i++)
            {
                TheCar[i].GetComponent<Rigidbody>().velocity = new Vector3(save.Speed[i,0], save.Speed[i,1], save.Speed[i,2]);
            }
            CarUserControl.h = save.steer[0];
            CarUserControl.v = save.accel[0];
            CarUserControl.v = save.footbrake[0];
            CarUserControl.handbrake = save.handbrake[0];

            CarUserControl2.h = save.steer[1];
            CarUserControl2.v = save.accel[1];
            CarUserControl2.v = save.footbrake[1];
            CarUserControl2.handbrake = save.handbrake[1];

            CarUserControl3.h = save.steer[2];
            CarUserControl3.v = save.accel[2];
            CarUserControl3.v = save.footbrake[2];
            CarUserControl3.handbrake = save.handbrake[2];

            CarUserControl4.h = save.steer[3];
            CarUserControl4.v = save.accel[3];
            CarUserControl4.v = save.footbrake[3];
            CarUserControl4.handbrake = save.handbrake[3];

        }
    }

    //倒数321
    IEnumerator CountdownStart(){
		yield return new WaitForSeconds (0.5f);
		CountDown.GetComponent<Text> ().text = "3";
		GetReady.Play ();
		CountDown.SetActive (true);
		yield return new WaitForSeconds (1);
		CountDown.SetActive (false);
		CountDown.GetComponent<Text> ().text = "2";
		GetReady.Play ();
		CountDown.SetActive (true);
		yield return new WaitForSeconds (1);
		CountDown.SetActive (false);
		CountDown.GetComponent<Text> ().text = "1";
		GetReady.Play ();
		CountDown.SetActive (true);
		yield return new WaitForSeconds (1);
		CountDown.SetActive (false);
		GoAudio.Play ();
		//BGM01.Play ();
		LapTimer.SetActive (true);
		CarControl.SetActive (true);

        loadAfter();
	}
}
