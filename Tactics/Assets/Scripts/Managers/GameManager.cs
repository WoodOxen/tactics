/**
 * @file GameManager.cs
 * @brief
 * @details
 * @author Yueyuan Li
 * @author Yuhang Li
 * @date 2023-04-28
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OpenVehicleEditor()
    {
        SceneManager.LoadScene(1);
    }
    public void PauseGame ()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
