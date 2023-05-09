using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSelectVehicle : MonoBehaviour
{
    public int vehicleIndex = 0;
    EditorCamController cameraController;
    // Start is called before the first frame update
    public void Awake()
    {
        cameraController = GetComponent<EditorCamController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("VehicleSpace").transform.childCount != 0)
        {
            cameraController.target = GameObject.Find("VehicleSpace").transform.GetChild(vehicleIndex);
        }
        else
        {
            cameraController.target = GameObject.Find("Platform").transform;
        }
    }
}
