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
    PowerUp
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
    public int[] spawns;
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
        m_GameTime += Time.deltaTime;
        //Cuentas tiempo
        //un indice del ultimo KeyMoment
        if (actualMoment == gameLoop.Length)
        {
            Debug.Log("Fin juego");
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
