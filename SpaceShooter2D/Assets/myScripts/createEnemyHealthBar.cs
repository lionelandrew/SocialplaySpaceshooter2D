using UnityEngine;
using System.Collections;

public class createEnemyHealthBar : MonoBehaviour 
{
    public GameObject enemyHealthBar;

    void Start()
    {
        if (this != null)
        {
            var itemLocation = this.transform.position;

            Instantiate(enemyHealthBar, itemLocation, enemyHealthBar.transform.rotation);
        }
    }
}
