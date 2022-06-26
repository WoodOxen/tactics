using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene (1);
	}

	public void Random(){
		CarChoose.RaceMode = 1;
		CarChoose.CarType = 1;
		SceneManager.LoadScene (2);
	}

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}

	public void quit(){
		Application.Quit ();
	}

	public void Credits(){
		SceneManager.LoadScene (4);
	}


	//buttons in track selection
	public void Track01(){
		SceneManager.LoadScene (2);
	}
	public void Track02(){
		SceneManager.LoadScene (3);
	}
	public void NeverTouch(){
		CashDisplay.TotalCash += 100;
		PlayerPrefs.SetInt ("SavedCash", CashDisplay.TotalCash);
	}
	public void ResetBuy(){
		PlayerPrefs.SetInt ("GreenBought", 0);
		PlayerPrefs.SetInt ("YellowBought", 0);
		PlayerPrefs.SetInt ("Track02Bought", 0);
	}
}
