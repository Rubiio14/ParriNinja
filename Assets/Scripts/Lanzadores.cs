using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lanzadores : MonoBehaviour
{
    
    public GameObject m_Chicken;
    public GameObject m_Lamb;
    public GameObject m_Ribs;
    public GameObject m_Bone;
    public GameObject m_PowerUp;
    //public GameObject m_Chicken;
    //public GameObject m_Chicken;
    //public GameObject m_Chicken;
    //public GameObject m_Chicken;
    public GameObject m_ObjetoCreado;
    Rigidbody rb;
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
    IEnumerator DelayCarne(KeyMoment m_Actualmovement)
    {
        
        for (int i = 0; i < m_Actualmovement.m_objectTypes.Length; i++)
        {
            // stuff
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
            }
            m_ObjetoCreado.transform.position = RythmManager.instance.m_Lanzadores.transform.GetChild(i).transform.position;
            m_ObjetoCreado.GetComponent<Rigidbody>().AddForce(new Vector3(0, m_Actualmovement.m_MeatVelocity[i], 0), ForceMode.Impulse);
           
            yield return new WaitForSeconds(m_Actualmovement.m_DelayLanzamientos);
        }
    }
}
