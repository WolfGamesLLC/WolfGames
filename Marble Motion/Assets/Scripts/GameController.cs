using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public MenuController menu;
    public PlayerController player;
    public GameObject mainMenu;

    Game game;

	// Use this for initialization
	void Start ()
    {
        MainMenuController mainMenu = new MainMenuController();
        mainMenu.SetScoreController(this.menu);

        BallController ball = new BallController();
        ball.SetMovementController(player);

        game = new Game(mainMenu, ball);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonUp("Cancel")) mainMenu.SetActive(true);
        game.Update();
    }
}
