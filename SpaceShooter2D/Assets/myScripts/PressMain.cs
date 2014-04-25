using UnityEngine;
using System.Collections;

public class PressMain : MonoBehaviour {
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.D))
		{
			Application.LoadLevel("Done_Main");
		}
	}

}
