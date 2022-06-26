using UnityEngine;
using System.Collections;

public class UnlockedObjects : MonoBehaviour {

	public int greenSelect;
	public GameObject greenLocked;
	public int yellowSelect;
	public GameObject yellowLocked;
	public int track02Select;
	public GameObject track02Locked;

	void Update () {
		greenSelect = PlayerPrefs.GetInt ("GreenBought");
		if (greenSelect == 100) {
			greenLocked.SetActive (false);
		} else {
			greenLocked.SetActive (true);
		}

		yellowSelect = PlayerPrefs.GetInt ("YellowBought");
		if (yellowSelect == 100) {
			yellowLocked.SetActive (false);
		} else {
			yellowLocked.SetActive (true);
		}

		track02Select = PlayerPrefs.GetInt ("Track02Bought");
		if (track02Select == 100) {
			track02Locked.SetActive (false);
		} else {
			track02Locked.SetActive (true);
		}
	}
	

}
