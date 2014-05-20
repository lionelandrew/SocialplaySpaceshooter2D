using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGUIDisplayNames : MonoBehaviour 
{
    public UILabel label;
    List<Scores> highscore;

    // Use this for initialization
    void Start()
    {
        highscore = new List<Scores>();
        highscore = HighScoreBoard._instance.GetHighScore();
        DisplayHighscores();
    }

    void DisplayHighscores()
    {
        for (int i = 0; i < highscore.Count; i++)
        {
            label.text += (i + 1) + ". " + highscore[i].name + "\n";
        }
    }
}
