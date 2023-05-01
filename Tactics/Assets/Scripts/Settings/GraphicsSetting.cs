/**
 * @file GraphicsSetting.cs
 * @brief This script is used to set the graphics options in the settings menu.
 * @author Yueyuan Li
 * @date 2023-04-28
 * @copyright GNU Public License
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tactics.Settings
{
    /**
    * @class GraphicsSetting
    * @brief Controls the graphics settings including full-screen, vSync, resolution, quality, and FPS.
    */
    public class GraphicsSetting : MonoBehaviour
    {
        [SerializeField] private Toggle fullScreenToggle;
        [SerializeField] private Toggle vSyncToggle;
        [SerializeField] private TMP_Text resolutionLabel;
        [SerializeField] private TMP_Text qualityLabel;
        [SerializeField] private TMP_Text fpsLabel;
        private List<Resolution> _resolutions = new List<Resolution>();
        private int _resolutionIndex = 0;
        private string[] _qualityLevels = { "Low", "Medium", "High" };
        private int _qualityIndex = 2;
        private int[] _fps = { 30, 50, 60, 120, 240 };
        private int _fpsIndex = 2;

        void Start()
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
            GetResolution();
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
        public void SetFullScreen()
        {
            Screen.fullScreenMode = (
                fullScreenToggle.isOn ?
                FullScreenMode.FullScreenWindow : FullScreenMode.Windowed
            );
            PlayerPrefs.SetInt("FullScreen", fullScreenToggle.isOn ? 1 : 0);
        }

        /// @fn LoadFullScreen
        /// @brief Load the player's preference for full screen mode. Update the toggle to
        /// the corresponding status.
        private void LoadFullScreen()
        {
            fullScreenToggle.isOn = PlayerPrefs.GetInt("FullScreen") == 1 ? true : false;
            Screen.fullScreenMode = (
                fullScreenToggle.isOn ?
                FullScreenMode.FullScreenWindow : FullScreenMode.Windowed
            );
        }

        /// @fn SetVSync
        /// @brief Immediately sets the vSync option and updates the setting to the player's 
        /// preference.
        /// @details The corresponding key is "VSync".
        public void SetVSync()
        {
            QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
            PlayerPrefs.SetInt("VSync", vSyncToggle.isOn ? 1 : 0);
        }

        /// @fn LoadVSync
        /// @brief Load the player's preference for vSync option. Update the toggle to the
        /// corresponding status.
        private void LoadVSync()
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
        private void GetResolution()
        {
            Resolution defaultResolution = new Resolution();
            defaultResolution.width = Screen.width;
            defaultResolution.height = Screen.height;
            _resolutions.Add(defaultResolution);

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
                    if (h > screenHeight) continue;

                    float w = h * proportion.Item1 / proportion.Item2;

                    if (w - Math.Floor(w) > 0.1) continue;

                    Resolution resolution = new Resolution();
                    resolution.width = Convert.ToInt32(w);
                    resolution.height = Convert.ToInt32(h);
                    _resolutions.Add(resolution);

                    if (_resolutions.Count >= 10) break;
                }
            }
        }

        /// @fn SetResolution
        /// @brief Immediately update the screen resolution and save it the the player's preference.
        /// @details The corresponding keys are: 
        /// {
        ///     "ResolutionX": horizontal resolution,
        ///     "ResolutionY": vertical resolution,
        ///     "Resolution": index of the resolution in the generated resolution list
        /// }
        private void SetResolution()
        {
            Screen.SetResolution(
                _resolutions[_resolutionIndex].width, 
                _resolutions[_resolutionIndex].height, 
                Screen.fullScreen
            );
            PlayerPrefs.SetInt("ResolutionX", _resolutions[_resolutionIndex].width);
            PlayerPrefs.SetInt("ResolutionY", _resolutions[_resolutionIndex].height);
            PlayerPrefs.SetInt("Resolution", _resolutionIndex);
        }

        /// @fn LoadResolution
        /// @brief Load the player's preference for screen resolution.
        private void LoadResolution()
        {
            _resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
            Screen.SetResolution(
                PlayerPrefs.GetInt("ResolutionX"), 
                PlayerPrefs.GetInt("ResolutionY"), 
                Screen.fullScreen
            );
        }

        public void SwitchResolution(int switchDirection)
        {
            _resolutionIndex += switchDirection ;
            if (_resolutionIndex < 0)
            {
                _resolutionIndex = _resolutions.Count - 1;
            }
            else if (_resolutionIndex >= _resolutions.Count)
            {
                _resolutionIndex = 0;
            }
            SetResolution();
            UpdateResolutionLabel();
        }

        /// @fn UpdateResolutionLabel
        /// @brief Update the text displayed for the resolution option.
        private void UpdateResolutionLabel()
        {
            resolutionLabel.text = (
                _resolutions[_resolutionIndex].width + " x " + _resolutions[_resolutionIndex].height
            );
        }

        /// @fn SetQuality
        /// @brief Immediately update the graphic quality and save it the the player's preference.
        /// @details The corresponding key is "Quality".
        private void SetQuality()
        {
            int qualityLevel = _qualityIndex * 2 + 1;
            QualitySettings.SetQualityLevel(qualityLevel, true);
            PlayerPrefs.SetInt("Quality", _qualityIndex);
        }

        /// @fn LoadQuality
        /// @brief Load the player's preference for graphic quality.
        private void LoadQuality()
        {
            _qualityIndex = PlayerPrefs.GetInt("Quality");
            int qualityLevel = _qualityIndex * 2 + 1;
            QualitySettings.SetQualityLevel(qualityLevel, true);
        }

        public void SwitchQuality(int switchDirection)
        {
            _qualityIndex += switchDirection;

            if (_qualityIndex < 0)
            {
                _qualityIndex = _qualityLevels.Length - 1;
            }
            else if (_qualityIndex >= _qualityLevels.Length)
            {
                _qualityIndex = 0;
            }
            SetQuality();
            UpdateQualityLabel();
        }

        /// @fn UpdateQualityLabel
        /// @brief Update the text displayed for the quality option.
        private void UpdateQualityLabel ()
        {
            qualityLabel.text = _qualityLevels[_qualityIndex];
        }

        /// @fn SetFPS
        /// @brief Immediately update the FPS and save it the the player's preference.
        /// @details The corresponding key is "FPS".
        private void SetFPS()
        {
            Application.targetFrameRate = _fps[_fpsIndex];
            PlayerPrefs.SetInt("FPS", _fpsIndex);
        }

        /// @fn LoadFPS
        /// @brief Load the player's preference for FPS.
        private void LoadFPS()
        {
            _fpsIndex = PlayerPrefs.GetInt("FPS");
            Application.targetFrameRate = _fps[_fpsIndex];
        }

        public void SwitchFPS(int switchDirection)
        {
            _fpsIndex += switchDirection ;
            if (_fpsIndex < 0)
            {
                _fpsIndex = _fps.Length - 1;
            }
            else if (_fpsIndex >= _fps.Length)
            {
                _fpsIndex = 0;
            }
            SetFPS();
            UpdateFPSLabel();
        }

        /// @fn UpdateFPSLabel
        /// @brief Update the text displayed for the FPS option.
        private void UpdateFPSLabel()
        {
            fpsLabel.text = _fps[_fpsIndex].ToString();
        }
    }
}