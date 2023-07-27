using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class TreeConstants
{
    public const int CharWidth = 15;
    public const int SeperateDist = 40;
    public const int TabDist = 40;
    public const int FrameHeight = 36;
    public const int textHeadMargin = 10;
}

public class ModelTreeManager: MonoBehaviour
{
    private Transform _targetVis;


    public TreeNode MyRoot;

    public void FindNode(Transform root, Transform mirrorRoot, int depth = 0)
    {
        foreach (Transform node in root)
        {
            GameObject mirrorNode = (GameObject)Instantiate(mirrorRoot.GetChild(1).gameObject, mirrorRoot);//mirrorRoot.GetChild(1) is the template node GameObject
            mirrorNode.SetActive(true);

            int nodeIndex = mirrorNode.transform.GetSiblingIndex() - 2;

            TreeNode tn = mirrorNode.GetComponent<TreeNode>();
            tn.IsLeaf = false;
            tn.Depth = depth + 1;
            tn.MappedObject = node.gameObject;

            TMPro.TextMeshProUGUI mirrorNodeTMP = mirrorNode.transform.Find("text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            mirrorNodeTMP.text = node.name;
            mirrorNodeTMP.fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.Bold;

            int width = node.name.Length * TreeConstants.CharWidth + TreeConstants.textHeadMargin;
            mirrorNode.GetComponent<RectTransform>().sizeDelta = new Vector2(width, TreeConstants.FrameHeight);

            int parentWdith = root.name.Length * TreeConstants.CharWidth + TreeConstants.textHeadMargin;

            mirrorNode.transform.localPosition = new Vector3(TreeConstants.TabDist - parentWdith / 2 + width / 2f,
                                                            -TreeConstants.SeperateDist * nodeIndex - TreeConstants.SeperateDist,
                                                            0);

            if (node.childCount != 0) // has child
            {
                mirrorNode.name = "node(" + nodeIndex + ")__" + node.name;
                GameObject mirrorNodeSample = (GameObject)Instantiate(mirrorRoot.transform.GetChild(1).gameObject, mirrorNode.transform);
                mirrorNodeSample.name = "SampleNode";
                FindNode(node, mirrorNode.transform, depth+1);
            }
            else // is leaf
            {
                mirrorNode.name = "leaf(" + nodeIndex + ")__" + node.name;
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
