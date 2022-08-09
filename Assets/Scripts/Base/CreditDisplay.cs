using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditDisplay : MonoBehaviour {

	void Start () {
		StartCoroutine (CreditEnd ());
	}
	
	IEnumerator CreditEnd(){
		yield return new WaitForSeconds (10);
		SceneManager.LoadScene (0);
	}
}
