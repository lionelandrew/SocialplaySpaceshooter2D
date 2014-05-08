using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject playerExplosion;
    private Done_PlayerController script;
    
    public int minDamage;
    public int maxDamage;

	void Start ()
	{
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            script = player.GetComponent<Done_PlayerController>();
        }
	}

	void OnTriggerEnter (Collider other)
	{
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (script != null)
        {
            int damage = Random.Range(minDamage, maxDamage + 1);
            script.ApplyDamage(damage);
        }

        if (other.gameObject.tag == "Asteroids" || other.gameObject.tag == "Crate")
        {
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
	}
}