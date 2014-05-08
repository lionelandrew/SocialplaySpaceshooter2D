using UnityEngine;
using System.Collections;

public class PressMain : MonoBehaviour 
{
    public bool isPaused = true;
    public GameObject carmera;
    public GameObject carmera1;
    public GameObject player;

    void Start()
    {
        carmera.SetActive(true);
        carmera1.SetActive(false);
        player.SetActive(false);
        PauseGameMode();
    }

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.D))
		{
            if (isPaused)
            {
                carmera.SetActive(false);
                carmera1.SetActive(true);
                player.SetActive(true);
                ResumeGameMode();
            }
		}
	}

    private void ResumeGameMode()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    private void PauseGameMode()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }
}
