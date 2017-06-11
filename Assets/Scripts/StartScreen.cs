using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

    //public Button highScore;
    
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        //highScore.onClick.AddListener(TaskOnClickHighScore);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }

    void TaskOnClickHighScore()
    {
        SceneManager.LoadScene(3);
    }
}
