using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class carControllActive : MonoBehaviour {

	public GameObject CarControl;
	public GameObject DreamCar01Control;
	void Start () {
		CarControl.GetComponent<CarController> ().enabled = true;
        if(GameSetting.ControlMethod == 2)
            CarControl.GetComponent<CppCarControl>().enabled = true;
        else
            CarControl.GetComponent<CarUserControl> ().enabled = true;

        CarControl.GetComponent<CarAudio> ().enabled = true;

        //if(GameSetting.RaceMode != 2)
        //{
        //    DreamCar01Control.GetComponent<CarAIControl>().enabled = true;
        //    DreamCar01Control.GetComponent<CarController>().enabled = true;
            //DreamCar01Control.GetComponent<CarAudio>().enabled = true;
        //}
	}

}
