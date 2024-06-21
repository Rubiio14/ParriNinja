using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Particles : MonoBehaviour
{
    public static VFX_Particles instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Particles(GameObject particle, GameObject objeto)
    {
        particle.transform.position = objeto.transform.position;

        particle.SetActive(true);

        ParticleSystem newparticles = particle.GetComponent<ParticleSystem>();

        float yRotation = particle.transform.rotation.y;

        yRotation = Random.value;

        newparticles.Play();
    }
}
