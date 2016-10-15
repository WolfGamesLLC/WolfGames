using UnityEngine;
using System.Collections;

public interface IGameController
{
    void StartPlayer();
    void SetScoreText();
}

public class MenuController : MonoBehaviour, IGameController
{
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
