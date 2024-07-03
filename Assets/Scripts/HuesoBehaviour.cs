using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoBehaviour : MonoBehaviour, SlizableItem
{
    Vector3 m_RotacionHueso;

    [SerializeField]
    GameObject particles;

    //Despawn
    public float m_DespawnTimer = 0f;
    bool m_NeedTimer = false;
    private void Start()
    {
        m_RotacionHueso = new Vector3(Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f));

    }
    private void Update()
    {
        gameObject.transform.Rotate(m_RotacionHueso);
        if (m_NeedTimer)
        {
            m_DespawnTimer += Time.deltaTime;
        }
        if (m_DespawnTimer >= 3)
        {
            gameObject.SetActive(false);
            m_DespawnTimer = 0;
            m_NeedTimer = false;
        }
    }
    public void Hueso()
    {
        Health_Manager.instance.RestaVida();
        VFX_Particles.instance.Particles(particles, this.gameObject);
        if (Health_Manager.instance.IsDefeat == false)
        {
            Health_Manager.instance.Defeat();
        }
    }

    public void Slice()
    {
        Hueso();
        Cuchillo.instance.m_BoneSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Despawner")
        {
            m_NeedTimer = true;
        }
    }
}
