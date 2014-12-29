using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadPlayer : MonoBehaviour 
{
	public Text SaveGameText;
	public Text LoadButtonText;
	public Canvas CreatePlayerCanvas;
	private List<LevelSerializer.SaveEntry> sg;

	public void Start()
	{
		SetLoadGameButtonText ();

//		foreach(var sg in LevelSerializer.SavedGames[LevelSerializer.PlayerName]) 
//		{ 
//			if(GUILayout.Button(sg.Caption)) 
//			{ 
//				LevelSerializer.LoadNow(sg.Data);
//				Time.timeScale = 1;
//			}
//		}
	}

	void SetLoadGameButtonText ()
	{
		sg = LevelSerializer.SavedGames [LevelSerializer.PlayerName];
		if (sg.Count >= 1) 
		{
			LoadButtonText.text = sg [0].Caption;
		}
		else
			LoadButtonText.text = "Create New Player";
	}

	public void LoadPlayerData()
	{
		if(sg.Count >= 1)
		{
			LevelSerializer.LoadNow(sg[0].Data);
			CreatePlayerCanvas.enabled = false;
		}
		else
		{
			CreatePlayerCanvas.enabled = true;
		}

		Time.timeScale = 1;
	}

	public void SavePlayerData()
	{
		if(SaveGameText.text != "")
			LevelSerializer.SaveGame(SaveGameText.text);
		else
			LevelSerializer.SaveGame("Player_1");
	}

	public void DeletePlayerData()
	{
		if(sg.Count >= 1)
		{
			sg[0].Delete();
			SetLoadGameButtonText();
		}
	}
}
