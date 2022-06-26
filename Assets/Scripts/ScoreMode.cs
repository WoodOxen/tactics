using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMode : MonoBehaviour {

	public GameObject TimeModeUI;
	public GameObject ScoreModeUI;
	public GameObject AIcar;
	public GameObject ScoreModeObject;
	public int ModeSelection;
	public int InternalScore;
	public GameObject ScoreValue;
	public GameObject PositionDisplay;
	public static int CurrentScore;

	void Start () {
		CurrentScore = 0;
		ModeSelection = CarChoose.RaceMode;
		if (ModeSelection == 2) {
			TimeModeUI.SetActive (false);
			ScoreModeUI.SetActive (true);
			ScoreModeObject.SetActive (true);
			AIcar.SetActive (false);
			PositionDisplay.SetActive (false);
		}
		if (ModeSelection == 1) {
			TimeModeUI.SetActive (true);
			ScoreModeUI.SetActive (false);
			ScoreModeObject.SetActive (false);
			AIcar.SetActive (true);
			PositionDisplay.SetActive (true);
		}
	}
	

	void Update () {
		InternalScore = CurrentScore;
		ScoreValue.GetComponent<Text> ().text = "" + InternalScore;
	}
}
