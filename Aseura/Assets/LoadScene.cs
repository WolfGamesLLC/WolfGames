using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

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
		StartCoroutine(ChangeLevel());
	}
	
	/// <summary>
	/// Changes the level.
	/// </summary>
	/// <returns>The level.</returns>
	IEnumerator ChangeLevel()
	{
		float fadeTime = fadingObject.BeginFade(Fading.FadeDirection.IN);
		yield return new WaitForSeconds(3);
	}

	#endregion
}
