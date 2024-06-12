using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador_Selector : MonoBehaviour
{
    //Lanzadores
    public GameObject[] m_Lanzadores;
    //Lanzador elegido
    [SerializeField]
    int m_RandomIndex;
    //Cambio entre lanzadores
    float m_DelayLanzadores;
    bool m_CambiaLanzador;

    // Update is called once per frame
    void Update()
    {
        if (m_CambiaLanzador)
        {
            m_RandomIndex = Random.Range(0, m_Lanzadores.Length);
            m_Lanzadores[m_RandomIndex].SetActive(true);
            m_CambiaLanzador = false;
            StartCoroutine(ResetLanzador(m_DelayLanzadores));
        }
        

    }
    IEnumerator ResetLanzador(float m_DelayLanzadores)
    {
        yield return new WaitForSeconds(m_DelayLanzadores);
        m_CambiaLanzador = true;
    }
}
