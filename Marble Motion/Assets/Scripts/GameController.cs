using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public MenuController menu;
    public PlayerController player;
    public GameObject mainMenu;

    Game game;

    // Use this for initialization
    void Start()
    {
        MainMenuController mainMenu = new MainMenuController();
        mainMenu.SetScoreController(this.menu);

        BallController ball = new BallController();
        ball.SetMovementController(player);

        game = new Game(mainMenu, ball);

        SaveLoad.Load();
        game.Score = SaveLoad.data.score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel")) mainMenu.SetActive(true);
        game.Update(Time.deltaTime);
    }

    public void OnDestroy()
    {
        //  Use this call for wherever a player triggers a custom event
        Analytics.CustomEvent("gameOver", new Dictionary< string, object >
        {
            { "score", game.Score }
        });
        SaveLoad.data.score = game.Score;
        SaveLoad.Save();

        // Use this call for each and every place that a player triggers a monetization event
//        Analytics.Transaction("MarbleMotion", 0.99m, "USD", null, null);

//        Analytics.SetUserGender(Gender.Male);
//        Analytics.SetUserBirthYear(2014);
    }
}

