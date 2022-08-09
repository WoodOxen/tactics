using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap2 : MonoBehaviour
{
    public GameObject TheCar;
    public static Vector3[] CarPosition = new Vector3[4];
    private float MarkX;
    private float MarkY;
    [SerializeField] public int CarNum;
    void Update()
    {
        CarPosition[CarNum] = TheCar.GetComponent<Transform>().position;
        MarkX = -50+(CarPosition[CarNum].z - 1)*100/563;
        MarkY = 50-(CarPosition[CarNum].x - 411)*100/528;
        transform.GetComponent<RectTransform>().localPosition = new Vector3(MarkX, MarkY, 0);
        transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,-90-TheCar.transform.eulerAngles.y);
    }
}
