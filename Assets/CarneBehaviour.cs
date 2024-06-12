using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneBehaviour : MonoBehaviour
{
    public int puntosCarne;
    MeshCollider carneCollider;
    MeshRenderer meshCarneCompleta;

    void Start()
    {
       carneCollider = GetComponent<MeshCollider>();
    }
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //que al hacer el corte se desactive el collider y la malla de la carne completa se desactive
        if (other.gameObject.tag == "Jugador")
        {
            carneCollider.enabled = false;
            meshCarneCompleta.enabled = false;
        }
    }
}
