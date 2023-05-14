using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Localization.Metadata;

public class CamSelectVehicle : MonoBehaviour
{
    public int vehicleIndex = 0;

    private Transform target;
    EditorCamController cameraController;
    
    public void SelectPart(Transform t)
    {
        target = t;
    }
    public void DeSelectPart()
    {
        target = null;
    }

    public void Awake()
    {
        cameraController = GetComponent<EditorCamController>();
    }
    void Start()
    {

    }
    
    void Update()
    {
        if (GameObject.Find("VehicleSpace").transform.childCount != 0)
        {
            if (target)
            {
                cameraController.target = target;
            }
            else
            {
                cameraController.target = GameObject.Find("VehicleSpace").transform.GetChild(vehicleIndex);
            }
            
        }
        else
        {
            cameraController.target = GameObject.Find("Platform").transform;
        }
    }
}
