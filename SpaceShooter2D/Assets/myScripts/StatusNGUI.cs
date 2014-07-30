using UnityEngine;
using System.Collections;

public class StatusNGUI : MonoBehaviour
{
	
	public UILabel Damage;
	public UILabel AttackRate;
	public UILabel Speed;
	public UILabel Accelleration;
	public UILabel Deceleration;
	public UILabel ShieldStrength;
	public UILabel Protection;
	
	private float damage;
	private float atkrate;
	private float accelleration;
	private float deceleration;
	private float speed;
	private float shield;
	private float protection;
	
	private Done_PlayerController script;
	
	// Use this for initialization
	void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			script = player.GetComponent<Done_PlayerController>();
		}
		UpdateStats();
	}
	
	// Update is called once per frame
	void Update()
	{
		//OnButtonPress();
		
		Damage.text = "Damage: " + damage;
		AttackRate.text = "Attack Rate: " + atkrate;
		Accelleration.text = "Accelleration: " + accelleration;
		Deceleration.text = "Deceleration: " + deceleration;
		Speed.text = "Speed: " + speed;
		ShieldStrength.text = "Shield Strength: " + shield;
		Protection.text = "Protection: " + protection;
	}
	
	//    void OnButtonPress()
	//    {
	//        if (Input.GetKeyDown(KeyCode.K))
	//        {
	//            damage += 5;
	//            atkrate += 5;
	//            accelleration += 5;
	//            deceleration += 5;
	//            speed += 5;
	//            shield += 10;
	//            protection += 10;
	//        }
	//    }
	
	void UpdateStats()
	{
		damage = script.damage;
		atkrate = script.fireRate;
		accelleration = script.accel;
		deceleration = script.decel;
		speed = script.speed;
		shield = 0;
		protection = 0;
	}
}
