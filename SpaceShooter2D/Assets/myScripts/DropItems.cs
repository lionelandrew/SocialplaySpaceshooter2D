using UnityEngine;
using System.Collections;

public class DropItems : MonoBehaviour 
{
    public ItemGetter gameItemGetter;

    public void Death()
    {
        DropLoot();
    }

    void DropLoot()
    {
        gameItemGetter.GetItems();

        if (gameObject.GetComponent<SpawnParticleEffect>())
            gameObject.GetComponent<SpawnParticleEffect>().NodeDestroyed();
    }
}
