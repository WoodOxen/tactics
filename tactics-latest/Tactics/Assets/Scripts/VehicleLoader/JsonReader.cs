using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public string SavesDir;
    public VehiclePara vehicle;

    public bool valid = false;

    [System.Serializable]
    public class VehicleModelPara
    {
        public List<BodyModelPara> carBody;
        public List<WheelModelPara> wheel;
    }
    [System.Serializable]
    public class BodyModelPara
    {
        public string name;
        public string dir;
        public Vector3 position;
        public Vector3 eulerRotation;
        public Vector3 scale;
    }

    [System.Serializable]
    public class WheelModelPara
    {
        public string name;
        public List<string> dir;
    }

    [System.Serializable]
    public class VehiclePhysicsPara
    {
        public float bodyMass;
        public Vector3 centerOfMass;
        public List<BodyColliderPara> collider;
        public List<WheelColliderPara> wheel;
    }

    [System.Serializable]
    public class BodyColliderPara
    {
        public string type; // box | sphere
        public Vector3 position;
        public Vector3 eulerRotation;
        public Vector3 scale;
    }
    [System.Serializable]
    public class SteeringWheelTypePara
    {
        public bool use;
        public bool inverse;
    }
    [System.Serializable]
    public class WheelTypePara
    {
        public bool powered;
        public SteeringWheelTypePara steering;
    }
    [System.Serializable]
    public class WheelSuspensionPara
    {
        public float spring;
        public float damper;
        public float distance;
        public float initialPosition;
    }
    [System.Serializable]
    public class WheelFrictionPara
    {
        public float extremumSlip;
        public float extremumValue = 1;
        public float AsymptoteSlip;
        public float AsymptoteValue;
    }

    [System.Serializable]
    public class WheelColliderPara
    {
        public WheelTypePara type;
        public float mass;
        public float radius;
        public Vector3 position;
        public WheelSuspensionPara suspension;
        public WheelFrictionPara forwardFriction;
        public WheelFrictionPara sidewayFriction;
    }

    [System.Serializable]
    public class CarBodyPara
    {
        public string name;
        public string dir;
        public Vector3 position;
        public Vector3 eulerRotation;
        public Vector3 scale;
        public string shader;
    }
    [System.Serializable]
    public class VehiclePara
    {
        public VehicleModelPara model;
        public VehiclePhysicsPara physics;  
    }

    public void ReadJson()
    {
        try
        {
            //Debug.Log(Application.dataPath);
            string jsonData = File.ReadAllText(Application.streamingAssetsPath + "/Saves/" + SavesDir);
            vehicle = JsonUtility.FromJson<VehiclePara>(jsonData);
            valid = true;
        }
        catch
        {
            valid = false;
        }
    }

}
