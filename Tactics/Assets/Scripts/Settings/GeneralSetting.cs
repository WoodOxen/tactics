/**
 * @file GeneralSetting.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-04-29
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;

public class GeneralSetting : MonoBehaviour
{
    [SerializeField] private TMP_Text localeLabel;
    private string[] availableLocales = {"English", "中文"};
    private int localeIndex = 0;

    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchLocale (int switchDirection)
    {
        int localeCount = LocalizationSettings.AvailableLocales.Locales.Count;
        localeIndex += switchDirection;
        if (localeIndex < 0)
        {
            localeIndex = localeCount - 1;
        }
        else if (localeIndex >= localeCount)
        {
            localeIndex = 0;
        }
        SetLocale();
        UpdateLocaleLabel();
    }

    private void SetLocale ()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
        PlayerPrefs.SetInt("Locale", localeIndex);
    }

    private void LoadLocale ()
    {
        localeIndex = PlayerPrefs.GetInt("Locale");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
    }

    private void UpdateLocaleLabel ()
    {
        localeLabel.text = LocalizationSettings.AvailableLocales.Locales[localeIndex].Identifier.CultureInfo.NativeName;
    }
}
