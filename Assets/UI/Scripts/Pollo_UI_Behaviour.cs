using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollo_UI_Behaviour : MonoBehaviour
{
    [SerializeField]
    GameObject polloEntero, polloParte1, polloParte2;

    Transform p_polloEntero, p_polloParte1, p_polloParte2;

    Rigidbody rb_polloEntero, rb_parte1, rb_parte2;

    public static Pollo_UI_Behaviour instance;

    Rigidbody rbPollo;

    BoxCollider m_PolloCollider;

    // Variables para almacenar el estado inicial
    Vector3 initialPositionPolloEntero, initialPositionParte1, initialPositionParte2;
    Quaternion initialRotationPolloEntero, initialRotationParte1, initialRotationParte2;
    bool initialActivePolloEntero, initialActiveParte1, initialActiveParte2;
    bool initialKinematicPolloEntero, initialKinematicParte1, initialKinematicParte2;
    bool initialUseGravityPolloEntero, initialUseGravityParte1, initialUseGravityParte2;

    private void Awake()
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

    void Start()
    {
        // Comprobaciones de null
        if (polloEntero == null || polloParte1 == null || polloParte2 == null)
        {
            Debug.LogError("Uno o m�s GameObjects no est�n asignados en el Inspector.");
            return;
        }

        // Almacenar el estado inicial
        initialPositionPolloEntero = polloEntero.transform.position;
        initialPositionParte1 = polloParte1.transform.position;
        initialPositionParte2 = polloParte2.transform.position;

        initialRotationPolloEntero = polloEntero.transform.rotation;
        initialRotationParte1 = polloParte1.transform.rotation;
        initialRotationParte2 = polloParte2.transform.rotation;

        initialActivePolloEntero = polloEntero.activeSelf;
        initialActiveParte1 = polloParte1.activeSelf;
        initialActiveParte2 = polloParte2.activeSelf;

        rb_polloEntero = polloEntero.GetComponent<Rigidbody>();
        rb_parte1 = polloParte1.GetComponent<Rigidbody>();
        rb_parte2 = polloParte2.GetComponent<Rigidbody>();

        if (rb_polloEntero == null || rb_parte1 == null || rb_parte2 == null)
        {
            Debug.LogError("Uno o m�s Rigidbodies no est�n asignados correctamente.");
            return;
        }

        initialKinematicPolloEntero = rb_polloEntero.isKinematic;
        initialKinematicParte1 = rb_parte1.isKinematic;
        initialKinematicParte2 = rb_parte2.isKinematic;

        initialUseGravityPolloEntero = rb_polloEntero.useGravity;
        initialUseGravityParte1 = rb_parte1.useGravity;
        initialUseGravityParte2 = rb_parte2.useGravity;

        p_polloEntero = polloEntero.transform;
        print(p_polloEntero.position);
        p_polloParte1 = polloParte1.transform;
        p_polloParte2 = polloParte2.transform;

        m_PolloCollider = GetComponent<BoxCollider>();
        rbPollo = GetComponent<Rigidbody>();

        if (m_PolloCollider == null || rbPollo == null)
        {
            Debug.LogError("BoxCollider o Rigidbody en el GameObject actual no est�n asignados correctamente.");
            return;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Piezas();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetToFactorySettings();
        }
    }

    public void Piezas()
    {
        polloEntero.SetActive(false);
        rbPollo.isKinematic = false;
        rbPollo.useGravity = true;
        m_PolloCollider.enabled = false;

        rbPollo.isKinematic = false;
        rbPollo.useGravity = true;

        polloParte1.SetActive(true);
        polloParte2.SetActive(true);

        polloParte1.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, 0), ForceMode.Impulse);
        polloParte2.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, 0), ForceMode.Impulse);
    }

    public void ResetToFactorySettings()
    {
        gameObject.transform.position = initialPositionPolloEntero;
        polloEntero.transform.position = initialPositionPolloEntero;
        polloEntero.transform.rotation = initialRotationPolloEntero;
        polloParte1.transform.position = initialPositionParte1;
        polloParte1.transform.rotation = initialRotationParte1;
        polloParte2.transform.position = initialPositionParte2;
        polloParte2.transform.rotation = initialRotationParte2;

        polloEntero.SetActive(initialActivePolloEntero);
        polloParte1.SetActive(initialActiveParte1);
        polloParte2.SetActive(initialActiveParte2);

        rb_polloEntero.isKinematic = initialKinematicPolloEntero;
        rb_parte1.isKinematic = initialKinematicParte1;
        rb_parte2.isKinematic = initialKinematicParte2;

        rb_polloEntero.useGravity = initialUseGravityPolloEntero;
        rb_parte1.useGravity = initialUseGravityParte1;
        rb_parte2.useGravity = initialUseGravityParte2;

        rb_polloEntero.velocity = Vector3.zero;
        rb_parte1.velocity = Vector3.zero;
        rb_parte2.velocity = Vector3.zero;

        rb_polloEntero.angularVelocity = Vector3.zero;
        rb_parte1.angularVelocity = Vector3.zero;
        rb_parte2.angularVelocity = Vector3.zero;

        m_PolloCollider.enabled = true;
        rbPollo.isKinematic = true;
        rbPollo.useGravity = false;
    }
}
