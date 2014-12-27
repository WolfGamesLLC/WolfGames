using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadPlayer : MonoBehaviour 
{
	public Text SaveGameText;
	public Text LoadButtonText;

	public void Start()
	{
		List<LevelSerializer.SaveEntry> sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName];

		if(sg.Count >= 1)
			LoadButtonText.text = sg[0].Caption;
		else
			LoadButtonText.text = "Create New Player";
//		foreach(var sg in LevelSerializer.SavedGames[LevelSerializer.PlayerName]) 
//		{ 
//			if(GUILayout.Button(sg.Caption)) 
//			{ 
//				LevelSerializer.LoadNow(sg.Data);
//				Time.timeScale = 1;
//			}
//		}
	}

	public void LoadPlayerData()
	{
		List<LevelSerializer.SaveEntry> sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName];		
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
}
