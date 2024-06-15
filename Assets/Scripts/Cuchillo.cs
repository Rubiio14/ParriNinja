using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    bool m_Pulsado = false;
    void Update()
    {
        //Pulsa el ClickDerecho
        if (Input.GetMouseButtonDown(0))
        {
            m_Pulsado = true;
        }
        //Suelta el CLickDerecho
        if (Input.GetMouseButtonUp(0))
        {
            m_Pulsado = false;
        }
        //Lanza un rayo desde la cámara hacia donde estas clickando con el ratón
        if (m_Pulsado)
        {
            Vector3 m_Position = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(m_Position);
            RaycastHit hit;

            //para mostrar el rayo en el debugger
            float rayLength = 100f;
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            //Printea por pantalla con lo que choca
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
            }
        }
    }
}
