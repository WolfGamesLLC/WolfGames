using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BallController
{
    public const float MAX_SPEED = 10.0f;
    public const float MIN_SPEED = 1.0f;

    public float speed = 10;
    public float scoreModifier = 100;

    private IMovementController movementController;
    private IScoreController scoreController;

    public void Move(float moveHorizontal, float moveVertical)
    {
        SetSpeed(moveHorizontal, moveVertical);
        movementController.MoveObject(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
    }

    public void SetScore()
    {
        scoreController.SetObjectScore(scoreModifier * speed);
    }

    public void SetSpeed(float moveHorizontal, float moveVertical)
    {
        if (moveHorizontal > 0 || moveVertical > 0)
            speed++;
        else speed--;

        if (speed < MIN_SPEED) speed = MIN_SPEED;
        if (speed > MAX_SPEED) speed = MAX_SPEED;
    }

    public void SetMovementController(IMovementController movementController)
    {
        this.movementController = movementController;
    }

    public void SetScoreController(IScoreController scoreController)
    {
        this.scoreController = scoreController;
    }
}
