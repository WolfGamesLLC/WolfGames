using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour 
{
	/// <summary>
	/// Enum containing possible fade directions
	/// </summary>
	public enum FadeDirection {
		IN = -1,
		OUT = 1,
	};

	#region Members

	/// <summary>
	/// The draw depth.
	/// </summary>
	private int drawDepth = -1000;
	
	/// <summary>
	/// The alpha channel for the texture.
	/// </summary>
	private float alpha = 1.0f;
	
	/// <summary>
	/// The fade dir.
	/// </summary>
	private FadeDirection fadeDir = FadeDirection.IN;

	#endregion

	#region Properties

	/// <summary>
	/// The fade out texture.
	/// </summary>
	public Texture2D FadeOutTexture;

	/// <summary>
	/// The fade speed.
	/// </summary>
	public float FadeSpeed = 0.8f;

	#endregion

	#region Methods

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI(){
		alpha += (int)fadeDir * FadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture);
	}

	/// <summary>
	/// Begins the fade.
	/// </summary>
	/// <returns>The fade speed.</returns>
	/// <param name="direction">The direction to fade.</param>
	public float BeginFade(FadeDirection direction){
		fadeDir = direction;
		return(FadeSpeed);
	}
	
	#endregion
}
