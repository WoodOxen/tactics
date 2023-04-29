/**
 * @file AudioSetting.cs
 * @brief Controls the volume of the music and effects mixer groups.
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// @class AudioSetting
/// @brief Controls the volume of the music and effects mixer groups.
public class AudioSetting : MonoBehaviour
{
    /// The AudioMixer to control volumes in Tactics. 
    /// The Mixer has two exposed parameters: MusicVolume and EffectsVolume
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.75f);
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            LoadEffectsVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("EffectsVolume", 0.75f);
            SetEffectsVolume();
        }
    }

    /// @fn SetMusicVolume
    /// @brief Set the volume of the music mixer group to the value of the music slider.
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    /// @fn LoadMusicVolume
    /// @brief Load the volume of the music mixer group from PlayerPrefs.
    private void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();
    }

    /// @fn SetEffectsVolume
    /// @brief Set the volume of the effects mixer group to the value of the effects slider.
    public void SetEffectsVolume()
    {
        float volume = effectsSlider.value;
        mainMixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }

    /// @fn LoadEffectsVolume
    /// @brief Load the volume of the effects mixer group from PlayerPrefs.
    private void LoadEffectsVolume()
    {
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        SetEffectsVolume();
    }
}
