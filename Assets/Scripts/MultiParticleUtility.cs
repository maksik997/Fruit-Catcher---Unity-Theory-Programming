using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiParticleUtility : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> Particles;

    [SerializeField]
    private float PlayDelay, PlayInterval;

    private void Awake()
    {
        PlayParticle();
    }

    public void PlayParticle()
    {
        StartCoroutine(PlayRoutine());
    }

    public void StopParticle()
    {
        StopCoroutine(PlayRoutine());
        Particles.ForEach(p => p.Stop());
        Destroy(gameObject);
    }

    private IEnumerator PlayRoutine()
    {
        yield return new WaitForSeconds(PlayDelay);
        foreach (ParticleSystem particle in Particles)
        {
            particle.Play();
            yield return new WaitForSeconds(PlayInterval);
        }
        yield return new WaitForSeconds(1); // tmp
        Destroy(gameObject);
    }
}
