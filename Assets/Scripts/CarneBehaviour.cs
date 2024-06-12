using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneBehaviour : MonoBehaviour
{
    public int puntosCarne;
    MeshCollider carneCollider;
    MeshRenderer meshCarneCompleta;

    //MovimientoCarne
    Rigidbody rb;
    public bool needForce;

    void Start()
    {
       carneCollider = GetComponent<MeshCollider>();
       rb = GetComponent<Rigidbody>();
       needForce = true;
    }
    void Update()
    {
        if (needForce == true)
        {
            rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //que al hacer el corte se desactive el collider y la malla de la carne completa se desactive
        if (other.gameObject.tag == "Jugador")
        {
            carneCollider.enabled = false;
            meshCarneCompleta.enabled = false;
        }
        if (other.gameObject.tag == "Despawner")
        {
            Destroy(this);
            //y activar Canvas de derrota o restar 1 vida
        }
        if(other.gameObject.tag == "MaxHeight")
        {
            needForce = false;
        }
    }
}
