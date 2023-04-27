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
using TMPro;

public class GraphicsSetting : MonoBehaviour
{
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private TMP_Text resoluationLabel;
    [SerializeField] private TMP_Text qualityLabel;
    [SerializeField] private TMP_Text fpsLabel;
    private List<Resolution> resolutionList = new List<Resolution>();
    private int resolutionIndex = 0;
    private string[] qualityList = { "Low", "Medium", "High" };
    private int qualityIndex = 2;
    private int[] fpsList = { 30, 50, 60, 120, 240 };
    private int fpsIndex = 2;

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
        GetResolutions();
        if (PlayerPrefs.HasKey("ResolutionX") && PlayerPrefs.HasKey("ResolutionY"))
        {
            LoadResolution();
            UpdateResolutionLabel();
        }
        else
        {
            SetResolution();
            UpdateResolutionLabel();
        }

        // Initialize the graphic quality
        if (PlayerPrefs.HasKey("Quality"))
        {
            LoadQuality();
            UpdateQualityLabel();
        }
        else
        {
            SetQuality();
            UpdateQualityLabel();
        }

        // Initialize the fps
        if (PlayerPrefs.HasKey("FPS"))
        {
            LoadFPS();
            UpdateFPSLabel();
        }
        else
        {
            SetFPS();
            UpdateFPSLabel();
        }
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

    /// @fn GetResolutions
    /// @brief Get all the resolutions supported by the monitor.
    private void GetResolutions ()
    {
        Resolution defaultResolution = new Resolution();
        defaultResolution.width = Screen.width;
        defaultResolution.height = Screen.height;
        resolutionList.Add(defaultResolution);
    }

    public void PreviousResolution ()
    {
        resolutionIndex -- ;
        if (resolutionIndex < 0)
        {
            resolutionIndex = resolutionList.Count - 1;
        }
        SetResolution();
        UpdateResolutionLabel();
    }

    public void NextResolution ()
    {
        resolutionIndex ++ ;
        if (resolutionIndex >= resolutionList.Count)
        {
            resolutionIndex = 0;
        }
        SetResolution();
        UpdateResolutionLabel();
    }

    private void SetResolution ()
    {
        Screen.SetResolution(
            resolutionList[resolutionIndex].width, 
            resolutionList[resolutionIndex].height, 
            Screen.fullScreen
        );
        PlayerPrefs.SetInt("ResolutionX", resolutionList[resolutionIndex].width);
        PlayerPrefs.SetInt("ResolutionY", resolutionList[resolutionIndex].height);
    }

    private void LoadResolution ()
    {
        Screen.SetResolution(
            PlayerPrefs.GetInt("ResolutionX"), 
            PlayerPrefs.GetInt("ResolutionY"), 
            Screen.fullScreen
        );
    }

    private void UpdateResolutionLabel ()
    {
        resoluationLabel.text = resolutionList[resolutionIndex].width + " x " + resolutionList[resolutionIndex].height;
    }

    public void PreviousQuality ()
    {
        qualityIndex -- ;
        if (qualityIndex < 0)
        {
            qualityIndex = qualityList.Length - 1;
        }
        SetQuality();
        UpdateQualityLabel();
    }

    public void NextQuality ()
    {
        qualityIndex ++ ;
        if (qualityIndex >= qualityList.Length)
        {
            qualityIndex = 0;
        }
        SetQuality();
        UpdateQualityLabel();
    }

    private void SetQuality ()
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    private void LoadQuality ()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
    }

    private void UpdateQualityLabel ()
    {
        qualityLabel.text = qualityList[qualityIndex];
    }

    public void PreviousFPS ()
    {
        fpsIndex -- ;
        if (fpsIndex < 0)
        {
            fpsIndex = fpsList.Length - 1;
        }
        SetFPS();
        UpdateFPSLabel();
    }

    public void NextFPS ()
    {
        fpsIndex ++ ;
        if (fpsIndex >= fpsList.Length)
        {
            fpsIndex = 0;
        }
        SetFPS();
        UpdateFPSLabel();
    }

    private void SetFPS ()
    {
        Application.targetFrameRate = fpsList[fpsIndex];
        PlayerPrefs.SetInt("FPS", fpsList[fpsIndex]);
    }

    private void LoadFPS ()
    {
        Application.targetFrameRate = PlayerPrefs.GetInt("FPS");
    }

    private void UpdateFPSLabel ()
    {
        fpsLabel.text = fpsList[fpsIndex].ToString();
    }
}