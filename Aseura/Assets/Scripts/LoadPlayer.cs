using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadPlayer : MonoBehaviour
{
    #region Members
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
        SetLoadPlayerButtonText();
    }
    
    #endregion

    #region Methods

    void SetLoadPlayerButtonText()
    {
        if (PlayerPrefs.HasKey("CharacterName"))
        {
            LoadButtonText.text = PlayerPrefs.GetString("CharacterName");
        }
        else
        {
            LoadButtonText.text = "Create New Player";
        }
    }

    /// <summary>
    /// Load player data and activate the next screen (I should not be doing this here)
    /// </summary>
    public void LoadPlayerData()
    {
        LaunchScreenPanel.SetActive(false);

        if(PlayerPrefs.HasKey("CharacterName"))
        {
            PlayerNameInputField.text = PlayerPrefs.GetString("CharacterName");
            LevelSerializer.PlayerName = PlayerNameInputField.text;
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
        PlayerPrefs.SetString("CharacterName", PlayerNameInputField.text);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Delete a player's saved data
    /// </summary>
    public void DeletePlayerData()
    {
        if (PlayerPrefs.HasKey("CharacterName"))
        {
            PlayerPrefs.DeleteKey("CharacterName");
            SetLoadPlayerButtonText();
        }
    }
    
    #endregion
}
