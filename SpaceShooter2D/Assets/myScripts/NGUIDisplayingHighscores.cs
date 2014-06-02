using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGUIDisplayingHighscores : MonoBehaviour 
{
    public UILabel label;
    List<Scores> highscore;

	// Use this for initialization
	void Start () 
    {
        highscore = new List<Scores>();
        highscore = HighScoreBoard._instance.GetHighScore();
        DisplayHighscores();
	}

    void DisplayHighscores()
    {
        for (int i = 0; i < highscore.Count; i++)
        {
            label.text += highscore[i].score + "\n";
        }
    }
}
