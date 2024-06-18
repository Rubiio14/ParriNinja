using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneBehaviour : MonoBehaviour
{
    public static CarneBehaviour instance;
    public int m_PuntosCarne;
    BoxCollider m_CarneCollider;

    [SerializeField]
    GameObject carneEntera, carneParte1, carneParte2;

    //MovimientoCarne
    Rigidbody rb;

    //Despawn
    public float m_DespawnTimer = 0f;
    bool m_NeedTimer = false;

    Vector3 m_RotacionCarnes;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       m_CarneCollider = GetComponent<BoxCollider>();
       rb = GetComponent<Rigidbody>();

       m_RotacionCarnes = new Vector3(Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f));
    }
    void Update()
    {
        carneEntera.transform.Rotate(m_RotacionCarnes);
        carneParte1.transform.Rotate(m_RotacionCarnes);
        carneParte2.transform.Rotate(m_RotacionCarnes);

        if(m_NeedTimer == true)
        {
            m_DespawnTimer += Time.deltaTime;
        }

        if (m_DespawnTimer >= 2.5)
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
        if (Random.RandomRange(1, 10) == Random.RandomRange(1, 10))
        {
            PowerUps.instance.CriticalHit(m_PuntosCarne);
        }
        else 
        {
            Score_Manager.instance.SumaPuntos(m_PuntosCarne);
        }
        
        Piezas();
    }

   

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Despawner")
        {
            gameObject.SetActive(false);
            Health_Manager.instance.RestaVida();


        }
    }

    public void Piezas()
    {
        carneParte1.SetActive(true);
        carneParte2.SetActive(true);
        carneParte1.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, 0), ForceMode.Impulse);
        carneParte2.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, 0), ForceMode.Impulse);
    }
}
