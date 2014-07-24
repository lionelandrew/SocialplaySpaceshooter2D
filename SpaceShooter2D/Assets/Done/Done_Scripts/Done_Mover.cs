using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Awake ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}
