using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    int m_NCarnes = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RythmManager.instance.gameLoop.Length; i++)
        {
            for (int j = 0; j < RythmManager.instance.gameLoop[j].m_objectTypes.Length; j++)
            {
                Debug.Log("Suma 1 a " + m_NCarnes + " Carnes");
                m_NCarnes++;
                
            }
            
        }
    }

    void Update()
    {
        if (m_NCarnes == 0)
        { 
            Debug.Log("Fin");
        }
    }

}
