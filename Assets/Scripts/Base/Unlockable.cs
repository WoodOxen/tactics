using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unlockable : MonoBehaviour {

	public GameObject greenCarButtonlocked;
	public GameObject yellowCarButtonlocked;
	public GameObject track02Buttonlocked;
	public int cashValue;

	void Update () {
		cashValue = CashDisplay.TotalCash;
		if (cashValue >= 100) {
			greenCarButtonlocked.GetComponent<Button> ().interactable = true;
			yellowCarButtonlocked.GetComponent<Button> ().interactable = true;
			track02Buttonlocked.GetComponent<Button> ().interactable = true;
		} else {
			greenCarButtonlocked.GetComponent<Button> ().interactable = false;
			yellowCarButtonlocked.GetComponent<Button> ().interactable = false;
			track02Buttonlocked.GetComponent<Button> ().interactable = false;
		}
	}

	public void GreenUnlock(){
		greenCarButtonlocked.SetActive (false);
		cashValue -= 100;
		CashDisplay.TotalCash -= 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);
		PlayerPrefs.SetInt ("GreenBought", 100);
	}

	public void YellowUnlock(){
		yellowCarButtonlocked.SetActive (false);
		cashValue -= 100;
		CashDisplay.TotalCash -= 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);
		PlayerPrefs.SetInt ("YellowBought", 100);
	}

	public void Track02Unlock(){
		track02Buttonlocked.SetActive (false);
		cashValue -= 100;
		CashDisplay.TotalCash -= 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);
		PlayerPrefs.SetInt ("Track02Bought", 100);
	}
}
