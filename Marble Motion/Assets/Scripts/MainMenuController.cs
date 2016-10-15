using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MainMenuController
{
    private IGameController gameController;

    // Start the game
    public void StartGame()
    {
        gameController.SetScoreText
    }

    // Set the Menu's game controller
    public void SetGameController(IGameController gameController)
    {
        this.gameController = gameController;
    }
}
