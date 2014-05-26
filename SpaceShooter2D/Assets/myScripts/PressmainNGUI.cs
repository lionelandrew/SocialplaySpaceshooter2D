using UnityEngine;
using System.Collections;

public class PressmainNGUI : MonoBehaviour
{
    public bool isPaused = true;
    public GameObject inventory;
    public GameObject HUD;
    public GameObject carmera;
    public GameObject player;

    void Start()
    {
        inventory.SetActive(true);
        HUD.SetActive(false);
        carmera.SetActive(false);
        player.SetActive(false);
        PauseGameMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isPaused)
            {
                inventory.SetActive(false);
                HUD.SetActive(true);
                carmera.SetActive(true);
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
