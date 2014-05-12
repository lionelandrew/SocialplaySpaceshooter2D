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
    private Done_PlayerController playerController;
    private Characters script;
    private Characters script1;

    public int scoreValue;
    private int number;
    private int damage;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<Done_PlayerController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        script = other.GetComponent<Characters>();
        script1 = this.GetComponent<Characters>();

        damage = scoreValue;

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
            damage = playerController.damage;
            script1.ApplyDamage(damage);
            if (script1.currentHealth < 1)
            {
                Death();
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
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
