using UnityEngine;
using System.Collections;

public class RotateParticle : MonoBehaviour
{
    public float rotateSpeed = 100;

    void Update()
    {
        float rotation = Time.deltaTime * rotateSpeed;

        gameObject.transform.Rotate(Vector3.forward * rotation);
    }
}
