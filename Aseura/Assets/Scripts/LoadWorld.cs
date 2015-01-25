using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadWorld : MonoBehaviour 
{
    #region Members

    private List<LevelSerializer.SaveEntry> sg;

    #endregion

    #region Editor Properties

    [SerializeField]
    private Text WorldNameInputFieldText;

    [SerializeField]
    private GameObject WorldSelectionPanel;

    #endregion

    #region Properties
    #endregion

    #region Initialization

    #endregion

    #region Methods

    /// <summary>
    /// Enable the LoadWorld componenet
    /// </summary>
    public void OnEnable()
    {
        SetLoadWorldButtonText();
    }

    void SetLoadWorldButtonText()
    {
        sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName];
        Debug.Log("Saved Games count for " + LevelSerializer.PlayerName + ": " + sg.Count.ToString());
        if (sg.Count >= 1)
        {
            WorldNameInputFieldText.text = sg[0].Caption;
            Debug.Log("WorldNameInputField.text: " + WorldNameInputFieldText);
        }
        else
            WorldNameInputFieldText.text = "Create New World";
    }

    /// <summary>
    /// Load World data and activate the next screen (I should not be doing this here)
    /// </summary>
    public void LoadWorldData()
    {
        WorldSelectionPanel.SetActive(false);

        if (sg.Count >= 1)
        {
            LevelSerializer.LoadNow(sg[0].Data);
        }
        else
        {
            WorldSelectionPanel.SetActive(true);
        }

        Time.timeScale = 1;
    }

    /// <summary>
    /// Save the World's data
    /// </summary>
    public void SaveWorldData()
    {
        if (WorldNameInputFieldText.text != "")
            LevelSerializer.SaveGame(WorldNameInputFieldText.text);
        else
            LevelSerializer.SaveGame("World_1");

        WorldSelectionPanel.SetActive(false);
    }

    /// <summary>
    /// Delete a World's saved data
    /// </summary>
    public void DeleteWorldData()
    {
        if (sg.Count >= 1)
        {
            sg[0].Delete();
            SetLoadWorldButtonText();
        }
    }

    public void CreateWorld()
    {
        Application.LoadLevel(1);

        SaveWorldData();
    }

    #endregion
}
