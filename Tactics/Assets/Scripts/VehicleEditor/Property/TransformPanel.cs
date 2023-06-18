using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransformData
{
    public Vector3 Pos;
    public Vector3 Rot;
    public Vector3 Size;

    public TransformData(Vector3 pos, Vector3 rot, Vector3 size)
    {
        Pos = pos;
        Rot = rot;
        Size = size;
    }
    public TransformData()
    {
        Pos = Vector3.zero;
        Rot = Vector3.zero;
        Size = Vector3.zero;
    }
}

public class TransformPanel : MonoBehaviour
{
    public TransformData Data = new TransformData();
    public Transform TargetTransform;

    public TMP_InputField Pos_x;
    public TMP_InputField Pos_y;
    public TMP_InputField Pos_z;
    public TMP_InputField Rot_x;
    public TMP_InputField Rot_y;
    public TMP_InputField Rot_z;
    public TMP_InputField Scale_x;
    public TMP_InputField Scale_y;
    public TMP_InputField Scale_z;

    public void LoadData(Transform target)
    {
        if (target)
        {
            TargetTransform = target;
            Data.Pos = target.localPosition;
            Data.Rot = target.localEulerAngles;
            Data.Size = target.localScale;
            WriteText();
        }
    }

    // called on text change
    public void UpdateData()
    {
        ReadText();
        if (TargetTransform)
        {
            TargetTransform.localPosition = Data.Pos;
            TargetTransform.localEulerAngles = Data.Rot;
            TargetTransform.localScale = Data.Size;
        }
    }

    public void WriteText()
    {
        Pos_x.text = Data.Pos.x.ToString();
        Pos_y.text = Data.Pos.y.ToString();
        Pos_z.text = Data.Pos.z.ToString();
        Rot_x.text = Data.Rot.x.ToString();
        Rot_y.text = Data.Rot.y.ToString();
        Rot_z.text = Data.Rot.z.ToString();
        Scale_x.text = Data.Size.x.ToString();
        Scale_y.text = Data.Size.y.ToString();
        Scale_z.text = Data.Size.z.ToString();
    }

    public void ReadText()
    {
        Data.Pos.x = float.Parse(Pos_x.text);
        Data.Pos.y = float.Parse(Pos_y.text);
        Data.Pos.z = float.Parse(Pos_z.text);
        Data.Rot.x = float.Parse(Rot_x.text);
        Data.Rot.y = float.Parse(Rot_y.text);
        Data.Rot.z = float.Parse(Rot_z.text);
        Data.Size.x = float.Parse(Scale_x.text);
        Data.Size.y = float.Parse(Scale_y.text);
        Data.Size.z = float.Parse(Scale_z.text);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
