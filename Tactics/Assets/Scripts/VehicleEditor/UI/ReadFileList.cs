using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadFileList : MonoBehaviour
{
    private TMPro.TMP_Dropdown _dropdown;
    public void ReadDir(string dir)
    {
        string[] files = Directory.GetFiles(dir);
        _dropdown.ClearOptions();
        foreach (string file in files)
        {
            _dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(Path.GetFileName(file)));
        }
        _dropdown.RefreshShownValue();
    }
    void Start()
    {
        _dropdown = GetComponent<TMPro.TMP_Dropdown>();

        ReadDir(Application.streamingAssetsPath + "/Saves/");

    }

}
