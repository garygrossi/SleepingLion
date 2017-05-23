using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DestroyerScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grass")
        {
            collision.gameObject.transform.position += new Vector3(0, 11.5f);
        }
        else if (collision.tag == "Player")
        {
            EditorSceneManager.LoadScene(1);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}