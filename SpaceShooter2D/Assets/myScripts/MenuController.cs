using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    private Done_GameController gameController;
    string name = "";
    int score = 0;
    List<Scores> highscore;
    private bool entered = false;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }

        highscore = new List<Scores>();
    }


    void ButtonClicked(GameObject _obj)
    {
        print("Clicked button:" + _obj.name);
    }

    // Update is called once per frame
    void Update()
    {
        score = gameController.score;
    }

    void OnGUI()
    {
        if (gameController.gameOver && !entered)
        {
            GUILayout.BeginArea(new Rect(360, 170, 300, 300));
            GUILayout.Space(60);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name :");
            name = GUILayout.TextField(name, 15);
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Please Enter Name To Save Name/Score"))
            {
                HighScoreBoard._instance.SaveHighScore(name, score);
                highscore = HighScoreBoard._instance.GetHighScore();
                entered = true;
            }

            GUILayout.EndArea();
        }
    }
}