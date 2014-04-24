using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPickup : MonoBehaviour
{
    public GameItemContainerInserter containerInserter;
    public float pickupRadius = 2;
    public GameObject pickupParticle;
    public AudioClip itemPickupSound;

    void Update()
    {
        List<ItemData> items = new List<ItemData>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);

        for (int c = 0; c < colliders.Length; c++)
        {
            if (colliders[c].transform.GetComponent<ItemData>())
            {
                ItemData item = colliders[c].transform.GetComponent<ItemData>();
                items.Add(item);

                audio.PlayOneShot(itemPickupSound);
                SpawnItemGetParticle();
            }
        }

        if (items.Count > 0)
        {
            containerInserter.PutGameItem(items);
        }
    }

    public void SpawnItemGetParticle()
    {
        GameObject particle = Instantiate(pickupParticle,
                                          gameObject.transform.position,
                                          pickupParticle.transform.rotation) as GameObject;
    }
}
