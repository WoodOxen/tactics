using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelVisController : MonoBehaviour
{

    public List<KeyValuePair<WheelCollider, Transform>> wheelGroups = new List<KeyValuePair<WheelCollider, Transform>>();
    
    /// <summary>
    /// bind Vis transform and wheel collider pair
    /// </summary>
    void InitWheel()
    {

        List<GameObject> colliderList = new List<GameObject>();

        foreach (Transform child in transform.Find("wheel"))
        {
            colliderList.Add(child.gameObject);
        }
        List<GameObject> modelList = new List<GameObject>();
        foreach (Transform child in transform.Find("Vis").Find("Wheel"))
        {
            modelList.Add(child.gameObject);
        }
        //Debug.Log(colliderList.Count);
        //Debug.Log(modelList.Count);

        for (int i = 0; i < colliderList.Count; i++)
        {
            //Debug.Log(colliderList[i].GetComponent<WheelCollider>());
            //Debug.Log(modelList[i].transform);
            wheelGroups.Add(new KeyValuePair<WheelCollider, Transform>(colliderList[i].GetComponent<WheelCollider>(), modelList[i].transform));
        }
    }

    /// <summary>
    /// Sync all the wheel model
    /// </summary>
    void Wheel_Update()
    {
        foreach (var wheel in wheelGroups)
        {
            WheelPair_Update(wheel.Value, wheel.Key);
        }

    }
    /// <summary>
    /// Sync wheel model and collider pair
    /// </summary>
    /// <param name="t"> the transform of tyre model </param>
    /// <param name="wheel"> the WheelCollider component </param>
    void WheelPair_Update(Transform t, WheelCollider wheel)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        wheel.GetWorldPose(out pos, out rot);

        t.position = pos;
        t.rotation = rot;
    }
    void Start()
    {
        InitWheel();
        
    }

    void Update()
    {
        try
        {
            Wheel_Update();
        }
        catch { }
        
    }


    

}