using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class UnpoweredWheel:MonoBehaviour
{
    WheelCollider WC;
    void Start()
    {
        WC = GetComponent<WheelCollider>();
        WC.brakeTorque = 0f;
        WC.motorTorque = 0.001f;
    }
}
