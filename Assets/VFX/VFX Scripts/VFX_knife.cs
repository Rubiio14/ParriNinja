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
        // Detectar cuando se hace clic con el rat�n
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }

    
        
            Vector3 finalMousePosition = Input.mousePosition;
            RotateImage(initialMousePosition, finalMousePosition);
        
    }

    void RotateImage(Vector3 start, Vector3 end)
    {
        // Calcular el vector de direcci�n del movimiento del rat�n
        Vector3 direction = end - start;

        // Calcular el �ngulo de rotaci�n en base al vector de direcci�n
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar la rotaci�n a la imagen
        imageToRotate.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
