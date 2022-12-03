using UnityEngine;
using System.Collections;

public class RedScore : MonoBehaviour {

	void Update()
	{
		this.transform.Rotate(0, 1, 0, Space.Self);
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")//触碰该宝石的是否是1号车辆（tag为“Player”,这个是Unity自带的不能改）
        {
            ScoreDisplay.Score[0] += 100;
            gameObject.SetActive(false);
        }
        for (int i = 2; i <= GameSetting.NumofPlayer; i++)//触碰该宝石的是否是2~8号车辆
        {
            if (collision.gameObject.tag == "Player" + i.ToString())
            {
                ScoreDisplay.Score[i - 1] += 100;
                gameObject.SetActive(false);
            }
        }
    }
}
