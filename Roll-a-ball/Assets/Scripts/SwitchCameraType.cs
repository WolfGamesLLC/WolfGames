using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchCameraType : MonoBehaviour {

	public Camera myCamera;
	public Text text;

	public void SetCameraState()
	{
		myCamera.orthographic = !myCamera.orthographic;
		text.text = myCamera.orthographic.ToString();
	}
}
