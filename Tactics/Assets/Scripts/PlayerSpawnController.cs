/// <summary>
/// This class generates a player at the given spawn point.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    public GameObject[] playerSpawnArray;
    private int randNumber;

    void Awake()
    {
        playerSpawnArray = GameObject.FindGameObjectsWithTag("PlayerSpawn");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetRandomPlayerSpawn()
    {
        randNumber = Random.Range(0, playerSpawnArray.Length);

        if (playerSpawnArray.Length > 0)
        {
            return playerSpawnArray[randNumber];
        }
        else
        {
            return null;
        }
    }
}
