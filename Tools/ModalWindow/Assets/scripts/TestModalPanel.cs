using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class TestModalPanel : MonoBehaviour {

    public Sprite icon;
    public Transform spawnPoint;
    public GameObject thingToSpawn;

    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();
    }

    private void ButtonOneFunction()
    {
        displayManager.DisplayMessage("Button One Pressed");
    }

    private void ButtonTwoFunction()
    {
        displayManager.DisplayMessage("Button Two Pressed");
    }

    private void ButtonThreeFunction()
    {
        displayManager.DisplayMessage("Button Three Pressed");
    }

    public void TestYNCWindow()
    {
        ModalPanelData data = new ModalPanelData("Test the YNC dialog box");
        data.Buttons.Add(new EventButtonData("YES", ButtonOneFunction));
        data.Buttons.Add(new EventButtonData("NO", ButtonTwoFunction));
        data.Buttons.Add(new EventButtonData("CANCEL", ButtonThreeFunction));

        modalPanel.ShowPanel(data);
    }

    public void TestErrorWindow()
    {
        ModalPanelData data = new ModalPanelData("You have encountered an error", icon);
        data.Buttons.Add(new EventButtonData("OK", ButtonOneFunction));
        modalPanel.ShowPanel(data);
    }

    public void TestLambda()
    {
        ModalPanelData data = new ModalPanelData("Do you wish to instantiate a cube with a Lambda function?");
        data.Buttons.Add(new EventButtonData("YES", () => { InstantiateObject(thingToSpawn); }));
        data.Buttons.Add(new EventButtonData("NO", () => { }));

        modalPanel.ShowPanel(data);
    }

    private void InstantiateObject(GameObject thingToInstantiate)
    {
        displayManager.DisplayMessage("Display Text");
        Instantiate(thingToInstantiate, spawnPoint.position, spawnPoint.rotation);
    }
}
