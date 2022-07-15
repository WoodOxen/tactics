using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LapTimeManager : MonoBehaviour {

	public static int MinuteCount;
	public static int SecondCount;
	public static float MilliCount;
	public static string MilliDisplay;

	public GameObject MinuteBox;
	public GameObject SecondBox;
	public GameObject MilliBox;

	public static float rawtime;

	// Update is called once per frame
	void Update () {
		MilliCount += Time.deltaTime * 10;
		rawtime += Time.deltaTime;
		MilliDisplay = MilliCount.ToString ("F0");
		MilliBox.GetComponent<TextMeshProUGUI>().text = "" + MilliDisplay;

		if (MilliCount >= 10) {
			SecondCount += 1;
			MilliCount = 0;
		}

		if (SecondCount <= 9) {
			SecondBox.GetComponent<TextMeshProUGUI> ().text = "0" + SecondCount + ".";
		} else {
			SecondBox.GetComponent<TextMeshProUGUI> ().text = "" + SecondCount + ".";
		}
			
		if (SecondCount >= 60) {
			MinuteCount += 1;
			SecondCount = 0;
		}

		if (MinuteCount <= 9) {
			MinuteBox.GetComponent<TextMeshProUGUI> ().text = "0" + MinuteCount + ":";
		} else {
			MinuteBox.GetComponent<TextMeshProUGUI> ().text = "" + MinuteCount + ":";
		}

	}
}
