using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class Lanzadores : MonoBehaviour
{
    public GameObject m_Chicken;
    public GameObject m_Lamb;
    public GameObject m_Ribs;
    public GameObject m_Sausage;
    public GameObject m_Meatball;
    public GameObject m_Bone;
    public GameObject m_PowerUp;
    public GameObject m_Lemon;


    public GameObject m_ObjetoCreado;
    public Transform m_Spawn;
    public float m_SpawnRotation;

    public static Lanzadores instance;

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

    public void Lanzamientos(KeyMoment m_Actualmovement)
    {
        StartCoroutine(DelayCarne(m_Actualmovement));  
    }
    IEnumerator DelayCarne(KeyMoment m_Actualmovement)
    {

        for (int i = 0; i < m_Actualmovement.m_objectTypes.Length; i++)
        {
            //Spawns
            switch (m_Actualmovement.m_Spawns[i])
            {
                case Spawns.Izquierda:
                    m_Spawn = Spawn_Izq();
                    m_SpawnRotation = Random.Range(1f, 2f);
                    break;
                case Spawns.M_Izquiera:
                    m_Spawn = Spawn_M_Izq();
                    m_SpawnRotation = Random.Range(0.5f, 1f);
                    break;
                case Spawns.Medio:
                    m_Spawn = Spawn_Medio();
                    m_SpawnRotation = Random.Range(0.1f, -0.1f);
                    break;
                case Spawns.M_Derecha:
                    m_Spawn = Spawn_M_Dcha();
                    m_SpawnRotation = Random.Range(-0.5f, -1f);
                    break;
                case Spawns.Derecha:
                    m_Spawn = Spawn_Dcha();
                    m_SpawnRotation = Random.Range(-1f, -2f);
                    break;
            }
            //Objetos
            Debug.Log("Entra al for");
            switch (m_Actualmovement.m_objectTypes[i])
            {
                case ObjectTypes.Chicken:
                    m_ObjetoCreado = CreaChiken();
                    break;
                case ObjectTypes.Lamb:
                    m_ObjetoCreado = CreaLamb();
                    break;
                case ObjectTypes.Ribs:
                    m_ObjetoCreado = CreaRibs();
                    break;
                case ObjectTypes.Bone:
                    m_ObjetoCreado = CreaBone();
                    break;
                case ObjectTypes.PowerUp:
                    m_ObjetoCreado = CreaPowerUp();
                    break;
                case ObjectTypes.Sausage:
                    m_ObjetoCreado = CreaSausage();
                    break;
                case ObjectTypes.Meatball:
                    m_ObjetoCreado = CreaMeatball();
                    break;
                case ObjectTypes.Lemon:
                    m_ObjetoCreado = CreaLemon();
                    break;
            }
            //Lanzamiento
            m_ObjetoCreado.transform.position = m_Spawn.transform.position;
            m_ObjetoCreado.GetComponent<Rigidbody>().AddForce(new Vector3(m_SpawnRotation, m_Actualmovement.m_MeatVelocity[i], 0), ForceMode.Impulse);
            yield return new WaitForSeconds(m_Actualmovement.m_DelayLanzamientos);
        }
    }

    //Metodos que Marcan el Spawn
    public Transform Spawn_Medio()
    {
        return RythmManager.instance.m_Lanzadores.transform.GetChild(0);
    }
    public Transform Spawn_M_Dcha()
    {
        return RythmManager.instance.m_Lanzadores.transform.GetChild(1);
    }
    public Transform Spawn_Dcha()
    {
        return RythmManager.instance.m_Lanzadores.transform.GetChild(2);
    }
    public Transform Spawn_M_Izq()
    {
        return RythmManager.instance.m_Lanzadores.transform.GetChild(3);
    }
    public Transform Spawn_Izq()
    {
        return RythmManager.instance.m_Lanzadores.transform.GetChild(4);
    }
    //Metodos que instancian Objetos
    public GameObject CreaChiken()
    {
        GameObject m_ChickenClone = Instantiate(m_Chicken);
        return m_ChickenClone;
    }
    public GameObject CreaLamb()
    {
        GameObject m_LambClone = Instantiate(m_Lamb);
        return m_LambClone;
    }
    public GameObject CreaRibs()
    {
        GameObject m_RibsClone = Instantiate(m_Ribs);
        return m_RibsClone;
    }
    public GameObject CreaBone()
    {
        GameObject m_BoneClone = Instantiate(m_Bone);
        return m_BoneClone;
    }
    public GameObject CreaPowerUp()
    {
        GameObject m_PowerUps = Instantiate(m_PowerUp);
        return m_PowerUps;
    }
    public GameObject CreaSausage()
    {
        GameObject m_SausageClone = Instantiate(m_Sausage);
        return m_SausageClone;
    }
    public GameObject CreaMeatball()
    {
        GameObject m_MeatballClone = Instantiate(m_Meatball);
        return m_MeatballClone;
    }
    public GameObject CreaLemon() 
    {
        GameObject m_LemonClone = Instantiate(m_Lemon);
        return m_LemonClone;
    }
}
