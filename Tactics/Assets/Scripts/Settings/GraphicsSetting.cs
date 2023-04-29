/**
 * @file GraphicsSetting.cs
 * @brief Controls the volume of the music and effects mixer groups.
 * @author Yueyuan Li
 * @date 2023-04-28
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsSetting : MonoBehaviour
{
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private TMP_Text resolutionLabel;
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
        // Initialize the full screen option from the player's preference.
        // If the player has not set the option, set it to full screen.
        if (PlayerPrefs.HasKey("FullScreen"))
        {
            LoadFullScreen();
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 1);
            SetFullScreen();
        }

        // Initialize the vSync option from the player's preference.
        // If the player has not set the option, set it to vSync.
        if (PlayerPrefs.HasKey("VSync"))
        {
            LoadVSync();
        }
        else
        {
            PlayerPrefs.SetInt("VSync", 1);
            SetVSync();
        }

        // Initialize the resolution option from the player's preference.
        // If the player has not set the option, set it to the current resolution.
        GetResolutions();
        if (PlayerPrefs.HasKey("Resolution"))
        {
            LoadResolution();
            
        }
        else
        {
            SetResolution();
        }
        UpdateResolutionLabel();

        // Initialize the graphic quality option from the player's preference.
        // If the player has not set the option, set it to high.
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

        // Initialize the fps option from the player's preference.
        // If the player has not set the option, set it to 60.
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

    /// @fn SetFullScreen
    /// @brief Immediately sets the screen to full screen or windowed mode and updates 
    /// the setting to the player's preference.
    /// @details The corresponding key is "FullScreen".
    public void SetFullScreen ()
    {
        Screen.fullScreenMode = fullScreenToggle.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        PlayerPrefs.SetInt("FullScreen", fullScreenToggle.isOn ? 1 : 0);
    }

    /// @fn LoadFullScreen
    /// @brief Load the player's preference for full screen mode. Update the toggle to
    /// the corresponding status.
    private void LoadFullScreen ()
    {
        fullScreenToggle.isOn = PlayerPrefs.GetInt("FullScreen") == 1 ? true : false;
        Screen.fullScreenMode = fullScreenToggle.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    /// @fn SetVSync
    /// @brief Immediately sets the vSync option and updates the setting to the player's 
    /// preference.
    /// @details The corresponding key is "VSync".
    public void SetVSync ()
    {
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
        PlayerPrefs.SetInt("VSync", vSyncToggle.isOn ? 1 : 0);
    }

    /// @fn LoadVSync
    /// @brief Load the player's preference for vSync option. Update the toggle to the
    /// corresponding status.
    private void LoadVSync ()
    {
        vSyncToggle.isOn = PlayerPrefs.GetInt("VSync") == 1 ? true : false;
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
    }

    /// @fn GetResolutions
    /// @brief Generate a list of resolutions that are compatible with the screen.
    /// @details This functions contains a list of default screen proportion and a list of 
    /// default screen height. The first resolution option the player sees is the current
    /// screen resolution. The rest of the options are determined by the following steps:
    /// 
    /// 1. Find the default screen proportion that is closest to the current screen proportion.
    /// 2. Get all the default heights that are smaller than the current screen height.
    /// 3. For each default height, calculate the width based on the screen proportion.
    /// 4. If the width is not an integer, skip this height.
    /// 5. Add the resolution to the list.
    /// 6. If the list has more than 10 options, stop.
    private void GetResolutions ()
    {
        Resolution defaultResolution = new Resolution();
        defaultResolution.width = Screen.width;
        defaultResolution.height = Screen.height;
        resolutionList.Add(defaultResolution);

        var proportionList = new List<(float, float)> {(3,2), (4,3), (5,4), (16, 9), (16, 10)};
        float[] height = {1920, 1440, 900, 768, 480, 240};
        float screenWidth = Convert.ToSingle(Screen.width);
        float screenHeight = Convert.ToSingle(Screen.height);
        float screenProportion = screenWidth / screenHeight;

        proportionList.Sort(
            (x, y) => (Math.Abs(x.Item1 / x.Item2 - screenProportion)).CompareTo(
                Math.Abs(y.Item1 / y.Item2 - screenProportion)
            )
        );

        foreach (var proportion in proportionList)
        {
            foreach (var h in height)
            {
                if (h <= screenHeight)
                {
                    float w = h * proportion.Item1 / proportion.Item2;
                    if (w - Math.Floor(w) > 0.1)
                    {
                        continue;
                    }
                    Resolution resolution = new Resolution();
                    resolution.width = Convert.ToInt32(w);
                    resolution.height = Convert.ToInt32(h);
                    resolutionList.Add(resolution);
                }
                if (resolutionList.Count >= 10)
                {
                    break;
                }
            }
        }
    }

    public void SwitchResolution (int switchDirection)
    {
        resolutionIndex += switchDirection ;
        if (resolutionIndex < 0)
        {
            resolutionIndex = resolutionList.Count - 1;
        }
        else if (resolutionIndex >= resolutionList.Count)
        {
            resolutionIndex = 0;
        }
        SetResolution();
        UpdateResolutionLabel();
    }

    /// @fn SetResolution
    /// @brief Immediately update the screen resolution and save it the the player's preference.
    /// @details The corresponding keys are: 
    /// {
    ///     "ResolutionX": horizontal resolution,
    ///     "ResolutionY": vertical resolution,
    ///     "Resolution": index of the resolution in the generated resolution list
    /// }
    private void SetResolution ()
    {
        Screen.SetResolution(
            resolutionList[resolutionIndex].width, 
            resolutionList[resolutionIndex].height, 
            Screen.fullScreen
        );
        PlayerPrefs.SetInt("ResolutionX", resolutionList[resolutionIndex].width);
        PlayerPrefs.SetInt("ResolutionY", resolutionList[resolutionIndex].height);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    /// @fn LoadResolution
    /// @brief Load the player's preference for screen resolution.
    private void LoadResolution ()
    {
        resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        Screen.SetResolution(
            PlayerPrefs.GetInt("ResolutionX"), 
            PlayerPrefs.GetInt("ResolutionY"), 
            Screen.fullScreen
        );
    }

    /// @fn UpdateResolutionLabel
    /// @brief Update the text displayed for the resolution option.
    private void UpdateResolutionLabel ()
    {
        resolutionLabel.text = (
            resolutionList[resolutionIndex].width + " x " + resolutionList[resolutionIndex].height
        );
    }

    public void SwitchQuality (int switchDirection)
    {
        qualityIndex += switchDirection ;
        if (qualityIndex < 0)
        {
            qualityIndex = qualityList.Length - 1;
        }
        else if (qualityIndex >= qualityList.Length)
        {
            qualityIndex = 0;
        }
        SetQuality();
        UpdateQualityLabel();
    }

    /// @fn SetQuality
    /// @brief Immediately update the graphic quality and save it the the player's preference.
    /// @details The corresponding key is "Quality".
    private void SetQuality ()
    {
        int qualityLevel = qualityIndex * 2 + 1;
        QualitySettings.SetQualityLevel(qualityLevel, true);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    /// @fn LoadQuality
    /// @brief Load the player's preference for graphic quality.
    private void LoadQuality ()
    {
        qualityIndex = PlayerPrefs.GetInt("Quality");
        int qualityLevel = qualityIndex * 2 + 1;
        QualitySettings.SetQualityLevel(qualityLevel, true);
    }

    /// @fn UpdateQualityLabel
    /// @brief Update the text displayed for the quality option.
    private void UpdateQualityLabel ()
    {
        qualityLabel.text = qualityList[qualityIndex];
    }

    public void SwitchFPS (int switchDirection)
    {
        fpsIndex += switchDirection ;
        if (fpsIndex < 0)
        {
            fpsIndex = fpsList.Length - 1;
        }
        else if (fpsIndex >= fpsList.Length)
        {
            fpsIndex = 0;
        }
        SetFPS();
        UpdateFPSLabel();
    }

    /// @fn SetFPS
    /// @brief Immediately update the FPS and save it the the player's preference.
    /// @details The corresponding key is "FPS".
    private void SetFPS ()
    {
        Application.targetFrameRate = fpsList[fpsIndex];
        PlayerPrefs.SetInt("FPS", fpsIndex);
    }

    /// @fn LoadFPS
    /// @brief Load the player's preference for FPS.
    private void LoadFPS ()
    {
        fpsIndex = PlayerPrefs.GetInt("FPS");
        Application.targetFrameRate = fpsList[fpsIndex];
    }

    /// @fn UpdateFPSLabel
    /// @brief Update the text displayed for the FPS option.
    private void UpdateFPSLabel ()
    {
        fpsLabel.text = fpsList[fpsIndex].ToString();
    }
}