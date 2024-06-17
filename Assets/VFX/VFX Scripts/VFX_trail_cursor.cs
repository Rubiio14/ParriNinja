using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_trail_cursor : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        trail = GetComponent<TrailRenderer>();
        trail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trail.emitting = true; 
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; 
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            trail.emitting = false;
        }
    }
}
