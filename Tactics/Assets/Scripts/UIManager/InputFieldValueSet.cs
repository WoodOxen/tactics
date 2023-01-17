using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldValueSet : MonoBehaviour
{
    public InputField field;
    public TextMeshProUGUI fieldName;
    // Update is called once per frame
    void Update()
    {
        string propertyName = fieldName.text.ToString().Replace(" ", "");
        PlayerPrefs.SetString(propertyName, field.text);
    }
}
