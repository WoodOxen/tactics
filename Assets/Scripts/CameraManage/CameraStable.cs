using UnityEngine;
using System.Collections;

public class CameraStable : MonoBehaviour {

    public GameObject TheCar;


    // Update is called once per frame
    void Update () {
        transform.eulerAngles = new Vector3 (0, TheCar.transform.eulerAngles.y, 0);

    }
}
