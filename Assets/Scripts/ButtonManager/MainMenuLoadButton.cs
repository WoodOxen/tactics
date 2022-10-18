using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoadButton : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject mainMenu;

    public void MainloadGame()
    {
        loadPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        loadPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
