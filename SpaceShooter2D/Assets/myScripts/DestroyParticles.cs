using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour
{
    public ParticleSystem particle;

	void Start ()
    {
        StartCoroutine("Wait");
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(particle.startLifetime);

        Destroy(gameObject);
    }
}
