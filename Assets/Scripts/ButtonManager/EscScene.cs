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
