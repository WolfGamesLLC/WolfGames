using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadWorld : MonoBehaviour 
{
    #region Members

    private List<LevelSerializer.SaveEntry> sg;

    private int localWorldButtonIndex;

    private const int MaxSaves = 3;

    #endregion

    #region Editor Properties

    [SerializeField]
    private Text WorldNameInputFieldText;

    [SerializeField]
    private GameObject WorldSelectionPanel;

    [SerializeField]
    private WorldSaveManager WorldSaveManagerPrefab;

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

    public void SetLoadWorldButtonText()
    {
        sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName];
        Debug.Log("Saved Games count for " + LevelSerializer.PlayerName + ": " + sg.Count.ToString());

        for (int i = 0; i < sg.Count; i++)
            CreateButton(sg[sg.Count - i - 1].Caption, i);

        WorldNameInputFieldText.text = "world_1";
    }

    private void CreateButton(string buttonText, int instance)
    {
        WorldSaveManager newButton = (WorldSaveManager)Instantiate(WorldSaveManagerPrefab);
        newButton.name = "localWorldButton_" + localWorldButtonIndex++;
        newButton.transform.SetParent(WorldSelectionPanel.transform, false);
        newButton.Setup(buttonText, instance);
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
        if (sg.Count > MaxSaves)
        {
            // popup info message here
            return;
        }

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
