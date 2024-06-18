using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void CriticalHit(int m_Puntos)
    {
        Score_Manager.instance.SumaPuntos(m_Puntos * 2);
    }

}
