using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyContentManager : MonoBehaviour
{
    public GameObject TargetNode;
    public GameObject TargetObject;

    public GameObject TransformPanelObject;
    

    public void ReadTransformData()
    {
        if (TargetNode)
        {
            TransformPanelObject.GetComponent<TransformPanel>().LoadData(TargetObject.transform);
        }
    }

    // called on tree node double click
    public void SetTarget(GameObject node)
    {
        TargetNode = node;
        TargetObject = TargetNode.GetComponent<TreeNode>().MappedObject;


        if (node.GetComponent<TreeNode>().PAss.Transform)
        {
            ReadTransformData();
            TransformPanelObject.SetActive(true);
        }
        else
        {
            TransformPanelObject.SetActive(false);
        }
    }
    public void Clear()
    {
        TransformPanelObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!TargetNode)
        {
            Clear();
        }
    }
}
