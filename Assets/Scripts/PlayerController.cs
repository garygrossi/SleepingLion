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
    public AudioSource rockEffect;
    public AudioSource glassEffect;

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
            if (counter == 20)
            {
                count += 10;
                SetCountText();
                counter = 0;
            }

            if (Data.speed < 5)
            {
                Data.speed = Data.speed + 0.1f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 1 + Input.GetAxis("Vertical") * 0.2f);
            transform.position += move * Data.speed * Time.deltaTime;

            Data.speed = Data.speed + speedMod;
        }
    }

    // Called when the player overlaps with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check what game object it is
        if (collision.gameObject.CompareTag("Cream"))
        {
            Destroy(collision.gameObject);
            count = count + 100;
            SetCountText();
        }

        if (collision.gameObject.CompareTag("Glass"))
        {
            glassEffect.Play();
            life--;
            SetLifeBar();
        }
        
        if (collision.gameObject.CompareTag("Rock"))
        {
            transform.position += new Vector3(0,0.8f);
            HitARock();
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

    void HitARock()
    {
        anim.SetTrigger("fall");
        anim.SetTrigger("getup");
        rockEffect.Play();
        Data.speed = 0;
        life--;
        SetLifeBar();
    }
}
