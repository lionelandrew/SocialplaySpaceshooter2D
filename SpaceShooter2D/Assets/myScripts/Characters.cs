﻿using UnityEngine;
using System.Collections;

public class Characters : MonoBehaviour
{
    public float currentHealth = 0;
    public float maxHealth = 0;

    private int die = 0;
    private bool hasDied = false;

    private Done_GameController gameController;
    public GameObject playerExplosion;

    void Start()
    {
        currentHealth = maxHealth;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
    }

    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 1)
        {
            hasDied = true;
            die++;
            if (die == 1 && hasDied)
            {
                if (gameObject.tag == "Player")
                {
                    Instantiate(playerExplosion, transform.position, transform.rotation);
                    gameController.GameOver();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}