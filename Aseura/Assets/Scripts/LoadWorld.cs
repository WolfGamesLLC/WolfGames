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
    private InputField WorldNameInputField;

    [SerializeField]
    private Text LoadButtonText;

    [SerializeField]
    private GameObject WorldSelectionPanel;

    #endregion

    #region Properties
    #endregion

    #region Initialization

    /// <summary>
    /// Initialize the LoadWorld componenet
    /// </summary>
    public void Start()
    {
        SetLoadWorldButtonText();
    }

    #endregion

    #region Methods

    void SetLoadWorldButtonText()
    {
        sg = LevelSerializer.SavedGames["World_"];
        if (sg.Count >= 1)
        {
            LoadButtonText.text = sg[0].Caption;
        }
        else
            LoadButtonText.text = "Create New World";
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
        if (WorldNameInputField.text != "")
            LevelSerializer.SaveGame("World_" + WorldNameInputField.text);
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
