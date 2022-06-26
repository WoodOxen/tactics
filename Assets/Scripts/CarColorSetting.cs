using UnityEngine;
using System.Collections;

public class CarColorSetting : MonoBehaviour {

	public GameObject RedBody;
	public GameObject BlueBody;
	public GameObject YellowBody;
	public GameObject GreenBody;
	public GameObject GreyBody;
	public int CarImport;

	// Use this for initialization
	void Start () {
		CarImport = CarChoose.CarType;
		if (CarImport == 1) {
			RedBody.SetActive (true);
		} else if (CarImport == 2) {
			BlueBody.SetActive (true);
		} else if (CarImport == 3) {
			YellowBody.SetActive (true);
		} else if (CarImport == 4) {
			GreenBody.SetActive (true);
		} else {
			GreyBody.SetActive (true);
		}
	}

}
