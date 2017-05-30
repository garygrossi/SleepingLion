using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] objects;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    private bool pause;

	// Use this for initialization
	void Start () {
        Spawner();
        pause = false;
	}

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            if (pause)
            {
                pause = false;
                Invoke("Spawner", Random.Range(minSpawnTime, maxSpawnTime));
                Debug.Log("Play");
            } else { 
                pause = true;
                Debug.Log("Paused");
            }
        }
    }

    void Spawner()
    {
        if (!pause) { 
            Instantiate(objects[Random.Range(0, objects.GetLength(0))], transform.position, Quaternion.identity);
            Invoke("Spawner", Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}
