using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    public float m_RotationSpeed;

   
    public Vector3 m_RotationAxis;

    
    void Update()
    {
        
        if (gameObject.activeSelf)
        {
            
            transform.Rotate(m_RotationAxis, m_RotationSpeed * Time.deltaTime);
        }
    }
}
