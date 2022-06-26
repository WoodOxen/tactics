using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CashDisplay : MonoBehaviour {

	public int CashValue;
	public static int TotalCash;
	public GameObject Cashdisplay;

	void Start () {
		TotalCash = PlayerPrefs.GetInt ("SavedCash");
	}

	void Update () {
		CashValue = TotalCash;
		Cashdisplay.GetComponent<Text>().text = "Cash $" + CashValue;
	}
}
