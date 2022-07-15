using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedDisplay : MonoBehaviour
{
    public GameObject TheCar;
    private float speed;
    private Vector3 velocity;
    public GameObject speedDisplaybox;
    // Update is called once per frame
    void Update()
    {
        velocity = TheCar.GetComponent<Rigidbody>().velocity;
        speed = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
        speedDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + speed.ToString("#0.00");
    }
}
