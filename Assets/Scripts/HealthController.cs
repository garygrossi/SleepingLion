using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public GameObject[] health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Data.Life < 3)
        {
            health[2].SetActive(false);
        }

        if (Data.Life < 2)
        {
            health[2].SetActive(false);
            health[1].SetActive(false);
        }

        if (Data.Life < 1)
        {
            health[2].SetActive(false);
            health[1].SetActive(false);
            health[0].SetActive(false);
        }
    }
}
