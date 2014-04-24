using UnityEngine;
using System.Collections;

public class SpawnParticleEffect : MonoBehaviour
{
    public PlayerPickup playerPickup;

    public void NodeDestroyed()
    {
        playerPickup.SpawnItemGetParticle();
    }
}
