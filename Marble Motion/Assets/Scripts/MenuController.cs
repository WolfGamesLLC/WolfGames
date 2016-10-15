using UnityEngine;
using System.Collections;

public interface IGameController
{
    void StartPlayer();
    void SetScoreText();
}

public class MenuController : MonoBehaviour, IGameController
{
    MainMenuController mainMenuController;

    // Run when the enable event is fired
    public void OnEnable()
    {
        mainMenuController = new MainMenuController();
        mainMenuController.SetGameController(this);
    }

    public void Update()
    {
        mainMenuController.StartGame();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #region IGameController implementation

    public void StartPlayer()
    {
    }

    public void SetScoreText()
    {
    }

    #endregion
}
