using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rB;

    // Initialize the object
    public void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rB.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
    }
}
