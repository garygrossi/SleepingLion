using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countCreamText;
    public Text lifeText;
    public AudioSource backgroundMusic;
    //public AudioSource gameplayAudio;

    private int count;
    private int counter;
    private int life;
    private float speedMod = 0.001f;
    private bool pause;
    private Animator anim;

    // Use this for initialization
    void Start () {
        // Init cream collection count
        count = 0;
        counter = 0;
        life = 3;
        pause = false;

        anim = GetComponent<Animator>();

        // Set the count text
        SetCountText();
        SetLifeBar();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            if (pause)
            {
                pause = false;
                backgroundMusic.Play();
                anim.enabled = true;
                Debug.Log("Play");
            }
            else
            {
                pause = true;
                backgroundMusic.Pause();
                anim.enabled = false;
                Debug.Log("Paused");
            }
        }

        if (!pause) { 
            counter = counter + 1;
            if (counter == 60)
            {
                count += 10;
                SetCountText();
                counter = 0;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 1 + Input.GetAxis("Vertical") * 0.2f);
            transform.position += move * speed * Time.deltaTime;

            speed = speed + speedMod;
        }
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

        if (collision.gameObject.CompareTag("Glass"))
        {
            // Do something
            life--;
            SetLifeBar();
        }
        
        if (collision.gameObject.CompareTag("Rock"))
        {
            // Do something
            //speed = 5;
            life--;
            SetLifeBar();
        }
        
    }

    void SetCountText()
    {
        Data.Score = count;
        countCreamText.text = "Score: " + count.ToString();
    }

    void SetLifeBar()
    {
        Data.Life = life;
        lifeText.text = "Health: " + life.ToString();
        if (life <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
