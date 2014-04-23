using UnityEngine;
using System.Collections;

public class LoginItemContainer : MonoBehaviour {

	public GameObject LimitedContainerObject;

	void OnEnable()
	{
		GameAuthentication.OnUserAuthEvent += GameAuthentication_OnUserAuthEvent;
	}

	void GameAuthentication_OnUserAuthEvent(string obj)
	{
		LimitedContainerObject.SetActive(true);
	}

}
