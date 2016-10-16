using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IPlayerController
{
    void StartPlayer();
}

public interface IScoreController
{
    void SetScoreText(string score);
}

public interface IMovementController
{
    void MoveObject(Vector3 force);
}

public class Game
{
    MainMenuController mainMenu;
    BallController player;
    int score;
    Vector3 playerPreviousPosition;

    public Game(MainMenuController menu, BallController ball)
    {
        mainMenu = menu;
        player = ball;
    }

    public void StartGame()
    {
        score = 0;
        mainMenu.SetScoreText(score);
    }

    public void Update()
    {

    }
}
