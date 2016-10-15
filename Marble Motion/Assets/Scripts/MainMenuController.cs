using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MainMenuController
{
    private IGameController gameController;

    public void SetGameController(IGameController gameController)
    {
        this.gameController = gameController;
    }
}
