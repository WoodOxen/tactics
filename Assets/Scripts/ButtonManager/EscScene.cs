/**
  * @file EscScene.cs
  * @brief 在TrackSelect场景和Credit场景通过Esc键快速回到主菜单
  * @details 
  * 挂载该脚本的对象：TrackSelect → Esc， Credit → Esc \n
  * @author 李雨航
  * @date 2023-12-31
  */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
