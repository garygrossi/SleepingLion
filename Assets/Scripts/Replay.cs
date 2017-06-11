using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

public class Replay : MonoBehaviour {

    public GameObject secretLion;
    public Button homeButton;
    public Text countCreamText;

    void Start()
    {
        int Score = Data.Score;
        if (Score >= 10000)
        {
            countCreamText.text = Data.Score.ToString() + "\n You have unlocked The Secret Lion!";
            secretLion.SetActive(true);
        } else
        {
            countCreamText.text = Data.Score.ToString();
        }
        //saveScore();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickReplay);
        homeButton.onClick.AddListener(TaskOnClickHome);
    }

    void saveScore()
    {
        var fileName = "highscores.txt";
        var filePath = @"";

        if (!File.Exists(fileName))
        {
            Debug.Log("Creating new file");
            var sr = File.CreateText(fileName);
            sr.WriteLine(Data.Score.ToString());
            sr.Close();
        }
        else
        {
            Debug.Log("Writing to file");
            var file = File.AppendText(filePath + fileName);
            file.WriteLine(Data.Score.ToString());
            file.Close();
        }
    }

    void TaskOnClickReplay()
    {
        Data.speed = 5;
        SceneManager.LoadScene(1);
    }

    void TaskOnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
