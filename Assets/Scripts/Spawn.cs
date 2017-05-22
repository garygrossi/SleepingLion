using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] objects;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 2f;

	// Use this for initialization
	void Start () {
        Spawner();
	}
	
    void Spawner()
    {
        Instantiate(objects[Random.Range(0, objects.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawner", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
