using UnityEngine;
using System.Collections;

public class EnemyHealthBarNGUI : MonoBehaviour
{
    public UISlider _healthBar;
    private float currentHealth;
    private float maxHealth;
    private float normalisedHealth;
    private Characters script;
    GameObject healthBar;
    public GameObject healthBar1;

    public GameObject target;
    private Transform target1;

    void Awake()
    {
        if (healthBar != null)
        {
            _healthBar = GetComponent<UISlider>();
        }

        if (target != null)
        {
            script = target.GetComponent<Characters>();
        }
    }

    void Update()
    {
        currentHealth = script.currentHealth;
        maxHealth = script.maxHealth;
        normalisedHealth = ((float)currentHealth / maxHealth) * 1;
        _healthBar.value = normalisedHealth;

        if (_healthBar.value == 0)
            healthBar1.SetActive(false);
    }
}
