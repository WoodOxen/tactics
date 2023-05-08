using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode : MonoBehaviour
{
    public bool IsLeaf;
    public bool Fold = true;
    public int Depth = 0;

    public bool NeedUpdate = true;


    private GameObject _parent;

    public void ToggleFold()
    {
        if (!IsLeaf)
        {
            Fold = !Fold;
            NeedUpdate = true;
        }
    }

    public void UpdateVisible()
    {
        if (Fold)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "SampleNode" || child.name == "SampleText" || child.name == "text")
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
                if (child.name == "SampleNode" || child.name == "SampleText" || child.name == "text")
                {
                    continue;
                }
                child.gameObject.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        _parent = transform.parent.gameObject;
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
