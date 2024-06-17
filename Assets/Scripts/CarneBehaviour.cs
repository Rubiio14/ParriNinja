using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneBehaviour : MonoBehaviour
{
    public static CarneBehaviour instance;
    public int puntosCarne;
    BoxCollider carneCollider;

    public int m_Puntos;

    [SerializeField]
    GameObject carneEntera, carneParte1, carneParte2;

    //MovimientoCarne
    Rigidbody rb;
    //public float verticalVelocity = 15;

    //despawn o llevar a la pool
    public float despawnTimer = 0f;
    bool needTimer = false;

    //rotaciónCarnesAleatorias
    Vector3 rotacionCarnes;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       carneCollider = GetComponent<BoxCollider>();
       rb = GetComponent<Rigidbody>();
       //rb.AddForce(new Vector3(0, verticalVelocity, 0), ForceMode.Impulse);
       rotacionCarnes = new Vector3(Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f));
    }
    void Update()
    {
        carneEntera.transform.Rotate(rotacionCarnes);
        carneParte1.transform.Rotate(rotacionCarnes);
        carneParte2.transform.Rotate(rotacionCarnes);

        if(needTimer == true)
        {
            despawnTimer += Time.deltaTime;
        }

        if (despawnTimer >= 2.5)
        {
            //devolver a la pool
            gameObject.SetActive(false);
            despawnTimer = 0f;
        }
    }

    //Reactivar gameObject
    private void Reset()
    {
        carneEntera.SetActive(true);
        carneCollider.enabled = true;
    }

    public void Cortado()
    {
        carneCollider.enabled = false;
        rb.isKinematic = true;
        carneEntera.SetActive(false);
        needTimer = true;

        Piezas();
    }
    private void OnTriggerEnter(Collider other)
    {
        /*que al hacer el corte se desactive el collider, el rb y la malla de la carne completa se desactive, que se active la de la carne cortada y que se devuelva a la pool(?)
        if (other.gameObject.tag == "Player")
        {
            carneCollider.enabled = false;
            rb.isKinematic = true;
            carneEntera.SetActive(false);
            needTimer = true;

            Piezas();

        }
        */
        if (other.gameObject.tag == "Despawner")
        {
            //devolver objeto a la pool
            gameObject.SetActive(false);
            Health_Manager.instance.health--;
            //en realidad que se haga la función de Reset();
            //y activar Canvas de derrota o restar 1 vida
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
