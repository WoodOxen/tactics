using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTreeManager: MonoBehaviour
{
    private Transform _targetVis;

    public TreeNode MyRoot;

    public void FindNode(Transform root, Transform mirrorRoot, int depth = 0)
    {
        foreach (Transform node in root)
        {
            if (node.childCount != 0) // has child
            {
                GameObject mirrorNode = (GameObject)Instantiate(mirrorRoot.GetChild(1).gameObject, mirrorRoot);
                mirrorNode.SetActive(true);
                GameObject mirrorNodeSample = (GameObject)Instantiate(mirrorRoot.transform.GetChild(1).gameObject, mirrorNode.transform);
                mirrorNodeSample.name = "SampleNode";
                int nodeIndex = mirrorNode.transform.GetSiblingIndex() - 2;
                mirrorNode.name = "node("+ nodeIndex +")__" + node.name;
                TreeNode tn = mirrorNode.GetComponent<TreeNode>();
                tn.IsLeaf = false;
                tn.Depth = depth+1;

                mirrorNode.transform.Find("text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = node.name;

                int width = node.name.Length * 15;
                mirrorNode.GetComponent<RectTransform>().sizeDelta = new Vector2(width,30);

                int parentWdith = root.name.Length * 15;

                mirrorNode.transform.localPosition = new Vector3(40 - parentWdith/2 + width/2f, -30f*nodeIndex-30, 0);

                FindNode(node, mirrorNode.transform, depth+1);
            }
            else // is leaf
            {
                GameObject mirrorNode = (GameObject)Instantiate(mirrorRoot.GetChild(1).gameObject, mirrorRoot);
                mirrorNode.name = "leaf(" + (mirrorNode.transform.GetSiblingIndex() - 2) + ")__" + node.name;
                mirrorNode.SetActive(true);

                TreeNode tn = mirrorNode.GetComponent<TreeNode>();
                tn.IsLeaf = false;
                tn.Depth = depth + 1;
                int nodeIndex = mirrorNode.transform.GetSiblingIndex() - 2;

                mirrorNode.transform.Find("text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = node.name;

                int width = node.name.Length * 15;
                mirrorNode.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 30);

                int parentWdith = root.name.Length * 15;

                mirrorNode.transform.localPosition = new Vector3(40 - parentWdith / 2 + width / 2f, -30f * nodeIndex - 30, 0);
            }
        }
    }
    public void UpdateTree(int vehicleIndex = 0)
    {
        for (int i = transform.childCount-1; i > 1; i--) // ignore first two sample gameobject
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        if (GameObject.Find("VehicleSpace").transform.childCount != 0)
        {
            _targetVis = GameObject.Find("VehicleSpace").transform.GetChild(vehicleIndex).Find("Vis");
            FindNode(_targetVis, transform);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        MyRoot = GetComponent<TreeNode>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
