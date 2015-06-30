using UnityEngine;
using System.Collections;

public class PlayerNetworkMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Loading player");
        foreach (Camera cam in GetComponentsInChildren<Camera>())
        {
            Debug.Log("Player camera enabled");
            cam.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
