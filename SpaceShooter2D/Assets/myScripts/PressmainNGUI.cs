using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressmainNGUI : MonoBehaviour
{
    public bool isPaused = true;
    public GameObject inventory;
    public GameObject HUD;
    public GameObject carmera;
    public GameObject player;
    public GameObject nameInput;
    private GameControllerNGUI gameController;
    List<Scores> highscore;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameControllerNGUI>();
        }

        highscore = new List<Scores>();
        highscore = HighScoreBoard._instance.GetHighScore();
        inventory.SetActive(true);
        HUD.SetActive(false);
        carmera.SetActive(false);
        player.SetActive(false);
        nameInput.SetActive(false);
        PauseGameMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isPaused)
            {
                this.transform.Rotate(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z);
                inventory.SetActive(false);
                HUD.SetActive(true);
                carmera.SetActive(true);
                player.SetActive(true);
                ResumeGameMode();
            }
        }

        if(gameController.gameOver  && nameInput.GetComponent<MenuControllerNGUI>().entered == false)
        {
            if (highscore.Count < 10)
           {
                nameInput.SetActive(true);
           }
           else if (highscore[highscore.Count - 1].score < gameController.score)
           {
                nameInput.SetActive(true);
           }
        }
    }

    private void ResumeGameMode()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    private void PauseGameMode()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }
}
