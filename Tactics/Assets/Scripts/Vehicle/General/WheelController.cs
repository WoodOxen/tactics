using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public float moveSpeed = 300;
    public float maxAngle = 35;
    public float angleSpeed = 50;

    public List<wheelData> wheels = new List<wheelData>();

    public class wheelData
    {
        public WheelTag tag;
        public WheelCollider wc;
        public wheelData(GameObject go)
        {
            tag = go.GetComponent<WheelTag>();
            wc = go.GetComponent<WheelCollider>();
        }
    }

    

    public void Start()
    {
        foreach (Transform wheel in transform.Find("wheel"))
        {
            wheelData data = new wheelData(wheel.gameObject);
            wheels.Add(data);
            if (!data.tag.powered)
            {
                wheel.gameObject.AddComponent<UnpoweredWheel>();
            }
        }
    }

    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        foreach (var wheel in wheels)
        {
            if (wheel.tag.powered)
            {
                wheel.wc.motorTorque = v * moveSpeed;
            }
        }
        
        // turning left
        if (Input.GetKey(KeyCode.A))
        {
            foreach(var wheel in wheels)
            {
                if (wheel.tag.steeringMode.active)
                {
                    wheel.wc.steerAngle -= Time.deltaTime * angleSpeed * (wheel.tag.steeringMode.inverse ? -1 : 1);
                    wheel.wc.steerAngle = Mathf.Clamp(wheel.wc.steerAngle, -maxAngle, maxAngle);
                }
            }
        }
        // turning right
        else if (Input.GetKey(KeyCode.D))
        {
            foreach (var wheel in wheels)
            {
                if (wheel.tag.steeringMode.active)
                {
                    wheel.wc.steerAngle += Time.deltaTime * angleSpeed * (wheel.tag.steeringMode.inverse ? -1 : 1);
                    wheel.wc.steerAngle = Mathf.Clamp(wheel.wc.steerAngle, -maxAngle, maxAngle);
                }
            }
        }
        // turn back
        else
        {
            foreach (var wheel in wheels)
            {
                if (wheel.tag.steeringMode.active)
                {
                    if (Mathf.Abs(wheel.wc.steerAngle)< Time.deltaTime * angleSpeed)
                    {
                        wheel.wc.steerAngle = 0;
                    }
                    else
                    {
                        wheel.wc.steerAngle += Time.deltaTime * angleSpeed * (wheel.wc.steerAngle > 0 ? -1 : 1);
                    }
                }
            }
        }
    }

}
