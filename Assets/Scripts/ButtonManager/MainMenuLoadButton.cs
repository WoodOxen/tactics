/**
  * @file MainMenuLoadButton.cs
  * @brief 主菜单场景中存档窗口的打开和关闭
  * @details 
  * 挂载该脚本的对象：MainMenu → Canvas → ButtonManager \n 
  * 主菜单场景中按下Load Game按钮后，呼出存档窗口；在存档窗口按下Back按钮后，关闭存档窗口。
  * @author 李雨航
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoadButton : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject mainMenu;
    /**
     * @fn MainloadGame
     * @brief 打开存档窗口，关闭主菜单选项
     */
    public void MainloadGame()
    {
        loadPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    /**
     * @fn Back
     * @brief 关闭存档窗口，打开主菜单选项
     */
    public void Back()
    {
        loadPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
