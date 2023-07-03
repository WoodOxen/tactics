using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTreeManager : ModelTreeManager
{
    public override void SetTargetVis(int vehicleIndex = 0)
    {
        _targetVis = GameObject.Find("VehicleSpace").transform.GetChild(vehicleIndex).Find("PhysicsVis");
    }
}
