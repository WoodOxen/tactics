using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StartManager : MonoBehaviour {

	public GameObject CountDown;
	public AudioSource GetReady;
	public AudioSource GoAudio;
	public AudioSource BGM01;
	public GameObject CarControl;
	public GameObject LapTimer;
    
    public GameObject ModeManager;
    public GameObject LapCompleteTrigger;
    public GameObject LapHalf;
    public GameObject CarColor;

    public GameObject TheCar1;
    public GameObject TheCar2;
    public GameObject TheCar3;
    public GameObject TheCar4;

    private int LoadNum;

    void Start () {
        //接口初始化
        CppControl.InitSpeedDelegate(CppControl.CallbackSpeedFromCpp);
        CppControl.InitPositionXDelegate(CppControl.CallbackPositionXFromCpp);
        CppControl.InitPositionYDelegate(CppControl.CallbackPositionYFromCpp);
        CppControl.InitPositionZDelegate(CppControl.CallbackPositionZFromCpp);
        CppControl.InitCruiseErrorDelegate(CppControl.CallbackCruiseErrorFromCpp);
        CppControl.InitAngleErrorDelegate(CppControl.CallbackAngleErrorFromCpp);
        CppControl.InitCurvatureDelegate(CppControl.CallbackCurvatureFromCpp);
        //CppControl.InitCSharpDelegate(CppControl.LogMessageFromCpp);
        CppControl.InitCarMoveDelegate(CppControl.GetCarMoveFromCpp);

        LoadNum = LoadButton.LoadNum;
        if (LoadNum != 0)
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
        CarColor.SetActive(true);
        ModeManager.SetActive(true);
		StartCoroutine (CountdownStart ());
    }
     private void loadBefore()
    {
        /*
        GameSetting.ControlMethod = new int[5];
        GameSetting.CarType = new int[5];
        SaveTactic save = LoadButton.save;
        GameSetting.ControlMethod[0] = save.ControlMethod1;
        GameSetting.ControlMethod[1] = save.ControlMethod2;
        GameSetting.ControlMethod[2] = save.ControlMethod3;
        GameSetting.ControlMethod[3] = save.ControlMethod4;
        TheCar1.GetComponent<Transform>().eulerAngles = new Vector3(save.AngleX[0], save.AngleY[0], save.AngleZ[0]);
        TheCar1.GetComponent<Transform>().position = new Vector3(save.PositionX[0], save.PositionY[0], save.PositionZ[0]);
        GameSetting.CarType[0] = save.CarColor1;
        GameSetting.CarType[1] = save.CarColor2;
        GameSetting.CarType[2] = save.CarColor3;
        GameSetting.CarType[3] = save.CarColor4;
        GameSetting.RaceMode = save.GameMode;
        GameSetting.trackNum = save.TrackNum;
        DamageDisplay.ExtentOfDamage = save.ExtentOfDamage;
        DamageDisplay.CollisionNum = save.CollisionNum;
        LapCompleteTrigger.SetActive(save.HalfFlag);
        LapHalf.SetActive(!save.HalfFlag);
        LapComplete.LapCount = save.lapNum;
        
        if (save.GameMode == 2)
        {
            GameModeManager.CurrentScore = save.score;
        }
        else
        {
            LapTimeManager.MinuteCount = save.min;
            LapTimeManager.SecondCount = save.sec;
            LapTimeManager.MilliCount = save.milli;
        }*/
    }

    private void loadAfter()
    {
        if (LoadNum != 0)
        {
            /*
            SaveTactic save = LoadButton.save;
            TheCar.GetComponent<Rigidbody>().velocity = new Vector3(save.SpeedX, save.SpeedY, save.SpeedZ);
            CarUserControl.h = save.steer;
            CarUserControl.v = save.accel;
            CarUserControl.v = save.footbrake;
            CarUserControl.handbrake = save.handbrake;
            */
        }
    }

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
