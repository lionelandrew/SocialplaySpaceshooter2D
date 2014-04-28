using UnityEngine;
using System.Collections;

public class PlayerStore : MonoBehaviour 
{
    Transform storeTransform = null;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.DrawRay(transform.position, transform.forward);
                if (hit.distance < 2 && hit.collider.gameObject.tag == "Store")
                {
                    SpaceShooterStore store = hit.collider.gameObject.GetComponent<SpaceShooterStore>();
                    storeTransform = hit.collider.transform;
                    store.EnterSpaceShooterStore();
                    GetComponent<PlayerInventory>().CloseInventory();
                }
            }
        }

        if (storeTransform != null)
        {
            if (Vector3.Distance(transform.position, storeTransform.position) > 6)
            {
                storeTransform.gameObject.GetComponent<SpaceShooterStore>().LeaveSpaceShooterStore();
                storeTransform = null;
            }
        }
	}
}
