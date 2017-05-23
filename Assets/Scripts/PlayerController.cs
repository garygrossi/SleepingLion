using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countCreamText;

    private int count;

	// Use this for initialization
	void Start () {
        // Init cream collection count
        count = 0;

        // Set the count text
        SetCountText();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 1 + Input.GetAxis("Vertical") * 0.2f);
        transform.position += move * speed * Time.deltaTime;
    }

    // Called when the player overlaps with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check what game object it is
        if (collision.gameObject.CompareTag("Cream"))
        {
            collision.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
        } 
    }

    void SetCountText()
    {
        Data.Score = count;
        countCreamText.text = "Cream Collected: " + count.ToString();
    }
}
