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
            CurrentScore.Score[0] += 25;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player2")
        {
            CurrentScore.Score[1] += 25;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player3")
        {
            CurrentScore.Score[2] += 25;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player4")
        {
            CurrentScore.Score[3] += 25;
            gameObject.SetActive(false);
        }
    }
}
