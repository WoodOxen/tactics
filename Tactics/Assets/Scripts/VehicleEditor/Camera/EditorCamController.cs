using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCamController : MonoBehaviour
{
    public Transform target; // The target the camera should orbit around
    public float distance = 10.0f; // The distance from the target
    public float xSpeed = 120.0f; // The speed of the x rotation
    public float ySpeed = 120.0f; // The speed of the y rotation
    public float scrollSpeed = 5;

    public float maxY = 60;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (target)
        {
            // get mouse input
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * ySpeed * distance * Time.deltaTime;
                y = Mathf.Clamp(y, 0, maxY);
            }

            distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            distance = Mathf.Clamp(distance, 3, 10);
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
