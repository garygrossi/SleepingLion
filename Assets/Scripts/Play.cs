using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {
    
    public Text countCreamText;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickReplay);
        SetHighScores(GetHighScores());
    }

    List<String> GetHighScores()
    {
        var fileName = "highscores.txt";
        var filePath = @"";
        List<String> results = new List<String>();

        if (!File.Exists(fileName))
        {
            results.Add("No high scores yet");
            return results;
        }
        else
        {
            Debug.Log("Reading file");
            var file = new StreamReader(filePath + fileName);
            String line;
            while ((line = file.ReadLine()) != null)
            {
                Debug.Log("Line" + line);
                results.Add(line);
            }
            file.Close();
            results.Sort();
            results.Reverse();
            return results;
        }
    }

    void SetHighScores(List<String> scores)
    {
        String scoreString = "";
        foreach (var score in scores.ToArray())
        {
            Debug.Log("Setting score " + score);
            scoreString = scoreString + score + "\n";
        }
        countCreamText.text = scoreString;
    }

    void TaskOnClickReplay()
    {
        SceneManager.LoadScene(1);
    }
}
