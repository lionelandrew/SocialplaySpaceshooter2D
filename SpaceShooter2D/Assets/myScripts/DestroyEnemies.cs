using UnityEngine;
using System.Collections;
using System;
using SocialPlay.ItemSystems;
using SocialPlay.Data;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class DestroyEnemies : MonoBehaviour 
{
    public GameObject explosion;
    public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
    private Done_PlayerController script;
    private GameObject player;
	public ItemGetter gameItemGetter;
    private int number;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
        if (other.tag == "Boundary" || other.tag == "EnemiesShot" || other.tag == "Asteroids")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

        if (other.tag == "Shot" && GameObject.FindGameObjectWithTag("Enemy"))
		{
			Death ();
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
		}
        else if (other.tag == "Shot" && GameObject.FindGameObjectWithTag("Asteroids"))
        {
            number = UnityEngine.Random.Range(1, 6);

            if (number == 3)
            {
                Death();
                gameController.AddScore(scoreValue);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (number == 1 || number == 2 || number == 4 || number == 5)
            {
                gameController.AddScore(scoreValue);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
	
	void Death()
	{
		DropLoot();
	}
	
	void DropLoot()
	{
		gameItemGetter.GetItems();
		
		if (gameObject.GetComponent<SpawnParticleEffect>())
			gameObject.GetComponent<SpawnParticleEffect>().NodeDestroyed();
	}

}
