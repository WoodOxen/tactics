using UnityEngine;
using System.Collections;

public class finishRotate : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 1, 0, Space.World);
	}
}
