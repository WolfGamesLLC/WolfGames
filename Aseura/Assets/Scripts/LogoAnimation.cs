using UnityEngine;
using System.Collections;

public class LogoAnimation : MonoBehaviour 
{
	#region Members

	private string url;

	#endregion
	
	#region Properties
	
	#endregion
	
	/// <summary>
	/// The main camera.
	/// </summary>
	private Fading fadingObject; 

	#region Methods

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		fadingObject = GameObject.Find("Main Camera").GetComponent<Fading>();
		url = string.Format("http://www.wolfgamesllc.com/warefeed/services?u={0}&c={1}&v={2}", 
		                    "test", System.Environment.MachineName, "Load%20Aseura");
		StartCoroutine(Log());
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		if(transform.localScale.x > 2)
		{
			transform.localScale += new Vector3(-1,-1,-1);
		}

		if(transform.localScale.x <= 2)
		{
			StartCoroutine(ChangeLevel());
		}
	}

	/// <summary>
	/// Changes the level.
	/// </summary>
	/// <returns>The level.</returns>
	IEnumerator ChangeLevel()
	{
		float fadeTime = fadingObject.BeginFade(Fading.FadeDirection.OUT);
	
		yield return new WaitForSeconds(1);

		Application.LoadLevel(Application.loadedLevel + 1);
	}

	IEnumerator Log () 
	{
//		print (url.ToString());
		WWW log = new WWW(url);
		yield return log;
	}

	#endregion
}
