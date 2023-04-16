using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusicVolume (float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetEffectVolume (float volume)
    {
        audioMixer.SetFloat("EffectVolume", volume);
    }

    public void SetUIVolume (float volume)
    {
        audioMixer.SetFloat("UIVolume", volume);
    }
}
