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
    Vector3 Position();
    void MoveObject(Vector3 force);
}

public class Game
{
    MainMenuController mainMenu;
    BallController player;
    long score;
    Vector3 playerPreviousPosition;

    public long Score
    {
        get { return score; }

        set
        {
            score = value;
            mainMenu.SetScoreText(Score);
        }
    }

    public Game(MainMenuController menu, BallController ball)
    {
        mainMenu = menu;
        player = ball;
    }

    public void Start()
    {
        Score = 0;
        playerPreviousPosition = player.Position();
    }

    public void Update()
    {
        Vector3 delta = playerPreviousPosition - player.Position();
        Score += (long)(Math.Abs(delta.x) + Math.Abs(delta.y));
        playerPreviousPosition = player.Position();
    }
}
