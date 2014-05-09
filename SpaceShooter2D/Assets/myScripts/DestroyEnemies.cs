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

    public ItemGetter gameItemGetter;
	private Done_GameController gameController;
    private Characters script;
    private Characters script1;
    private Characters script2;

    public int scoreValue;
    private int number;
    private int damage;

	void Start ()
	{
        damage = scoreValue;

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            script = player.GetComponent<Characters>();
        }

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            script1 = enemy.GetComponent<Characters>();
        }

        GameObject asteroids = GameObject.FindGameObjectWithTag("Asteroids");
        if (asteroids != null)
        {
            script2 = asteroids.GetComponent<Characters>();
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

        if (other.tag == "Shot" && gameObject.tag == "Enemy")
		{
			Death ();
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
		}
        else if (other.tag == "Shot" && gameObject.tag == "Asteroids")
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
        else if (other.tag == "Player" && gameObject.tag == "Asteroids" || other.tag == "Player" && gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (script != null && other.tag == "Player")
        {
            script.ApplyDamage(damage);
        }

        if (other.tag == "Asteroids" || other.tag == "Crate")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
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
