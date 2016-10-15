using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour, IMovementController
{
    public BallController ballController;
    public GameObject mainMenu;

    private Rigidbody rB;

    // Run when the enable event is fired
    public void OnEnable()
    {
        ballController = new BallController();
        ballController.SetMovementController(this);
    }

    // Initialize the object
    public void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        ballController.SetSpeed(hMove, vMove);
        ballController.Move(hMove, vMove);
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
}
