using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoBehaviour : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //que al impactar con el jugador, se pierda la partida
        if(other.gameObject.tag == "Jugador")
        {

        }
    }
}
