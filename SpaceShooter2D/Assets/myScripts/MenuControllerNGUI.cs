using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UIInput))]
public class MenuControllerNGUI : MonoBehaviour 
{
    private GameControllerNGUI gameController;
    string name = "";
    int score = 0;
    List<Scores> highscore;
    public bool entered = false;
    UIInput uiInput;
    public GameObject nameInput;

	// Use this for initialization
	void Start () 
    {
        uiInput = this.GetComponent<UIInput>();

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameControllerNGUI>();
        }

        highscore = new List<Scores>();
	}

    void OnPress()
    {
        if (Input.GetMouseButtonDown(0))
        {}

        if(Input.GetKeyDown(KeyCode.Return))
        {
            name = uiInput.label.text;
            score = gameController.score;
            UpdatehighScore();
        }
    }

	// Update is called once per frame
	void UpdatehighScore () 
    {
        HighScoreBoard._instance.SaveHighScore(name, score);
        highscore = HighScoreBoard._instance.GetHighScore();
        entered = true;
        nameInput.SetActive(false);
	}
}
