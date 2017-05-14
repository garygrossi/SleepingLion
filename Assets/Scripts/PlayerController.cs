using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countCreamText;

    private Rigidbody2D rigidBody;
    private int count;

	// Use this for initialization
	void Start () {
        // Get rigidbody
        rigidBody = GetComponent<Rigidbody2D>();

        // Init cream collection count
        count = 0;

        // Set the count text
        SetCountText();
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

    // Called when the player overlaps with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check what game object it is
        if (collision.gameObject.CompareTag("Cream"))
        {
            collision.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        } 
    }

    void SetCountText()
    {
        countCreamText.text = "Cream Collected: " + count.ToString();
    }
}
