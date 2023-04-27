/**
 * @file GraphicsSetting.cs
 * @brief Controls the volume of the music and effects mixer groups.
 * @author Yueyuan Li
 * @date 2023-04-23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSetting : MonoBehaviour
{
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Dropdown textureQualityDropdown;
    [SerializeField] private Dropdown fpsDropdown;
    public List<Resolution> resolutions = new List<Resolution>();

    void Start ()
    {
        // Initialize the full screen option
        if (PlayerPrefs.HasKey("FullScreen"))
        {
            LoadFullScreen();
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 1);
            SetFullScreen();
        }

        // Initialize the vSync option
        if (PlayerPrefs.HasKey("VSync"))
        {
            LoadVSync();
        }
        else
        {
            PlayerPrefs.SetInt("VSync", 1);
            SetVSync();
        }

        // Initialize the resolution
    }

    public void SetFullScreen ()
    {
        PlayerPrefs.SetInt("FullScreen", fullScreenToggle.isOn ? 1 : 0);
        Screen.fullScreen = PlayerPrefs.GetInt("FullScreen") == 1 ? true : false;
    }

    private void LoadFullScreen ()
    {
        fullScreenToggle.isOn = PlayerPrefs.GetInt("FullScreen") == 1 ? true : false;
        Screen.fullScreen = PlayerPrefs.GetInt("FullScreen") == 1 ? true : false;
    }

    public void SetVSync ()
    {
        PlayerPrefs.SetInt("VSync", vSyncToggle.isOn ? 1 : 0);
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
    }

    private void LoadVSync ()
    {
        vSyncToggle.isOn = PlayerPrefs.GetInt("VSync") == 1 ? true : false;
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
    }


}

[System.Serializable]
public class Resolution
{
    public int horizontal;
    public int vertical;
}