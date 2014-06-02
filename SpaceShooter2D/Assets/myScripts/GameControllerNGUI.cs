using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerNGUI : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public UILabel scoreText;
    public UILabel highScoreText;
    public UILabel restartText;
    public UILabel gameOverText;

    public bool gameOver;
    private bool restart;
    public int score;
    private int topHighScore;

    List<Scores> localHighScore;
    private int emptyList;

    void Start()
    {
        localHighScore = new List<Scores>();
        localHighScore = HighScoreBoard._instance.GetHighScore();
        emptyList = localHighScore.Count;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;

        if (localHighScore.Count == 0)
        {
            topHighScore = 0;
        }
        else
            topHighScore = localHighScore[0].score;

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        UpdateScore();
        UpdateHighScore();

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Application.LoadLevel("mainMenu");
            }
        }

        if (gameOver)
        {
            GameOver();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'F1' for MainMenu";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateHighScore()
    {
        if (score < topHighScore)
        {
            highScoreText.text = "Local HighScore: " + topHighScore;
        }
        else if (score > topHighScore)
        {
            highScoreText.text = "Local HighScore: " + score;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}