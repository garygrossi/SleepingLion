using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour {

    public Button homeButton;
    public Text countCreamText;

    void Start()
    {
        countCreamText.text = Data.Score.ToString();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickReplay);
        homeButton.onClick.AddListener(TaskOnClickHome);
    }

    void TaskOnClickReplay()
    {
        SceneManager.LoadScene(1);
    }

    void TaskOnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
