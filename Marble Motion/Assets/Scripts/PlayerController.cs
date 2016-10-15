using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public interface IMovementController
{
    void MoveObject(Vector3 force);
}

public interface IScoreController
{
    void SetObjectScore(float score);
}

public class PlayerController : MonoBehaviour, IMovementController, IScoreController
{
    public BallController ballController;
    public Text scoreText;
    public GameObject mainMenu;

    private Rigidbody rB;
    private float score;

    // Run when the enable event is fired
    public void OnEnable()
    {
        ballController = new BallController();
        ballController.SetMovementController(this);
        ballController.SetScoreController(this);
    }

    // Initialize the object
    public void Start()
    {
        rB = GetComponent<Rigidbody>();
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        ballController.SetSpeed(hMove, vMove);
        ballController.Move(hMove, vMove);
        ballController.SetScore(rB.velocity.x + rB.velocity.z);
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        if (Input.GetButtonUp("Cancel")) mainMenu.SetActive(true);
    }


    // OnTriggerEnter is called when the Collider other enters the trigger
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
            other.gameObject.SetActive(false);
    }

    #region IMovementController implementation

    public void MoveObject(Vector3 force)
    {
        rB.AddForce(force);
    }

    #endregion

    #region IScoreController implementation

    public void SetObjectScore(float score)
    {
        this.score += score;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = score.ToString();
    }

    #endregion
}
