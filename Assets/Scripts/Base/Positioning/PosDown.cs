using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PosDown : MonoBehaviour {

	public GameObject positonDisplay;

	void OnTriggerExit(Collider other){
		if (other.tag == "CarPos") {
			positonDisplay.GetComponent<Text> ().text = "2st Place";
		}
	}
}
