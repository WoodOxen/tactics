using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RaceFinish : MonoBehaviour {

	public GameObject PlayerCar;
	public GameObject CompleteTrig;
	public AudioSource FinishBGM;
	public GameObject FinishCam;
	public GameObject DrivingCam;
	public GameObject levelBGM;
	public GameObject CarOthers;
    public GameObject TimeManager;

    public GameObject CompletePanel;
    public GameObject ScoreModeLabel;
    public GameObject TimeModeLabel;
    public GameObject ScoreDisplay;
    public GameObject TimeDisplay;
    public GameObject CollisionNumDisplay;
    public GameObject TotalDamageDisplay;
    public GameObject GradeDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    private int RaceMode;

    // Use this for initialization
    void Start() {
        PlayerCar.SetActive (false);
		CompleteTrig.SetActive (false);
		CarOthers.SetActive (false);
		//CarController.m_Topspeed = 0.0f;
		PlayerCar.GetComponent<CarAudio> ().enabled = false;
		PlayerCar.GetComponent<CarController> ().enabled = false;
		PlayerCar.GetComponent<CarUserControl> ().enabled = false;



		CashDisplay.TotalCash += 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);

		//DrivingCam.SetActive (false);
		PlayerCar.SetActive (true);
		//FinishCam.SetActive (true);
		levelBGM.SetActive (false);
       

        FinishBGM.Play ();


        CompletePanel.SetActive(true);
        RaceMode = GameSetting.RaceMode;
        CollisionNumDisplay.GetComponent<TextMeshProUGUI>().text = "" + DamageDisplay.CollisionNum;
        TotalDamageDisplay.GetComponent<TextMeshProUGUI>().text = "" + DamageDisplay.ExtentOfDamage;

        //we need a algorithm to calculate the grade
        GradeDisplay.GetComponent<TextMeshProUGUI>().text = "coming soon";

        if (RaceMode == 2)
        {
            ScoreModeLabel.SetActive(true);
            ScoreDisplay.SetActive(true);
            ScoreDisplay.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore;
        }
        else
        {
            TimeModeLabel.SetActive(true);
            TimeDisplay.SetActive(true);
            TimeDisplay.GetComponent<TextMeshProUGUI>().text = "" + MinuteBox.GetComponent<TextMeshProUGUI>().text + SecondBox.GetComponent<TextMeshProUGUI>().text + MilliBox.GetComponent<TextMeshProUGUI>().text;
            //+ ":" + LapTimeManager.SecondCount + "." + LapTimeManager.MilliCount;
            LapTimeManager.rawtime = 0;
            LapTimeManager.MinuteCount = 0;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MilliCount = 0;
            TimeManager.SetActive(false);
        }
        
        //StartCoroutine (EndofRace ());
    }

    /*
	IEnumerator EndofRace(){
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene (0);
	}*/
	

}
