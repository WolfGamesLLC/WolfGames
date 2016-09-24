using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public interface IMovementController
{
    void Move(Vector3 force);
}

public interface IScoreController
{
    void Set(float score);
}

public class PlayerController : MonoBehaviour, IMovementController, IScoreController
{
    public BallController ballController;
    public Text scoreText;

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
        ballController.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ballController.SetScore();
    }


    // OnTriggerEnter is called when the Collider other enters the trigger
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
            other.gameObject.SetActive(false);
    }

    #region IMovementController implementation

    public void Move(Vector3 force)
    {
        rB.AddForce(force);
    }

    #endregion

    #region IScoreController implementation
    public void Set(float score)
    {
        if (rB.IsSleeping() == false)
        {
            score += score;
            scoreText.text = score.ToString();
        }
    }
    #endregion
}
