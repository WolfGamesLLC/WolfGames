using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadPlayer : MonoBehaviour 
{
    
	public InputField PlayerNameInputField;
	public Text LoadButtonText;
	public GameObject PlayerViewPanel;
    public GameObject LaunchScreenPanel;
    private List<LevelSerializer.SaveEntry> sg;

	public void Start()
	{
		SetLoadGameButtonText ();
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
        LaunchScreenPanel.SetActive(false);

        if (sg.Count >= 1)
		{
			LevelSerializer.LoadNow(sg[0].Data);
            PlayerViewPanel.SetActive(false);
		}
		else
		{
            PlayerViewPanel.SetActive(true);
		}

		Time.timeScale = 1;
	}

	public void SavePlayerData()
	{
		if(PlayerNameInputField.text != "")
			LevelSerializer.SaveGame(PlayerNameInputField.text);
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
