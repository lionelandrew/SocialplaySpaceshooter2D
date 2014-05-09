using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject playerExplosion;
    private Characters script;
    
    public int minDamage;
    public int maxDamage;
    private int damage;

	void Start ()
	{
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            script = player.GetComponent<Characters>();
        }
	}

	void OnTriggerEnter (Collider other)
	{
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (script != null && other.tag == "Player")
        {
            damage = Random.Range(minDamage, maxDamage + 1);
            script.ApplyDamage(damage);
        }

        if (other.tag == "Asteroids" || other.tag == "Crate")
        {
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
	}
}