using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	public float accel;
	public float decel;
	public float maxSpeed;
	public int damage = 0;
	
	private float time = 0;
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}
	}
	
	void FixedUpdate ()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			time = Time.deltaTime;
			speed = maxSpeed / (accel * time);
			if(speed > maxSpeed)
			{
				speed = maxSpeed;
				time = 0;
			}
			rigidbody.velocity = new Vector3 (-speed,0,0);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			time = Time.deltaTime;
			speed = maxSpeed / (accel * time);
			if(speed > maxSpeed)
			{
				speed = maxSpeed;
				time = 0;
			}
			
			rigidbody.velocity = new Vector3 (speed,0,0);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			time = Time.deltaTime;
			speed = maxSpeed / (accel * time);
			if(speed > maxSpeed)
			{
				speed = maxSpeed;
				time = 0;
			}
			rigidbody.velocity = new Vector3 (0,0,speed);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			time = Time.deltaTime;
			speed = maxSpeed / (accel * time);
			if(speed > maxSpeed)
			{
				speed = maxSpeed;
				time = 0;
			}
			rigidbody.velocity = new Vector3 (0,0,-speed);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.velocity = new Vector3 (0,0,0);
		}
		
		//deceleration
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			time = Time.deltaTime;
			speed = decel - time;
			
			rigidbody.velocity = new Vector3 (-speed,0,0);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			time = Time.deltaTime;
			speed = decel - time;
			
			rigidbody.velocity = new Vector3 (speed,0,0);
		}
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			time = Time.deltaTime;
			speed = decel - time;
			
			rigidbody.velocity = new Vector3 (0,0,speed);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			time = Time.deltaTime;
			speed = decel - time;
			
			rigidbody.velocity = new Vector3 (0,0,-speed);
		}
		
		time = 0;
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
		
		//		rigidbody.position = new Vector3
		//		(
		//			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
		//			0.0f, 
		//			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		//		);
	}
}
