using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackFunction : MonoBehaviour
{
    public GameObject TheCar;

    public float CallbackSpeed()
    {
        Vector3 velocity = TheCar.GetComponent<Rigidbody>().velocity;
        float speed = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
        return speed;
    }
}
