using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject playerExplosion;
	private Done_GameController gameController;
    private Done_PlayerController script;
    private GameObject player;
    
    private int damage;
    public int minDamage;
    public int maxDamage;

	void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            script = player.GetComponent<Done_PlayerController>();
        }

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
	}

	void OnTriggerEnter (Collider other)
	{
 

        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            damage = Random.Range(minDamage, maxDamage + 1);
            script.playerHealth -= damage;
        }

        if (GameObject.FindGameObjectWithTag("Asteroids") || GameObject.FindGameObjectWithTag("Crate"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
	}
}