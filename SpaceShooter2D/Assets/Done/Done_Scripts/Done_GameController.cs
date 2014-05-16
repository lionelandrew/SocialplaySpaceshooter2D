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
	private int highScore;

    List<Scores> highscore1;
	
	void Start ()
	{
        highscore1 = new List<Scores>();
        highscore1 = HighScoreBoard._instance.GetHighScore();
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
        highScore = highscore1[0].score;
		UpdateScore ();
		UpdateHighScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
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
		highScoreText.text = "Local HighScore: " + highScore;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}