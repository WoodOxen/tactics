using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordControllerOutput : MonoBehaviour
{
    public static ArrayList[] steer = new ArrayList[4];
    public static ArrayList[] accel = new ArrayList[4];
    public static ArrayList[] footbrake = new ArrayList[4];
    public static ArrayList[] handbrake = new ArrayList[4];

    void Start()
    {
        for(int i =0;i < 4; i++)
        {
            steer[i] = new ArrayList(10000);
            accel[i] = new ArrayList(10000);
            footbrake[i] = new ArrayList(10000);
            handbrake[i] = new ArrayList(10000);
        }
    }
}
