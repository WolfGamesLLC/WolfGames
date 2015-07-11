using UnityEngine;
using System.Collections;

public class BuildableObject : MonoBehaviour {

	// Use this for initialization
    public void Setup()
    {
        transform.LookAt(Camera.main.transform);
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }
	
	// Update is called once per frame
	void Update () 
    {
	}
}
