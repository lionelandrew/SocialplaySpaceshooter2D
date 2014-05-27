using UnityEngine;
using System.Collections;

public class PlayerHealthBarNGUI : MonoBehaviour
{
    public UISlider _healthBar;
    private float currentHealth;
    private float maxHealth;
    private float normalisedHealth;
    private Characters script;
    public GameObject healthBarForeground;

    void Awake()
    {
        if (_healthBar != null)
        {
            _healthBar = GetComponent<UISlider>();
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            script = player.GetComponent<Characters>();
        }
    }

    void Update()
    {
        currentHealth = script.currentHealth;
        maxHealth = script.maxHealth;
        normalisedHealth = ((float)currentHealth / maxHealth) * 1;
        _healthBar.value = normalisedHealth;

        if (_healthBar.value == 0)
            healthBarForeground.SetActive(false);
    }
}
