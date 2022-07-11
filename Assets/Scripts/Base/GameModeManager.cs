using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameModeManager : MonoBehaviour {

	public GameObject TimeModeUI;
	public GameObject ScoreModeUI;
	public GameObject AIcar;
	public GameObject ScoreModeObject;
	public int ModeSelection;
	public int InternalScore;
	public GameObject ScoreValue;
	//public GameObject PositionDisplay;
	public static int CurrentScore;
    public GameObject LapRequireDisplay;

    void Start () {
        DamageDisplay.ExtentOfDamage = 0f;
        DamageDisplay.CollisionNum = 0;
		CurrentScore = 0;
		ModeSelection = GameSetting.RaceMode;
		if (ModeSelection == 2) {
			TimeModeUI.SetActive (false);
			ScoreModeUI.SetActive (true);
			ScoreModeObject.SetActive (true);
			AIcar.SetActive (false);
			//PositionDisplay.SetActive (false);
            LapRequireDisplay.GetComponent<Text>().text = "1" ;
        }
		else{
			TimeModeUI.SetActive (true);
			ScoreModeUI.SetActive (false);
			ScoreModeObject.SetActive (false);
			AIcar.SetActive (true);
			//PositionDisplay.SetActive (true);
            LapRequireDisplay.GetComponent<Text>().text = "2";
        }
	}
	

	void Update () {
		InternalScore = CurrentScore;
		ScoreValue.GetComponent<Text> ().text = "" + InternalScore;
	}
}
