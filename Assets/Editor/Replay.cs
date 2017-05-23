using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
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
        EditorSceneManager.LoadScene(0);
        Debug.Log("You have clicked the button!");
    }
}
