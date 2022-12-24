using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages scene switch in TACTICS
/// </summary>
public class SceneSelector : MonoBehaviour
{
    public void ChangeScene(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }
}
