using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class VFX_Smoke : MonoBehaviour
{
    public static VFX_Smoke instance;

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

    public void Smoke(GameObject smoke, GameObject carne)
    {
        smoke.transform.position = carne.transform.position;

        smoke.SetActive(true);

        ParticleSystem newsmoke = smoke.GetComponent<ParticleSystem>();

        newsmoke.Play();
    }

}
