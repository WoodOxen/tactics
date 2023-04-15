using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRaceData : MonoBehaviour
{
    public GameObject[] Cars;
    /// 各车辆的巡线误差
    public static float[] distance_error = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 各车辆前方的赛道曲率
    public static float[] curvature = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 各车辆的角度误差
    public static float[] yaw = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] yawrate = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] speed = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    private float[] speed_last = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float[] acc = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public static float width = 0;

    private CruiseData[] cruiseDatas;
    private Vector3 velocity;
    private Vector3 angular_velocity;
    private Rigidbody[] rigidbodys;
    [SerializeField]
    public float width_edit;
    

    void Start()
    {
        width = width_edit;
        cruiseDatas = new CruiseData[8];
        rigidbodys = new Rigidbody[8];
        for (int i = 0;i < 8;i++)
        {
            cruiseDatas[i] = Cars[i].GetComponent<CruiseData>();
            rigidbodys[i] = Cars[i].GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < 8; i++)
        {
            distance_error[i] = cruiseDatas[i].distance_error;
            curvature[i] = cruiseDatas[i].curvature;
            yaw[i] = cruiseDatas[i].yaw;
            velocity = rigidbodys[i].velocity;
            angular_velocity = rigidbodys[i].angularVelocity;
            speed[i] = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
            //speed[i] = cruiseDatas[i].GetWPkRelative(10).z;
            acc[i] = (speed[i] - speed_last[i]) / Time.fixedDeltaTime;
            speed_last[i] = speed[i];
            yawrate[i] = angular_velocity.y;
        }
    }

}
