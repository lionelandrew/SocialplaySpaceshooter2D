using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

	public GUIText Damage;
	public GUIText AttackRate;
	public GUIText Speed;
	public GUIText Accelleration;
	public GUIText Deceleration;
	public GUIText ShieldStrength;
	
	private float damage;
	private float atkrate;
	private float accelleration;
	private float deceleration;
	private float speed;
	private float shield;
	
	private Done_PlayerController script;
	
	// Use this for initialization
	void Start () 
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			script = player.GetComponent<Done_PlayerController>();
		}
		UpdateStats();
	}
	
	// Update is called once per frame
	void Update () 
	{
		OnButtonPress();
		
		Damage.text = "Damage: " + damage;
		AttackRate.text = "Attack Rate: " + atkrate;
		Accelleration.text = "Accelleration: " + accelleration;
		Deceleration.text = "Deceleration: " + deceleration;
		Speed.text = "Speed: " + speed;
		ShieldStrength.text = "Shield Strength: " + shield;
	}
	
	void OnButtonPress()
	{
		if (Input.GetKeyDown (KeyCode.K))
		{
			damage += 5;
			atkrate += 5;
			accelleration += 5;
			deceleration += 5;
			speed += 5;
			shield += 10;
		}
	}
	
	void UpdateStats()
	{
		damage = 0;
		atkrate = script.fireRate;
		accelleration = 0;
		deceleration = 0;
		speed = script.speed;
		shield = 0;
	}
}
