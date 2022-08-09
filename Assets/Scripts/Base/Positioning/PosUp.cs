using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PosUp : MonoBehaviour {

	public GameObject positonDisplay;

	void OnTriggerExit(Collider other){
		if (other.tag == "CarPos") {
			positonDisplay.GetComponent<Text> ().text = "1st Place";
		}
	}
}
