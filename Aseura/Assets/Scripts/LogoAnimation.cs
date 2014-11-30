using UnityEngine;
using System.Collections;

public class LogoAnimation : MonoBehaviour 
{
	#region Members

	#endregion
	
	#region Properties
	
	#endregion
	
	/// <summary>
	/// The main camera.
	/// </summary>
	public Fading fadingObject; 
	
	#region Methods

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		fadingObject = GameObject.Find("Main Camera").GetComponent<Fading>();
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
		yield return new WaitForSeconds(3);

		Application.LoadLevel(Application.loadedLevel + 1);
	}

	#endregion
}
