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
    public const float SCORE_MULTIPLIER = 0.75f;

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

    public void Update(float elapsedTime)
    {
        Vector3 delta = (playerPreviousPosition - player.Position()) / elapsedTime;
        Score += (long)(Math.Abs(delta.x * SCORE_MULTIPLIER) + Math.Abs(delta.z * SCORE_MULTIPLIER));
        playerPreviousPosition = player.Position();
    }
}
