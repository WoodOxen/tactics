using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorContentManager : MonoBehaviour
{
    private int _tabStatus = 0;

    public GameObject ModelTab;
    public GameObject PhysicsTab;

    public GameObject ModelContent;
    public GameObject PhysicsContent;
    
    public void SwitchTab(int status)
    {
        if (status == _tabStatus)
        {
            return;
        }
        if (status != -1) {
            _tabStatus = status;
        }
        switch (_tabStatus)
        {
            case 0:
                ModelTab.GetComponent<Image>().color = new Color(1, 1, 1, 0.04f);
                PhysicsTab.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                ModelTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.SmallCaps;
                PhysicsTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.SmallCaps;

                ModelContent.SetActive(true);
                PhysicsContent.SetActive(false);

                break;
            case 1:
                ModelTab.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
                PhysicsTab.GetComponent<Image>().color = new Color(1, 1, 1, 0.04f);
                PhysicsTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Underline | TMPro.FontStyles.SmallCaps;
                ModelTab.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.SmallCaps;

                ModelContent.SetActive(false);
                PhysicsContent.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void UpdateTab()
    {
        SwitchTab(-1);
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
