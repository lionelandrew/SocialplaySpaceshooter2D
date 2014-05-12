using UnityEngine;
using System.Collections;

public class LoginWelcomeMessage : MonoBehaviour 
{
	public UILabel welcomeMessage;

	void OnEnable() 
	{
		SPLogin.recivedUserInfo += SPLogin_recivedUserInfo;
	}

	void SPLogin_recivedUserInfo(SPLogin.UserInfo obj)
	{
		Application.LoadLevel("mainMenu");
	}
}
