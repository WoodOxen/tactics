using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor.Localization.Plugins.Google.Columns;
using TMPro;
using VehiclePhysics;
using UnityEditor;

public class EditorManager : MonoBehaviour
{
    // type 0 for "saving, type 1 for model
    public int LoadType = 0;


    private void LoadJson()
    {
        GameObject loader = GameObject.Find("JsonReader");
        JsonReader jr = loader.GetComponent<JsonReader>();
        VehicleConstructor vc = loader.GetComponent<VehicleConstructor>();
        TMPro.TMP_Dropdown dropdown = GameObject.Find("UI").transform.Find("Bar").Find("Dropdown").gameObject.GetComponent<TMPro.TMP_Dropdown>();
        jr.SavesDir = dropdown.options[dropdown.value].text;
        jr.ReadJson();
        vc.PlaceVehicle(GameObject.Find("VehicleSpace").transform, SceneManager.GetActiveScene().name == "Editor");
    }
    private void UpdateFileList(int type)
    {
        ReadFileList rfl = GameObject.Find("UI").transform.Find("Bar").Find("Dropdown").gameObject.GetComponent<ReadFileList>();
        switch (type)
        {
            case 0:
                rfl.ReadDir(Application.streamingAssetsPath + "/Saves/");
                break;
            case 1:
                rfl.ReadDir(Application.streamingAssetsPath + "/Model/");
                break;
            default:
                break;
        }
    }
    
    public void UnSelectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void TogglePlayVehicle(GameObject textObject)
    {
        TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
        try
        {
            GameObject vehicle = GameObject.Find("VehicleSpace").transform.GetChild(0).gameObject;
            if (text.text == "Play")
            {
                try
                {
                    vehicle.GetComponent<Rigidbody>().isKinematic = false;
                    vehicle.GetComponent<VPStandardInput>().enabled = true;
                    text.text = "Stop";
                }
                catch { }
            }
            else
            {
                try
                {
                    DeleteVehicle();
                    Load();
                    text.text = "Play";
                }
                catch { }
            }
        }
        catch { return; }
        
    }
    public void SelectObject(GameObject button)
    {
        GameObject targetObject = button.GetComponent<TreeNode>().MappedObject;
        
    }
    public void SwitchLoadType()
    {
        TMPro.TextMeshProUGUI selectionName = GameObject.Find("UI").transform.Find("Bar").Find("Selection").Find("text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if (LoadType == 0)
        {
            LoadType = 1;
            selectionName.text = "Model";
        }
        else
        {
            LoadType = 0;
            selectionName.text = "Saving";
        }
        UpdateFileList(LoadType);
    }
    public void ToggleEscConfirm()
    {
        GameObject confirm = GameObject.Find("Exit Confirm Window").transform.Find("Panel").gameObject;
        GameObject ui = GameObject.Find("UI");
        confirm.SetActive(!confirm.activeSelf);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Load()
    {
        if (LoadType == 0)
        {
            // load saves
            LoadJson();
        }
        else
        {
            // load model only
        }
    }


    public void DeleteVehicle()
    {
        GameObject space = GameObject.Find("VehicleSpace");
        if (space.transform.childCount != 0)
        {
            DestroyImmediate(space.transform.GetChild(0).gameObject);
        }
        space = GameObject.Find("PreviewSpace");
        if (space.transform.childCount != 0)
        {
            DestroyImmediate(space.transform.GetChild(0).gameObject);
        }
    }

    public void ToggleOrthographic()
    {
        Camera.main.orthographic = !Camera.main.orthographic;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscConfirm();
        }
    }
}
