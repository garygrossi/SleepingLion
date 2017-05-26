using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour {

    public Button replayButton;
    public Text countCreamText;

    void Start()
    {
        countCreamText.text = Data.Score.ToString();
        Button btn = replayButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
