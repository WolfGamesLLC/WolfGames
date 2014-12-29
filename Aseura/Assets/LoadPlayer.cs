using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadPlayer : MonoBehaviour 
{
	public Text SaveGameText;
	public Text LoadButtonText;
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
		if (sg.Count >= 1) {
			print (sg [0].Caption);
			LoadButtonText.text = sg [0].Caption;
		}
		else
			LoadButtonText.text = "Create New Player";
	}

	public void LoadPlayerData()
	{
		if(sg.Count >= 1)
			LevelSerializer.LoadNow(sg[0].Data);
		else
			SaveGameText.text = "Player_1";

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
		sg[0].Delete();
		SetLoadGameButtonText();
	}
}
