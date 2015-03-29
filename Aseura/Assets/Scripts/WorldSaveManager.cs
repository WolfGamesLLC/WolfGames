using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldSaveManager : MonoBehaviour 
{
    /// <summary>
    /// Setup a new instance of a WorldSaveManager object
    /// </summary>
    /// <param name="text">The main button text</param>
    /// <param name="yPosition">The instance of the button</param>
	public void Setup (string text, int instance) 
    {
        enabled = true;

        Debug.Log("Vector3.down (" + Vector3.down + ")* (instance (" + instance + ") = " + (Vector3.down * (instance * 40)));
        transform.Translate(Vector3.down * (instance * 40));
        Debug.Log("LocalPosition = " + transform.localPosition);

        Transform t = transform.FindChild("CreateOrLoadButton/CreateOrLoadCharacterButtonText");
        if (t == null)
            Debug.Log("CreateOrLoadCharacterButtonText child not found in " + name);

        Text bText = (Text)t.GetComponent("Text");
        bText.text = text;

        Debug.Log("Created button: name: " + name + " text: " + bText.text);
    }
}
