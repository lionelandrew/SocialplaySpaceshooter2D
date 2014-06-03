using UnityEngine;
using System.Collections;

public class EnemyHealthBarNGUI : MonoBehaviour
{
    UISlider[] _healthBar;
    private float currentHealth;
    private float maxHealth;
    private float normalisedHealth;
    private Characters[] script;
    GameObject[] healthBar;
    GameObject[] enemy;
    int i = 0;

    void Awake()
    {
        healthBar = GameObject.FindGameObjectsWithTag("EnemyHealthBar");
        if (healthBar != null)
        {
            _healthBar = GetComponents<UISlider>();
        }

        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy != null)
        {
            script = GetComponents<Characters>();
        }
    }

    void Update()
    {
        i++;
        if(i == 1)
        {

            for(int k = 0; k <= _healthBar.Length; k++)
            {
                currentHealth = script[k].currentHealth;
                maxHealth = script[k].maxHealth;
                normalisedHealth = ((float)currentHealth / maxHealth) * 1;
                _healthBar[k].value = normalisedHealth;

                _healthBar[k].transform.localScale = new Vector3(_healthBar[k].transform.localScale.x + 4, _healthBar[k].transform.localScale.y + 4, _healthBar[k].transform.localScale.z);
                _healthBar[k].transform.position = new Vector3(-(Camera.main.WorldToScreenPoint(-enemy[k].transform.position).x - 975), (Camera.main.WorldToScreenPoint(-enemy[k].transform.position).y + 340), 0);
            }
        }


    }
}
