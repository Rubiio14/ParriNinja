using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon_Behaviour : MonoBehaviour
{
    public static Lemon_Behaviour instance;
    public int m_PuntosLimon;
    BoxCollider m_LimonCollider;

    [SerializeField]
    GameObject limonEntero, limonParte1, limonParte2, limonParte3, limonParte4;

    Rigidbody rbLimon;

    //Despawn
    public float m_DespawnTimerLimon = 0f;
    bool m_NeedTimerLimon = false;

    Vector3 m_RotacionLimon;
    Vector3 m_RotacionPiezas;

    //aguantar en el aire
    bool m_NeedHoldTimer = false;
    public float m_holdTimer = 0f;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        m_LimonCollider = GetComponent<BoxCollider>();
        rbLimon = GetComponent<Rigidbody>();

        m_RotacionLimon = new Vector3(Random.Range(0.05f, 0.4f), Random.Range(0.05f, 0.4f), Random.Range(0.05f, 0.4f));
    }
    void Update()
    {
        limonEntero.transform.Rotate(m_RotacionLimon);
        limonParte1.transform.Rotate(m_RotacionPiezas);
        limonParte2.transform.Rotate(m_RotacionPiezas);
        limonParte2.transform.Rotate(m_RotacionPiezas);
        limonParte2.transform.Rotate(m_RotacionPiezas);
        m_RotacionPiezas = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));



        if (m_NeedTimerLimon == true)
        {
            m_DespawnTimerLimon += Time.deltaTime;
        }

        if (m_DespawnTimerLimon >= 3.5)
        {
            gameObject.SetActive(false);
            m_DespawnTimerLimon = 0f;
        }

        if (m_NeedHoldTimer == true)
        {
            m_holdTimer += Time.deltaTime;
        }
        if (m_holdTimer >= 2f)
        {
            Piezas();
        }
    }

    private void Reset()
    {
        limonEntero.SetActive(true);
        m_LimonCollider.enabled = true;
    }

    public void Cortado()
    {
        m_NeedHoldTimer = true;
        rbLimon.isKinematic = true;
        rbLimon.useGravity = false;

        if(m_holdTimer >= 3f)
        {
            Piezas();    
        }
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
        limonEntero.SetActive(false);
        m_LimonCollider.enabled = false;

        if (Random.Range(1, 10) == Random.Range(1, 10))
        {
            PowerUps.instance.CriticalHit(m_PuntosLimon);
        }
        else
        {
            Score_Manager.instance.SumaPuntos(m_PuntosLimon);
        }
        m_NeedTimerLimon = true;

        rbLimon.isKinematic = false;
        rbLimon.useGravity = true;
        m_NeedHoldTimer = false;
        m_holdTimer = 0f;

        limonParte1.SetActive(true);
        limonParte2.SetActive(true);
        limonParte3.SetActive(true);
        limonParte4.SetActive(true);

        limonParte1.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, 0), ForceMode.Impulse);
        limonParte2.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, 0), ForceMode.Impulse);
        limonParte3.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 10, 0), ForceMode.Impulse);
        limonParte4.GetComponent<Rigidbody>().AddForce(new Vector3(3, 10, 0), ForceMode.Impulse);

    }
}
