using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    public float rotationSpeed = 100f;

    // Eje sobre el cual rotar.
    public Vector3 rotationAxis = Vector3.up;

    // Update se llama una vez por frame.
    void Update()
    {
        // Si el objeto est� activo.
        if (gameObject.activeSelf)
        {
            // Aplica la rotaci�n.
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }
}
