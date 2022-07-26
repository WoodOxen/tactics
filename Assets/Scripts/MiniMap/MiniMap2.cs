using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap2 : MonoBehaviour
{
    public GameObject TheCar;
    public static Vector3 CarPosition;
    private float MarkX;
    private float MarkY;
    
    void Update()
    {
        CarPosition = TheCar.GetComponent<Transform>().position;
        MarkX = -50+(CarPosition.z - 1)*100/563;
        MarkY = 50-(CarPosition.x-411)*100/528;
        transform.GetComponent<RectTransform>().localPosition = new Vector3(MarkX, MarkY, 0);
        transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,-90-TheCar.transform.eulerAngles.y);
    }
}
