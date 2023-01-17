using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueChange : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI currentValue;

    // Update is called once per frame
    void Update()
    {
        currentValue.text = slider.value.ToString();
    }
}
