using UnityEngine;
using System.Collections;

public interface IMovementController
{
	void movePlayer(float moveHorizontal, float moveVertical);
}

public class PlayerController : MonoBehaviour, IMovementController 
{
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	public Controller controller;

	private void OnEnable()
	{
		controller.SetMovementController(this);
	}

	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		controller.movePlayer (moveHorizontal, moveVertical);
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
			if(count >= 12) 
				winText.text = "YOU WIN!";
		}
	}

	public void movePlayer (float moveHorizontal, float moveVertical)
	{
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}

public class Controller
{
	private IMovementController movementController;

	public void movePlayer(float moveHorizontal, float moveVertical)
	{
		movementController.movePlayer(moveHorizontal, moveVertical);
	}

	public void SetMovementController(IMovementController controller)
	{
		this.movementController = controller;
	}
}