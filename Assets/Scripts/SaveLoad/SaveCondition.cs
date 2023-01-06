/**
  * @file SaveCondition.cs
  * @brief 定义SaveCondition类，记录各个存档位的使用情况
  * @details  
  * 挂载该脚本的对象：无 \n
  * @author 李雨航
  * @date 2022-01-06
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveCondition
{
    /// 存档位1的使用情况 
    public int Save1Track = 0;
    /// 存档位2的使用情况 
    public int Save2Track = 0;
    /// 存档位3的使用情况 
    public int Save3Track = 0;
    /// 存档位4的使用情况 
    public int Save4Track = 0;
}
