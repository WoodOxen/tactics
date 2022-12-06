using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages scene switch in TACTICS
/// </summary>
public class SceneSwitcher : MonoBehaviour
{

    public void ToMenu() {
        SceneManager.LoadScene(0);
    }

    public void ToModeSelection() {
        SceneManager.LoadScene(1);
    }

    public void ToSettings() {
        SceneManager.LoadScene(2);
    }

}
