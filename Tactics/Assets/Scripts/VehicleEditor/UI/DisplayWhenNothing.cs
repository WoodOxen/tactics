using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWhenNothing : MonoBehaviour
{
    public GameObject Dir;
    public int EmptyNum;

    private TMPro.TextMeshProUGUI _tmp;
    // Start is called before the first frame update
    void Start()
    {
        _tmp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _tmp.enabled = Dir.transform.childCount <= EmptyNum;
    }
}
