using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Particles : MonoBehaviour
{
    public static VFX_Particles instance;

    public void Partycles(GameObject particle, GameObject objeto)
    {
        particle.transform.position = objeto.transform.position;

        particle.SetActive(true);

        ParticleSystem newparticles = particle.GetComponent<ParticleSystem>();

        newparticles.Play();
    }
}
