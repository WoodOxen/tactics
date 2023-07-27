using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode : MonoBehaviour
{
    public bool IsLeaf;
    public bool Fold = true;
    public int Depth = 0;
    public bool NeedUpdate = true;
    public GameObject MappedObject;

    private void ReassginSiblings(Transform t, int spareLine)
    {
        for (int i = t.GetSiblingIndex() + 1; i < t.parent.childCount; i++)
        {
            t.parent.GetChild(i).transform.localPosition += Vector3.down * spareLine * TreeConstants.SeperateDist * (Fold ? -1 : 1);
        }
        if (t.parent.GetComponent<TreeNode>().Depth != 0)
        {
            ReassginSiblings(t.parent, spareLine);
        }
    }

    public int CountSpareLine(Transform root)
    {
        int count = 0;
        foreach (Transform child in root)
        {
            TreeNode childTN = child.GetComponent<TreeNode>();
            if (childTN && child.name != "SampleNode")
            {
                count++;
                if (!childTN.IsLeaf && !childTN.Fold)
                {
                    count += CountSpareLine(child);
                }
            }
        }
        return count;
    }

    public void ToggleFold()
    {
        if (!IsLeaf)
        {
            Fold = !Fold;
            NeedUpdate = true;
            // when unfold, tell parent nodes to spare space
            int spareLine = CountSpareLine(transform);
            //move down siblings and siblings in parent
            ReassginSiblings(transform,spareLine);
            

        }
    }

    public void UpdateVisible()
    {
        if (Fold)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "SampleNode" || child.name == "Other" || child.name == "text")
                {
                    continue;
                }
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                if (child.name == "SampleNode" || child.name == "Other" || child.name == "text")
                {
                    continue;
                }
                child.gameObject.SetActive(true);
            }
        }
    }

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateVisible();
    }

    // Update is called once per frame
    void Update()
    {
        if (NeedUpdate)
        {
            NeedUpdate = false;
            UpdateVisible();
        }
    }
}
