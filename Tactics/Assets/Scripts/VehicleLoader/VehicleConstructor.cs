using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using Assets.Scripts.VehicleEditor;
using VehiclePhysics;

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
    public GameObject BoxColVisPrefab;
    public GameObject SphereColVisPrefab;

    public JsonReader myReader;

    public GameObject vehicle;

    private Material _transparentMat;




    private void AddMatArray(Transform t)
    {
        MeshRenderer mr = t.GetComponent<MeshRenderer>();
        if (mr)
        {
            Material[] mats = new Material[mr.materials.Length+1];
            mats[0] = mr.material;
            for (int i = 0; i < mr.materials.Length; i++)
            {
                mats[i] = mr.materials[i];
            }
            mats[mr.materials.Length] = _transparentMat;
            mr.materials = mats;
        }
        foreach (Transform child in t)
        {
            AddMatArray (child);
        }
    }

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
        GameObject bodyPhysics = new GameObject("PhysicsVis");
        bodyPhysics.transform.SetParent(vehicle.transform);
        bodyPhysics.transform.localPosition = Vector3.zero;
        bodyPhysics.transform.localRotation = Quaternion.identity;
        GameObject bodyCollider = new GameObject("Collider");
        bodyCollider.transform.SetParent(bodyPhysics.transform);
        bodyCollider.transform.localPosition = Vector3.zero;
        bodyCollider.transform.localRotation = Quaternion.identity;
        foreach (JsonReader.BodyColliderPara para in myReader.vehicle.physics.collider)
        {
            GameObject col = new GameObject();
            switch (para.type)
            {
                case "box":
                    col = Instantiate(BoxColVisPrefab);
                    break;
                case "sphere":
                    col = Instantiate(SphereColVisPrefab);
                    break;
                default:
                    break;
            }
            col.transform.SetParent(bodyCollider.transform);
            col.transform.localPosition = para.position;
            col.transform.localEulerAngles = para.eulerRotation;
            col.transform.localScale = para.scale;

        }
    }
    public void ConstructPhysics()
    {
        Rigidbody carRigid = vehicle.AddComponent<Rigidbody>();
        carRigid.mass = myReader.vehicle.physics.bodyMass;
        carRigid.centerOfMass = myReader.vehicle.physics.centerOfMass;
        carRigid.drag = 0.1f;
        carRigid.isKinematic = true;
        vehicle.SetActive(false);

        VPVehicleController controller = vehicle.AddComponent<VPVehicleController>();
        VPStandardInput input = vehicle.AddComponent<VPStandardInput>();
        input.enabled = false;
        controller.enabled = true;
        

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
            VPWheelCollider wc = col.AddComponent<VPWheelCollider>();
            wc.mass = para.mass;
            wc.radius = para.radius;
            wc.suspensionDistance = para.suspension.distance;

            wc.springRate = para.suspension.spring;
            wc.damperRate = para.suspension.damper;

            //WheelFrictionCurve forwardWFC = new WheelFrictionCurve();
            //forwardWFC.extremumSlip = para.forwardFriction.extremumSlip;
            //forwardWFC.extremumValue = para.forwardFriction.extremumValue;
            //forwardWFC.asymptoteSlip = para.forwardFriction.AsymptoteSlip;
            //forwardWFC.asymptoteValue = para.forwardFriction.AsymptoteValue;
            //forwardWFC.stiffness = 1;

            Transform wheelVis = vehicle.transform.Find("Vis").Find("Wheel").GetChild(0);
            GameObject modifiedWheelVis = new GameObject("Wheel"+col.transform.GetSiblingIndex());
            modifiedWheelVis.transform.parent = wheelVis.parent.transform;
            modifiedWheelVis.transform.localPosition = para.position;
            modifiedWheelVis.transform.eulerAngles = Vector3.zero;
            modifiedWheelVis.transform.localScale = Vector3.one;
            wheelVis.SetParent(modifiedWheelVis.transform);
            wheelVis.transform.localPosition = Vector3.zero;

            wc.wheelTransform = modifiedWheelVis.transform;

        }

        // assign wheel collider
        VPAxle[] axles = new VPAxle[2];
        axles[0] = new VPAxle();
        axles[1] = new VPAxle();
        axles[0].leftWheel = vehicle.transform.Find("wheel").GetChild(0).gameObject.GetComponent<VPWheelCollider>();
        axles[0].rightWheel = vehicle.transform.Find("wheel").GetChild(1).gameObject.GetComponent<VPWheelCollider>();
        axles[0].steeringMode = Steering.SteeringMode.Steerable;
        axles[0].brakeCircuit = Brakes.BrakeCircuit.Front;
        axles[1].leftWheel = vehicle.transform.Find("wheel").GetChild(2).gameObject.GetComponent<VPWheelCollider>();
        axles[1].rightWheel = vehicle.transform.Find("wheel").GetChild(3).gameObject.GetComponent<VPWheelCollider>();
        axles[1].steeringMode = Steering.SteeringMode.Disabled;
        axles[1].brakeCircuit = Brakes.BrakeCircuit.Rear;
        controller.axles = axles;
        vehicle.SetActive(true);

    }
    public void ConstructModel(bool addHightLight = false)
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

        if (addHightLight)
        {
            AddMatArray(model.transform);
        }
    }

    public void Construct(Transform place, bool inEditor, Vector3 position)
    {
        vehicle = new GameObject();
        vehicle.name = ("Vehicle (" + vehicle.GetInstanceID().ToString() + ")");
        vehicle.transform.SetParent(place);
        vehicle.transform.localPosition = position;

        ConstructModel(inEditor);
        if (inEditor)
        {

            ConstructPhysicsVis();
            ConstructPhysics();

            
            
        }
        else
        {
            ConstructPhysics();
            //vehicle.AddComponent<WheelVisController>();
            vehicle.AddComponent<WheelController>();
        }

        CommonTool.ChangeLayer(vehicle.transform, 7);
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
    public void Awake()
    {
        _transparentMat = Resources.Load<Material>("Materials/Transparent");
    }

}
