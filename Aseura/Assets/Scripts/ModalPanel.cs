using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EventButtonDetails
{
    public string Title;
    public Sprite Background;
    public UnityAction Action;
}

public class ModalPanelDetails
{
    public string Title;
    public string ContentText;
    public Sprite IconImage;
    public Sprite Background;
    public EventButtonDetails[] ButtonDetails;
}

public class ModalPanel : MonoBehaviour 
{

    private const int MAX_BUTTONS = 10;
    private int ButtonIndex;
    public Text contentText;
    public Image iconImage;
    public Button[] buttons;
    public GameObject modalPanelObject;

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
        ClosePanel();
    }

    public void Start()
    {
        ClosePanel();
    }

    public void SetSelection(string buttonText, UnityAction buttonEvent)
    {
        if (ButtonIndex >= MAX_BUTTONS)
        {
            Debug.LogError("You asked to create button #" + ButtonIndex.ToString() + " only " + MAX_BUTTONS.ToString() + " are allowed");
        }
        
        buttons[ButtonIndex].name = buttonText;
        buttons[ButtonIndex].onClick.RemoveAllListeners();
        buttons[ButtonIndex].onClick.AddListener(buttonEvent);
        buttons[ButtonIndex].onClick.AddListener(ClosePanel);
        buttons[ButtonIndex].gameObject.SetActive(true);

        ButtonIndex++;
    }

    public void ShowPanel(string text, Sprite imageIcon = null)
    {
        modalPanelObject.SetActive(true);

        contentText.gameObject.SetActive(true);
        contentText.text = text;

        if (imageIcon)
        {
            iconImage.sprite = imageIcon;
            iconImage.gameObject.SetActive(true);
        }
    }

    public void ShowPanel(ModalPanelDetails details)
    {
        foreach (EventButtonDetails buttonDetails in details.ButtonDetails)
        {
            SetSelection(buttonDetails.Title, buttonDetails.Action);
        }

        ShowPanel(details.ContentText, details.IconImage);
    }

    private void ClosePanel()
    {
        modalPanelObject.SetActive(false);
        iconImage.gameObject.SetActive(false);
        contentText.gameObject.SetActive(false);

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        ButtonIndex = 0;
    }
}
