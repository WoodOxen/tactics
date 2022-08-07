using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscGameSetting : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
