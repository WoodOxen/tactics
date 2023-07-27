using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorContentManager : MonoBehaviour
{
    private int _tabStatus = 0;

    public GameObject ModelTab;
    public GameObject PhysicsTab;
    
    public void SwitchTab(int status)
    {
        if (status == _tabStatus)
        {
            return;
        }
        _tabStatus = status;
        switch (status)
        {
            case 0:
                ModelTab.GetComponent<Image>().color = new Color(1, 1, 1, 0.04f);
                PhysicsTab.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                ModelTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.SmallCaps;
                PhysicsTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.SmallCaps;
                break;
            case 1:
                ModelTab.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                PhysicsTab.GetComponent<Image>().color = new Color(1, 1, 1, 0.04f);
                PhysicsTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.SmallCaps;
                ModelTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.SmallCaps;
                break;
            default:
                break;
        }
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
