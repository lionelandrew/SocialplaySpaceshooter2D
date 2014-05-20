using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText highScoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	public bool gameOver;
	private bool restart;
	public int score;
	private int topHighScore;

    List<Scores> localHighScore;
	
	void Start ()
	{
        localHighScore = new List<Scores>();
        localHighScore = HighScoreBoard._instance.GetHighScore();
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
        topHighScore = localHighScore[0].score;
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
        UpdateScore();
        UpdateHighScore();

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                Application.LoadLevel("mainMenu"); 
			}
		}

        if (gameOver)
        {
            GameOver();
        }
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for MainMenu";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	void UpdateHighScore ()
	{
        if (score < topHighScore)
        {
            highScoreText.text = "Local HighScore: " + topHighScore;
        }
        else if(score > topHighScore)
        {
            highScoreText.text = "Local HighScore: " + score;
        }
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}