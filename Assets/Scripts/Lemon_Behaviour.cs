using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon_Behaviour : MonoBehaviour, SlizableItem
{
    public static Lemon_Behaviour instance;
    public int m_PuntosLimon;
    BoxCollider m_LimonCollider;

    [SerializeField]
    GameObject manchas;
    [SerializeField]
    GameObject particles;
    [SerializeField]
    GameObject[] smoke;

    [SerializeField]
    GameObject limonEntero, limonParte1, limonParte2, limonParte3, limonParte4;

    Rigidbody rbLimon;

    //Despawn
    public float m_DespawnTimerLimon = 0f;
    public bool m_NeedTimerLimon = false;
    public bool m_Smoke = false;

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

        m_RotacionLimon = new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f));

    }
    private void OnEnable()
    {
        m_RotacionPiezas = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

    }
    void Update()
    {
        limonEntero.transform.Rotate(m_RotacionLimon);
        limonParte1.transform.Rotate(m_RotacionPiezas);
        limonParte2.transform.Rotate(m_RotacionPiezas);
        limonParte3.transform.Rotate(m_RotacionPiezas);
        limonParte4.transform.Rotate(m_RotacionPiezas);



        if (m_NeedTimerLimon == true)
        {
            m_DespawnTimerLimon += Time.deltaTime;
        }

        if (m_DespawnTimerLimon >= 1.5)
        {
            if (m_Smoke == false)
            {
                if(!Cuchillo.instance.m_MeatCutSound.isPlaying)
                {
                    Cuchillo.instance.m_MeatCutSound.Play();
                }
                VFX_Smoke.instance.Smoke(smoke[0], limonParte1);
                VFX_Smoke.instance.Smoke(smoke[1], limonParte2);
                VFX_Smoke.instance.Smoke(smoke[2], limonParte3);
                VFX_Smoke.instance.Smoke(smoke[3], limonParte4);
                m_Smoke = true;
            }
            limonParte1.SetActive(false);
            limonParte2.SetActive(false);
            limonParte3.SetActive(false);
            limonParte4.SetActive(false);
        }

        if (m_DespawnTimerLimon >= 2.5)
        {
            Destroy(gameObject);
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
        RythmManager.instance.m_IsLemonActive = true;
        VFX_Particles.instance.Particles(particles, limonEntero);
        Score_Manager.instance.SumaPuntos(m_PuntosLimon);

        if (m_holdTimer >= 3f)
        {
            Piezas();
        }
    }

    public void Piezas()
    {
        limonEntero.SetActive(false);
        m_LimonCollider.enabled = false;
        RythmManager.instance.m_IsLemonActive = false;

        m_NeedTimerLimon = true;

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

        Fade_Manchas.instance.Mancha(manchas, this.gameObject);
    }

    public void Slice()
    {
        Cortado();
        Cuchillo.instance.m_CutSound.Play();
    }
}
