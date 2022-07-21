using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CountStart : MonoBehaviour {

	public GameObject CountDown;
	public AudioSource GetReady;
	public AudioSource GoAudio;
	public AudioSource BGM01;
	public GameObject CarControl;
	public GameObject LapTimer;
    public GameObject TheCar;
    public GameObject ModeManager;
    public GameObject LapCompleteTrigger;
    public GameObject LapHalf;
    public GameObject CarColor;

    private int LoadNum;

    void Start () {
        LoadNum = LoadButton.LoadNum;
        if (LoadNum != 0)
        {
            loadBefore();
        }
        else
        {
            GameModeManager.CurrentScore = 0;
        }
        CarColor.SetActive(true);
        ModeManager.SetActive(true);
        //PlayerPrefs.SetInt ("MinSave", 0);
		//PlayerPrefs.SetInt ("SecSave", 0);
		//PlayerPrefs.SetFloat ("MilliSave", 0);
		//PlayerPrefs.SetFloat ("RAWTIME", 0);
		StartCoroutine (CountdownStart ());
    }
     private void loadBefore()
    {
        SaveTactic save = LoadButton.save;
        TheCar.GetComponent<Transform>().eulerAngles = new Vector3(save.AngleX, save.AngleY, save.AngleZ);
        TheCar.GetComponent<Transform>().position = new Vector3(save.PositionX, save.PositionY, save.PositionZ);
        GameSetting.CarType = save.CarColor;
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
        }
    }

    private void loadAfter()
    {
        if (LoadNum != 0)
        {
            SaveTactic save = LoadButton.save;
            TheCar.GetComponent<Rigidbody>().velocity = new Vector3(save.SpeedX, save.SpeedY, save.SpeedZ);
            CarUserControl.h = save.steer;
            CarUserControl.v = save.accel;
            CarUserControl.v = save.footbrake;
            CarUserControl.handbrake = save.handbrake;
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
