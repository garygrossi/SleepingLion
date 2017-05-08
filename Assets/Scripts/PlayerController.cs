using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        // Get rigidbody
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    // Pre physics
    private void FixedUpdate()
    {
        // Get horizontal and vertical input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector2 for movement based on inputs
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Apply the movement to the character
        rigidBody.AddForce(movement * speed);
    }
}
