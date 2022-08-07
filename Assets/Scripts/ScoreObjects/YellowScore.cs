using UnityEngine;
using System.Collections;

public class YellowScore : MonoBehaviour {


	void Update()
    {
		this.transform.Rotate(0,1,0,Space.Self);
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameModeManager.CurrentScore1 += 25;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player2")
        {
            GameModeManager.CurrentScore2 += 25;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player3")
        {
            GameModeManager.CurrentScore3 += 25;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player4")
        {
            GameModeManager.CurrentScore4 += 25;
            gameObject.SetActive(false);
        }
    }
}
