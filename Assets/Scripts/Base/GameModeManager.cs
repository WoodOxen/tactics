using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

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
    public GameObject MinimapAIcarMark;

    void Start () {
        DamageDisplay.ExtentOfDamage = 0f;
        DamageDisplay.CollisionNum = 0;
		//CurrentScore = 0;
		ModeSelection = GameSetting.RaceMode;
		if (ModeSelection == 2) { //Score Mode
			TimeModeUI.SetActive (false);
			ScoreModeUI.SetActive (true);
			ScoreModeObject.SetActive (true);
			AIcar.SetActive (false);
            MinimapAIcarMark.SetActive(false);
			//PositionDisplay.SetActive (false);
            LapRequireDisplay.GetComponent<TextMeshProUGUI>().text = "1" ;
        }
		else{ // Time Mode
			TimeModeUI.SetActive (true);
			ScoreModeUI.SetActive (false);
			ScoreModeObject.SetActive (false);
            //MinimapAIcarMark.SetActive(true);
            //AIcar.SetActive (true);
			//PositionDisplay.SetActive (true);
            LapRequireDisplay.GetComponent<TextMeshProUGUI>().text = "2";
        }
	}
	

	void Update () {
		InternalScore = CurrentScore;
		ScoreValue.GetComponent<TextMeshProUGUI> ().text = "" + InternalScore;
	}
}
