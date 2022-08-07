using UnityEngine;
using System.Collections;

public class RedScore : MonoBehaviour {

	void Update()
	{
		this.transform.Rotate(0, 1, 0, Space.Self);
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameModeManager.CurrentScore1 += 100;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player2")
        {
            GameModeManager.CurrentScore2 += 100;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player3")
        {
            GameModeManager.CurrentScore3 += 100;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player4")
        {
            GameModeManager.CurrentScore4 += 100;
            gameObject.SetActive(false);
        }
    }
}
