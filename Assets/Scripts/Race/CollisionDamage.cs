/**
  * @file CollisionDamage.cs
  * @brief 检测小车的碰撞和损伤
  * @details
  * 挂载该脚本的对象：RaceArea → Car\n
  * 当小车收到碰撞时，获取小车抵消该碰撞所需的冲力，并记录小车碰撞次数和碰撞损伤程度。
  * @author 李雨航
  * @date 2022-01-06
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    /// 该脚本获取的是几号车的碰撞损伤
    [SerializeField] public int CarNum;
    private Vector3 impulse;
    private float Impulse;
    //private float Force;

    void OnCollisionEnter(Collision collisionInfo)
    {
        impulse = collisionInfo.impulse;
        DamageDisplay.CollisionNum[CarNum] += 1;
        Impulse = (Mathf.Sqrt(Mathf.Pow(impulse.x,2f)+ Mathf.Pow(impulse.y, 2f)+ Mathf.Pow(impulse.z, 2f)))/1000;
        //Force = Impulse / Time.fixedDeltaTime;
        DamageDisplay.ExtentOfDamage[CarNum] += Impulse;
    }
}
