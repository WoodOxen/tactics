using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages scene switch in TACTICS
/// 
/// Scene IDs:
/// - 0: Main menu (Scene/Menu/MainMenu)
/// - 1: New Game (Scene/Menu/NewGame)
/// - 2: Load Game (Scene/Menu/LoadGame)
/// - 3: Editors (Scene/Menu/Editors)
/// - 4: Settings (Scene/Menu/Settings)
/// - 5: Credits (Scene/Credits)
/// </summary>
public class SceneSelector : MonoBehaviour
{
    public void ChangeScene(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }
}
