using UnityEngine;
using System.Collections;

public class SkyBoxRot: MonoBehaviour {

	public float rotateSpeed = 0.5f;

	void Update () {
		RenderSettings.skybox.SetFloat ("_Rotation", rotateSpeed * Time.time);
	}
}
