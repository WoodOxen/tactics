/**
 * @file AudioSystem.cs
 * @brief
 * @author Yueyuan Li
 * @author Yuhang Li
 * @date 2023-04-29
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Instance;
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup effectsMixerGroup;

    private void Awake()
    {
    }
}
