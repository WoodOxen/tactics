/**
  * @file SkyBoxRot.cs
  * @brief 令MainMenu和TrackSelect场景中背景的天空缓缓旋转
  * @details  
  * 挂载该脚本的对象：MainMenu和TrackSelect场景中的任意一个对象均可
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;

public class SkyBoxRot: MonoBehaviour {

    public float rotateSpeed = 0.5f;

    void Update () {
        RenderSettings.skybox.SetFloat ("_Rotation", rotateSpeed * Time.time);
    }
}
