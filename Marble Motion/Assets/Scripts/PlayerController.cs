using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float scoreModifier;
    public Text scoreText;

    private Rigidbody rB;
    private float score;

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
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        SetScore();
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        rB.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
    }

    private void SetScore()
    {
        if (rB.IsSleeping() == false)
        {
            score += scoreModifier * speed;
            scoreText.text = score.ToString();
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
            other.gameObject.SetActive(false);
    }
}
