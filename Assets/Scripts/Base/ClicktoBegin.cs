using UnityEngine;
using System.Collections;

public class ClicktoBegin : MonoBehaviour {

	public GameObject buttons;
	public GameObject ClickButtons;
	public GameObject ClickText;
	public GameObject CashDisplayStart;

	public void Click(){
		buttons.SetActive (true);
		CashDisplayStart.SetActive (true);
		ClickButtons.SetActive (false);
		ClickText.SetActive (false);

	}
}
