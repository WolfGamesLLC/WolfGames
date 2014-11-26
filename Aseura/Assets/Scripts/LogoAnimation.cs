using UnityEngine;
using System.Collections;

public class LogoAnimation : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if(transform.localScale.x > 1)
		{
			transform.localScale += new Vector3(-1,-1,-1);
		}
	}
}
