﻿using System;
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
    }

    public void Update()
    {
        Score = 1;
    }
}
