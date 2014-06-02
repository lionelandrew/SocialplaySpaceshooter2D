using UnityEngine;
using System.Collections;

public class EnemyHealthBarNGUI : MonoBehaviour
{
    UISlider _healthBar;
    private float currentHealth;
    private float maxHealth;
    private float normalisedHealth;
    private Characters script;
    int i = 0;

    void Awake()
    {
        GameObject healthBar = GameObject.FindGameObjectWithTag("EnemyHealthBar");
        if (healthBar != null)
        {
            _healthBar = GetComponent<UISlider>();
        }
    }

    void Update()
    {
        i++;
        if(i == 1)
         _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x + 4, _healthBar.transform.localScale.y + 4, _healthBar.transform.localScale.z);
       
       // _healthBar.transform.position = (-(Camera.main.WorldToScreenPoint(-target.position).x - 975), (Camera.main.WorldToScreenPoint(-target.position).y + 340), 100, 16)
        
        //currentHealth = script.currentHealth;
        //maxHealth = script.maxHealth;
       // normalisedHealth = ((float)currentHealth / maxHealth) * 1;
       // _healthBar.value = normalisedHealth;
        
    }
}
