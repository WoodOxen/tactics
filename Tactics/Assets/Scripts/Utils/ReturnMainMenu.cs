/**
  * @file ReturnMainMenu.cs
  * @brief Return to the main menu by pressing the Esc button
  * @details 
  * Hanging to: Branch panels in the menu scene
  * @author WoodOxen
  * @date 2023-01-16
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
