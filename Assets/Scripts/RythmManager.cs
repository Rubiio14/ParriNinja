using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public enum ObjectTypes
{ 
    Chicken,
    Lamb,
    Ribs,
    Bone,
    PowerUp,
    Sausage,
    Meatball,
    Lemon
};
public enum Spawns
{
    Izquierda,
    M_Izquiera,
    Medio,
    M_Derecha,
    Derecha
};

[System.Serializable]
public class KeyMoment
{
    public float m_MusicTiming;
    public float m_DelayLanzamientos;
    public Spawns[] m_Spawns;
    public ObjectTypes[] m_objectTypes;
    public float[] m_MeatVelocity;
    
}

public class RythmManager : MonoBehaviour
{
    public GameObject m_Lanzadores;
    public float m_GameTime;
    public KeyMoment[] gameLoop;
    int actualMoment = 0;
    public static RythmManager instance;
    public bool m_IsLemonActive;

    public void Awake()
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
    public void Update()
    {
        //Tiempo de Juego
        float m_LastGameTime = m_GameTime;
        if (m_IsLemonActive)
        {
            m_GameTime = m_LastGameTime;
        }
        else if(!m_IsLemonActive)
        {
            m_GameTime += Time.deltaTime;
        }
        
        if (actualMoment == gameLoop.Length)
        {
            if (FindObjectOfType<CarneBehaviour>() == null)
            {
                Score_Manager.instance.VictoryScreen();
            }
            
        }
        else 
        {
            if (Mathf.Round(m_GameTime) == gameLoop[actualMoment].m_MusicTiming)
            {
                Debug.Log("LLama a Lanzadores");
                Lanzadores.instance.Lanzamientos(gameLoop[actualMoment]);
                actualMoment++;
            }
        }
    }
}
