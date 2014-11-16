using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchCameraType : MonoBehaviour {

	public Camera camera;
	public Text text;

	public void SetCameraState()
	{
		camera.orthographic = !camera.orthographic;
		text.text = camera.orthographic.ToString();
	}
}
