/**
 * @file GeneralSetting.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-04-29
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;

namespace Tactics.Settings
{
    public class GeneralSetting : MonoBehaviour
    {
        [SerializeField] private TMP_Text localeLabel;
        [SerializeField] private TMP_InputField savePathInputField;
        [SerializeField] private TMP_InputField scriptPathInputField;
        private int _localeIndex = 0;
        private string _savePath;
        private string _scriptPath;
        private string _defaultPath;

        void Start()
        {
            // Initialize the localization system
            LocalizationSettings.InitializationOperation.WaitForCompletion();

            if (PlayerPrefs.HasKey("Locale"))
            {
                LoadLocale();
            }
            else
            {
                SetLocale();
            }
            UpdateLocaleLabel();

            _defaultPath = Application.dataPath;
            // Initialize the save path
            if (PlayerPrefs.HasKey("SavePath"))
            {
                LoadSavePath();
            }
            else
            {
                SetSavePath();
            }

            // Initialize the script path
            if (PlayerPrefs.HasKey("ScriptPath"))
            {
                LoadScriptPath();
            }
            else
            {
                SetScriptPath();
            }
        }

        private void SetLocale()
        {
            LocalizationSettings.SelectedLocale = (
                LocalizationSettings.AvailableLocales.Locales[_localeIndex]
            );
            PlayerPrefs.SetInt("Locale", _localeIndex);
        }

        private void LoadLocale()
        {
            _localeIndex = PlayerPrefs.GetInt("Locale");
            LocalizationSettings.SelectedLocale = (
                LocalizationSettings.AvailableLocales.Locales[_localeIndex]
            );
        }

        public void SwitchLocale(int switchDirection)
        {
            int localeCount = LocalizationSettings.AvailableLocales.Locales.Count;
            _localeIndex += switchDirection;

            if (_localeIndex < 0)
            {
                _localeIndex = localeCount - 1;
            }
            else if (_localeIndex >= localeCount)
            {
                _localeIndex = 0;
            }

            SetLocale();
            UpdateLocaleLabel();
        }

        private void UpdateLocaleLabel()
        {
            var locales = LocalizationSettings.AvailableLocales.Locales;
            localeLabel.text = locales[_localeIndex].Identifier.CultureInfo.NativeName;
        }

        private string GetValidPath(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                string warning = "The path is invalid. Reset to default.";
                Debug.LogWarning(warning);
                return _defaultPath;
            }
            return path;
        }

        private void LoadSavePath()
        {
            _savePath = GetValidPath(PlayerPrefs.GetString("SavePath"));
            UpdateSavePath();
        }

        public void SetSavePath()
        {
            _savePath = savePathInputField.text;
            PlayerPrefs.SetString("SavePath", GetValidPath(_savePath));
            UpdateSavePath();
        }

        private void UpdateSavePath()
        {
            savePathInputField.text = _savePath;
        }

        private void LoadScriptPath()
        {
            _scriptPath = GetValidPath(PlayerPrefs.GetString("ScriptPath"));
            UpdateScriptPath();
        }

        public void SetScriptPath()
        {
            _scriptPath = scriptPathInputField.text;
            PlayerPrefs.SetString("ScriptPath", GetValidPath(_scriptPath));
            UpdateScriptPath();
        }

        private void UpdateScriptPath()
        {
            scriptPathInputField.text = _scriptPath;
        }
    }
}
