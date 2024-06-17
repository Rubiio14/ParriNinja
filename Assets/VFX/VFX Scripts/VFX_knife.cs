using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VFX_knife : MonoBehaviour
{
    public RawImage imageToRotate; // La imagen que vamos a rotar

    private Vector3 initialMousePosition;

    void Update()
    {
        // Detectar cuando se hace clic con el ratón
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }

    
        
            Vector3 finalMousePosition = Input.mousePosition;
            RotateImage(initialMousePosition, finalMousePosition);
        
    }

    void RotateImage(Vector3 start, Vector3 end)
    {
        // Calcular el vector de dirección del movimiento del ratón
        Vector3 direction = end - start;

        // Calcular el ángulo de rotación en base al vector de dirección
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar la rotación a la imagen
        imageToRotate.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
