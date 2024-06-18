using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoBehaviour : MonoBehaviour
{
    Vector3 m_RotacionHueso;
    private void Start()
    {
        m_RotacionHueso = new Vector3(Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f), Random.Range(0.05f, 0.25f));

    }
    private void Update()
    {
        gameObject.transform.Rotate(m_RotacionHueso);

    }
    public void Hueso()
    {
        Health_Manager.instance.RestaVida();
        Health_Manager.instance.Defeat();
    }
}
