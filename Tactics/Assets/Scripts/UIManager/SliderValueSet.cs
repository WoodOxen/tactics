using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueSet : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderName;

    // Update is called once per frame
    void Update()
    {
        string propertyName = sliderName.text.ToString().Replace(" ", "");
        PlayerPrefs.SetFloat(propertyName, slider.value);
    }
}
