using UnityEngine;
using System.Collections;

public class LoginWelcomeMessage : MonoBehaviour {

	public UILabel welcomeMessage;

	void OnEnable() 
	{
		SPLogin.recivedUserInfo += SPLogin_recivedUserInfo;
		GameAuthentication.OnUserAuthEvent += GameAuthentication_OnUserAuthEvent;
	}

	void GameAuthentication_OnUserAuthEvent(string obj) 
	{
		welcomeMessage.text += "Received UserID: " + obj;
	}

	void SPLogin_recivedUserInfo(SPLogin.UserInfo obj)
	{
		welcomeMessage.gameObject.SetActive(true);
		welcomeMessage.text = "Welcome " + obj.name + " ";

		StartCoroutine(MyMethod());
	}

	IEnumerator MyMethod() 
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("mainMenu");
	}
}
