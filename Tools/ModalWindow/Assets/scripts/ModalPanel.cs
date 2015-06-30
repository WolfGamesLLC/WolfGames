using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Event button data object for accessing event button properties
/// </summary>
public class EventButtonData
{
    #region Members

    private string title;
    private Sprite background;
    private UnityAction action;

    #endregion

    #region Properties

    /// <summary>
    /// Text displayed on the button
    /// </summary>
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    /// <summary>
    /// Background sprite used for the button
    /// </summary>
    public Sprite Background
    {
        get { return background; }
        set { background = value; }
    }

    /// <summary>
    /// A function reference to the action the button performs
    /// </summary>
    public UnityAction Action
    {
        get { return action; }
        set { action = value; }
    }

    #endregion

    #region Initialization

    /// <summary>
    /// Standard constructor for an EventButtonData object
    /// </summary>
    /// <param name="title">The text displayed on the button</param>
    /// <param name="action">A reference to a function that will be performed when the button is pressed</param>
    /// <param name="background">An optional sprite containing the background image used for the button</param>
    public EventButtonData(string title, UnityAction action, Sprite background = null)
    {
        Title = title;
        Action = action;
        Background = background;
    }

    #endregion
}

/// <summary>
/// Modal Panel data object for accessing modal panel data
/// </summary>
public class ModalPanelData
{
    #region Members

    private Transform position;
    private string title;
    private string text;
    private Sprite icon;
    private Sprite background;
    private List<EventButtonData> buttons;

    #endregion
    #region Properties

    /// <summary>
    /// Position of the ModalPanel on the screen - NOT IMPLEMENTED
    /// </summary>
    public Transform Position
    {
        get { return position; }
        set { position = value; }
    }

    /// <summary>
    /// Title of the Modal Panel - NOT IMPLEMENTED
    /// </summary>
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    /// <summary>
    /// Textual content of the modal panel
    /// </summary>
    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    /// <summary>
    /// A sprite containing the icon displayed on the panel
    /// </summary>
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    /// <summary>
    /// A sprite containing the background image to be displayed with the panel
    /// </summary>
    public Sprite Background
    {
        get { return background; }
        set { background = value; }
    }

    /// <summary>
    /// The list of buttons to be displayed on the panel
    /// </summary>
    public List<EventButtonData> Buttons
    {
        get { return buttons; }
        set { buttons = value; }
    }

    #endregion

    #region Initialization

    /// <summary>
    /// The standard constructor for a ModalPanelData object
    /// </summary>
    /// <param name="text">The text to be displayed in the dialog box</param>
    /// <param name="icon">An option sprite that contains an icon to be displayed on the dialog</param>
    public ModalPanelData(string text, Sprite icon = null)
    {
        Text = text;
        Icon = icon;
        buttons = new List<EventButtonData>();
    }

    #endregion
}

public class ModalPanel : MonoBehaviour 
{

    private int ButtonIndex;
    private List<Button> buttons;

    /// <summary>
    /// Unity Text object that display the text of the panel
    /// </summary>
    public Text text;

    /// <summary>
    /// Unity Image object that will display the optional dialog box icon
    /// </summary>
    public Image icon;

    /// <summary>
    /// Unity button to be instantiated for each button requested
    /// </summary>
    public Button buttonTemplate;
 
    /// <summary>
    /// The panel that contains the text, icon and instantiated buttons
    /// </summary>
    public GameObject modalPanelObject;

    /// <summary>
    /// The panel that will become the parent of the buttons
    /// </summary>
    public GameObject buttonPanelObject;

    /// <summary>
    /// Singleton for access to the modal panel object
    /// </summary>
    private static ModalPanel modalPanel;
    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("No active ModalPanel script found: there needs to be at least one active ModelPanel script on a game object in your game");
        }

        return modalPanel;
    }

    public void Awake()
    {
        buttons = new List<Button>();
        ClosePanel();
    }

   public void ShowPanel(ModalPanelData data)
    {
        foreach (EventButtonData button in data.Buttons)
        {
            Button newButton = Instantiate(buttonTemplate) as Button;
            newButton.name = button.Title;
            newButton.onClick.RemoveAllListeners();
            newButton.onClick.AddListener(button.Action);
            newButton.onClick.AddListener(ClosePanel);
            newButton.gameObject.SetActive(true);
            newButton.transform.FindChild("Text").GetComponent<Text>().text = button.Title;
            newButton.transform.SetParent(buttonPanelObject.transform);
            buttons.Add(newButton);
        }

        modalPanelObject.SetActive(true);

        text.gameObject.SetActive(true);
        text.text = data.Text;

        if (data.Icon)
        {
            icon.sprite = data.Icon;
            icon.gameObject.SetActive(true);
        }
    }

    private void ClosePanel()
    {
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }
 
        buttons.Clear();
        
        modalPanelObject.SetActive(false);
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false); 
    }
}
