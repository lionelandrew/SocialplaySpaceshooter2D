using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayHighScores : MonoBehaviour 
{
    List<Scores> highscore;
    GUIStyle guiStyle;
    GUIStyle guiStyle1;

    // Use this for initialization
    void Start()
    {
        highscore = new List<Scores>();
        guiStyle = new GUIStyle();
        guiStyle1 = new GUIStyle();
        guiStyle.fontSize = 40;
        guiStyle.normal.textColor = Color.white;
        guiStyle1.fontSize = 20;
        guiStyle1.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(160, 20, 3000, 3000));
        highscore = HighScoreBoard._instance.GetHighScore();

        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", guiStyle, GUILayout.Width((Screen.width / 2) + 50) );
        GUILayout.Label("Scores", guiStyle, GUILayout.Width(Screen.width / 2));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        for (int i = 0; i < highscore.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label((i+1) + ". " + highscore[i].name, guiStyle1, GUILayout.Width((Screen.width / 2) + 50));
            GUILayout.Label("" + highscore[i].score, guiStyle1, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }

        /*was a for each above is how to change from a foreach to a for loop
        foreach (Scores _score in highscore)
        { 
            GUILayout.BeginHorizontal();
            GUILayout.Label(_score.name, guiStyle1, GUILayout.Width((Screen.width / 2) + 50));
            GUILayout.Label("" + _score.score, guiStyle1, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }*/
        GUILayout.EndArea();
    }
}
