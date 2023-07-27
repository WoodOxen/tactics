/**
 * @file ReturnMainMenu.cs
 * @brief This script is used to return to the main menu when the player presses the escape key.
 * @author Yueyuan Li
 * @date 2023-01-16
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMainMenu : MonoBehaviour
{
    public GameObject currentObject;
    public GameObject mainMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentObject.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
