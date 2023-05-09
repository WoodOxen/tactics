using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EditorManager : MonoBehaviour
{
    public void UnSelectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ToggleEscConfirm()
    {
        GameObject confirm = GameObject.Find("UI").transform.Find("Exit Confirm Window").gameObject;
        GameObject ui = GameObject.Find("UI");
        confirm.SetActive(!confirm.activeSelf);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadJson()
    {
        GameObject loader = GameObject.Find("JsonReader");
        JsonReader jr = loader.GetComponent<JsonReader>();
        VehicleConstructor vc = loader.GetComponent<VehicleConstructor>();
        TMPro.TMP_Dropdown dropdown = GameObject.Find("UI").transform.Find("Bar").Find("Dropdown").gameObject.GetComponent<TMPro.TMP_Dropdown>();
        jr.SavesDir = dropdown.options[dropdown.value].text;
        jr.ReadJson();
        vc.PlaceVehicle(GameObject.Find("VehicleSpace").transform, SceneManager.GetActiveScene().name == "Editor");

    }

    public void DeleteVehicle()
    {
        GameObject space = GameObject.Find("VehicleSpace");
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
