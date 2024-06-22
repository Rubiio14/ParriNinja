using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject[] manchas;
    [SerializeField]
    GameObject[] particles;
    [SerializeField]
    GameObject[] smoke;
    public int m_PuntosCarne;
    BoxCollider m_CarneCollider; 
    [SerializeField]
    GameObject carneEntera, carneParte1, carneParte2;

    //MovimientoCarne
    Rigidbody rb;

    //Despawn
    public float m_DespawnTimer = 0f;
    bool m_NeedTimer = false;
    bool m_Smoke = false;

    Vector3 m_RotacionCarnes;
    Vector3 m_RotacionPiezas;


    void Start()
    {
       m_CarneCollider = GetComponent<BoxCollider>();
       rb = GetComponent<Rigidbody>();

       m_RotacionCarnes = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));

    }
    private void OnEnable()
    {
        m_RotacionPiezas = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

    }
    void Update()
    {
        carneEntera.transform.Rotate(m_RotacionCarnes);
        carneParte1.transform.Rotate(m_RotacionPiezas);
        carneParte2.transform.Rotate(m_RotacionPiezas);


        if (m_NeedTimer == true)
        {
            m_DespawnTimer += Time.deltaTime;
        }

        if (m_DespawnTimer >= 1.5f)
        {
            if (m_Smoke == false)
            {
                if (!Cuchillo.instance.m_MeatCutSound.isPlaying)
                {
                    Cuchillo.instance.m_MeatCutSound.Play();
                }
                VFX_Smoke.instance.Smoke(smoke[0], carneParte1);
                VFX_Smoke.instance.Smoke(smoke[1], carneParte2);
                m_Smoke = true;
            }
            carneParte1.SetActive(false);
            carneParte2.SetActive(false);
        }

        if (m_DespawnTimer >= 2.5f)
        {
            gameObject.SetActive(false);
            m_DespawnTimer = 0f;
        }
    }

    private void Reset()
    {
        carneEntera.SetActive(true);
        m_CarneCollider.enabled = true;
    }

    public void Cortado()
    {
        m_CarneCollider.enabled = false;
        rb.isKinematic = true;
        carneEntera.SetActive(false);
        m_NeedTimer = true;
        if (Random.Range(1, 10) == Random.Range(1, 10))
        {
            PowerUps.instance.CriticalHit(m_PuntosCarne);
            VFX_Particles.instance.Particles(particles[1], carneEntera);
        }
        else 
        {
            Score_Manager.instance.SumaPuntos(m_PuntosCarne);
            VFX_Particles.instance.Particles(particles[0], carneEntera);
        }      
        Piezas();
        Fade_Manchas.instance.Mancha(manchas[Random.Range(0, manchas.Length)], carneEntera);
    }

    public void Piezas()
    {
        carneParte1.SetActive(true);
        carneParte2.SetActive(true);
        carneParte1.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, 0), ForceMode.Impulse);
        carneParte2.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, 0), ForceMode.Impulse);
    }
}
