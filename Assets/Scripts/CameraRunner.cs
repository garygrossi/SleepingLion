using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour {

    public Transform player;
    public GameObject pauseOverlay;

    //private float speed = 5;
    private float speedmod = 0.001f;
    private bool pause;

	// Use this for initialization
	void Start () {
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            if (pause)
            {
                pause = false;
                pauseOverlay.SetActive(false);
                Debug.Log("Play");
            }
            else
            {
                pause = true;
                pauseOverlay.SetActive(true);
                Debug.Log("Paused");
            }
        }

        if (!pause)
        {
            transform.position += new Vector3(0, Data.speed * Time.deltaTime);
            //speed += speedmod;
        }
	}
}
