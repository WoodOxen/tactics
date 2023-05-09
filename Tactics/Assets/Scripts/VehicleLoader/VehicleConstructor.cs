using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;

public class WheelTag : MonoBehaviour
{
    [System.Serializable]
    public class SteeringMode
    {
        public bool active = false;
        public bool inverse = false;
    }
    public bool powered = false;
    public SteeringMode steeringMode = new SteeringMode();
}

public class VehicleConstructor : MonoBehaviour
{
    public JsonReader myReader;

    public GameObject vehicle;

    /// <summary>
    /// Find the wheel gameObject using the relative path string
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public GameObject FindWheel(string dir, GameObject model)
    {
        string[] childList = dir.Split("/");
        GameObject res = model;
        foreach (var childName in childList)
        {
            res = res.transform.Find(childName).gameObject;
        }
        return res;
    }
    /// <summary>
    /// Construct physics visualization, including colliders, wheels, gravity center
    /// </summary>
    public void ConstructPhysicsVis()
    {

    }
    public void ConstructPhysics()
    {
        Rigidbody carRigid = vehicle.AddComponent<Rigidbody>();
        carRigid.mass = myReader.vehicle.physics.bodyMass;
        carRigid.centerOfMass = myReader.vehicle.physics.centerOfMass;

        GameObject bodyCollider = new GameObject("Col");
        bodyCollider.transform.SetParent(vehicle.transform);
        bodyCollider.transform.localPosition = Vector3.zero;
        bodyCollider.transform.localRotation = Quaternion.identity;
        foreach (JsonReader.BodyColliderPara para in myReader.vehicle.physics.collider)
        {
            GameObject col = new GameObject(para.type);
            col.transform.SetParent(bodyCollider.transform);
            col.transform.localPosition = para.position;
            col.transform.localEulerAngles = para.eulerRotation;
            col.transform.localScale = para.scale;
            switch (para.type)
            {
                case "box":
                    col.AddComponent<BoxCollider>();
                    break;
                case "sphere":
                    col.AddComponent<SphereCollider>();
                    break;
                default:
                    break;
            }
        }

        GameObject wheel = new GameObject("wheel");
        wheel.transform.SetParent(vehicle.transform);
        wheel.transform.localPosition = Vector3.zero;
        wheel.transform.localRotation = Quaternion.identity;
        foreach (JsonReader.WheelColliderPara para in myReader.vehicle.physics.wheel)
        {
            GameObject col = new GameObject();
            col.name = "wheel (" + col.GetInstanceID().ToString() + ")";
            col.transform.SetParent(wheel.transform);
            col.transform.localPosition = para.position;
            col.transform.localEulerAngles = Vector3.zero;
            col.transform.localScale = Vector3.one;
            WheelCollider wc = col.AddComponent<WheelCollider>();
            wc.mass = para.mass;
            wc.radius = para.radius;
            wc.suspensionDistance = para.suspension.distance;
            wc.forceAppPointDistance = para.radius/2f;

            JointSpring sj = new JointSpring();
            sj.spring = para.suspension.spring;
            sj.damper = para.suspension.damper;
            sj.targetPosition = para.suspension.initialPosition;
            wc.suspensionSpring = sj;

            WheelFrictionCurve forwardWFC = new WheelFrictionCurve();
            forwardWFC.extremumSlip = para.forwardFriction.extremumSlip;
            forwardWFC.extremumValue = para.forwardFriction.extremumValue;
            forwardWFC.asymptoteSlip = para.forwardFriction.AsymptoteSlip;
            forwardWFC.asymptoteValue = para.forwardFriction.AsymptoteValue;
            forwardWFC.stiffness = 1;

            wc.forwardFriction = forwardWFC;

            WheelFrictionCurve sidewayWFC = new WheelFrictionCurve();
            sidewayWFC.extremumSlip = para.sidewayFriction.extremumSlip;
            sidewayWFC.extremumValue = para.sidewayFriction.extremumValue;
            sidewayWFC.asymptoteSlip = para.sidewayFriction.AsymptoteSlip;
            sidewayWFC.asymptoteValue = para.sidewayFriction.AsymptoteValue;
            sidewayWFC.stiffness = 1;

            wc.sidewaysFriction = sidewayWFC;
            WheelTag tag = col.AddComponent<WheelTag>();
            tag.powered = para.type.powered;
            tag.steeringMode.active = para.type.steering.use;
            tag.steeringMode.inverse = para.type.steering.inverse;
        }
    }
    public void ConstructModel()
    {
        GameObject model = Importer.LoadFromFile(Application.streamingAssetsPath + "/Model/" + myReader.vehicle.model.carBody[0].dir);
        model.name = "Vis";
        model.transform.SetParent(vehicle.transform);
        model.transform.localPosition = myReader.vehicle.model.carBody[0].position;
        model.transform.localEulerAngles = myReader.vehicle.model.carBody[0].eulerRotation;
        model.transform.localScale = myReader.vehicle.model.carBody[0].scale;
        GameObject Wheels = new GameObject("Wheel");
        Wheels.transform.SetParent(model.transform);
        Wheels.transform.localPosition = Vector3.zero;
        Wheels.transform.localEulerAngles = Vector3.zero;
        foreach (var wheel in myReader.vehicle.model.wheel)
        {
            GameObject wheelroot = FindWheel(wheel.dir[0], model);
            wheelroot.transform.SetParent(Wheels.transform);
            for (int i = 1; i < wheel.dir.Count; i++)
            {
                FindWheel(wheel.dir[i], model).transform.SetParent(wheelroot.transform);
            }
        }
    }

    public void Construct(Transform place, bool inEditor, Vector3 position)
    {
        vehicle = new GameObject();
        vehicle.name = ("Vehicle (" + vehicle.GetInstanceID().ToString() + ")");
        vehicle.transform.SetParent(place);
        vehicle.transform.localPosition = position;

        ConstructModel();
        if (inEditor)
        {
            ConstructPhysicsVis();
        }
        else
        {
            ConstructPhysics();
            vehicle.AddComponent<WheelVisController>();
            vehicle.AddComponent<WheelController>();
        }
    }

    public void PlaceVehicle(Transform place, bool inEditor = false)
    {
        if (place.childCount!=0 && inEditor)
        {
            Debug.LogError("Vehicle already loaded in the editor, please delete the existing vehicle first.");
        }
        else
        {
            myReader = GetComponent<JsonReader>();
            if (myReader.valid)
            {
                Debug.Log("Json file is loaded successfully, start constructing the vehicle under VehicleSpace");
                //try
                //{
                //    Construct();
                //}
                //catch
                //{
                //    Debug.LogError("Failure: Construct data wrong");
                //}
                Construct(place, inEditor, new Vector3(0,1.1f,0));

            }
            else
            {
                Debug.LogError("Failure: Loading json file");
            }
        }

    }

}
