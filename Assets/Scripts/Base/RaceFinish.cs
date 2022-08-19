using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RaceFinish : MonoBehaviour {

	public GameObject[] PlayerCar;
	public GameObject CompleteTrig;
	public AudioSource FinishBGM;
	public GameObject FinishCam;
	public GameObject DrivingCam;
	public GameObject levelBGM;
	//public GameObject CarOthers;
    public GameObject TimeManager;

    public GameObject CompletePanel;
    public GameObject ScoreModeLabel;
    public GameObject TimeModeLabel;
    public GameObject ScoreDisplay;
    public GameObject TimeDisplay;
    public GameObject CollisionNumDisplay;
    public GameObject TotalDamageDisplay;
    public GameObject GradeDisplay;
    public GameObject CppControlGO;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    private int RaceMode;
    private int PlayerNum;

    // Use this for initialization
    void Start() {
        PlayerNum = GameSetting.NumofPlayer;
        for(int i = 0;i < PlayerNum; i++)
        {
            PlayerCar[i].SetActive(false);
        }
        
		CompleteTrig.SetActive (false);

        //CarOthers.SetActive (false);
        //CarController.m_Topspeed = 0.0f;
        for (int i = 0; i < PlayerNum; i++)
        {
            PlayerCar[i].GetComponent<CarAudio>().enabled = false;
            PlayerCar[i].GetComponent<CarController>().enabled = false;
            PlayerCar[i].GetComponent<CppCarControl>().enabled = false;
            switch (i)
            {
                case 0:
                    PlayerCar[0].GetComponent<CarUserControl>().enabled = false;
                    break;
                case 1:
                    PlayerCar[1].GetComponent<CarUserControl2>().enabled = false;
                    break;
                case 2:
                    PlayerCar[2].GetComponent<CarUserControl3>().enabled = false;
                    break;
                case 3:
                    PlayerCar[3].GetComponent<CarUserControl4>().enabled = false;
                    break;
            }
        }
        CppControlGO.SetActive(false);


        //DrivingCam.SetActive (false);
        for (int i = 0; i < PlayerNum; i++)
        {
            PlayerCar[i].SetActive(true);
        }
		//FinishCam.SetActive (true);
		levelBGM.SetActive (false);
       

        FinishBGM.Play ();

        CompletePanel.SetActive(true);
        RaceMode = GameSetting.RaceMode;
        CollisionNumDisplay.GetComponent<TextMeshProUGUI>().text = "" + DamageDisplay1.CollisionNum;
        TotalDamageDisplay.GetComponent<TextMeshProUGUI>().text = "" + DamageDisplay1.ExtentOfDamage;

        //we need a algorithm to calculate the grade
        GradeDisplay.GetComponent<TextMeshProUGUI>().text = "coming soon";

        if (RaceMode == 2)
        {
            ScoreModeLabel.SetActive(true);
            ScoreDisplay.SetActive(true);
            ScoreDisplay.GetComponent<TextMeshProUGUI>().text = "" + GameModeManager.CurrentScore1;
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
