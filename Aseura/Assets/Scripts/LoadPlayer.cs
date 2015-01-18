using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadPlayer : MonoBehaviour
{
    #region Members
    
    private List<LevelSerializer.SaveEntry> sg;
    
    #endregion

    #region Editor Properties

    [SerializeField] 
    private InputField PlayerNameInputField;

    [SerializeField] 
    private Text LoadButtonText;

    [SerializeField] 
    private GameObject PlayerViewPanel;

    [SerializeField] 
    private GameObject LaunchScreenPanel;

    [SerializeField]
    private GameObject WorldSelectionPanel;
    
    #endregion

    #region Properties
    #endregion

    #region Initialization

    /// <summary>
    /// Initialize the LoadPlayer componenet
    /// </summary>
    public void Start()
    {
        SetLoadGameButtonText();
    }
    
    #endregion

    #region Methods

    void SetLoadGameButtonText()
    {
        sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName];
        if (sg.Count >= 1)
        {
            LoadButtonText.text = sg[0].Caption;
        }
        else
            LoadButtonText.text = "Create New Player";
    }

    /// <summary>
    /// Load player data and activate the next screen (I should not be doing this here)
    /// </summary>
    public void LoadPlayerData()
    {
        LaunchScreenPanel.SetActive(false);

        if (sg.Count >= 1)
        {
            LevelSerializer.LoadNow(sg[0].Data);
            PlayerViewPanel.SetActive(false);
            WorldSelectionPanel.SetActive(true);
        }
        else
        {
            PlayerViewPanel.SetActive(true);
        }

        Time.timeScale = 1;
    }

    /// <summary>
    /// Save the player's data
    /// </summary>
    public void SavePlayerData()
    {
        if (PlayerNameInputField.text != "")
            LevelSerializer.SaveGame(PlayerNameInputField.text);
        else
            LevelSerializer.SaveGame("Player_1");
    }

    /// <summary>
    /// Delete a player's saved data
    /// </summary>
    public void DeletePlayerData()
    {
        if (sg.Count >= 1)
        {
            sg[0].Delete();
            SetLoadGameButtonText();
        }
    }
    
    #endregion
}
