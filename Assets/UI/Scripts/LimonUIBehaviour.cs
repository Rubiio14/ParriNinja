using UnityEngine;

public class LimonUIBehaviour : MonoBehaviour
{

    [SerializeField]
    GameObject limonEntero, limonParte1, limonParte2, limonParte3, limonParte4;

    Transform p_limonEntero, p_limonParte1, p_limonParte2, p_limonParte3, p_limonParte4;

    Rigidbody rb_limonentero, rb_parte1, rb_parte2, rb_parte3, rb_parte4;

    public static LimonUIBehaviour instance;

    Rigidbody rbLimon;

    BoxCollider m_LimonCollider;

    // Variables para almacenar el estado inicial
    Vector3 initialPositionLimonEntero, initialPositionParte1, initialPositionParte2, initialPositionParte3, initialPositionParte4;
    Quaternion initialRotationLimonEntero, initialRotationParte1, initialRotationParte2, initialRotationParte3, initialRotationParte4;
    bool initialActiveLimonEntero, initialActiveParte1, initialActiveParte2, initialActiveParte3, initialActiveParte4;
    bool initialKinematicLimonEntero, initialKinematicParte1, initialKinematicParte2, initialKinematicParte3, initialKinematicParte4;
    bool initialUseGravityLimonEntero, initialUseGravityParte1, initialUseGravityParte2, initialUseGravityParte3, initialUseGravityParte4;

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
        if (limonEntero == null || limonParte1 == null || limonParte2 == null || limonParte3 == null || limonParte4 == null)
        {
            Debug.LogError("Uno o más GameObjects no están asignados en el Inspector.");
            return;
        }

        // Almacenar el estado inicial
        initialPositionLimonEntero = limonEntero.transform.position;
        initialPositionParte1 = limonParte1.transform.position;
        initialPositionParte2 = limonParte2.transform.position;
        initialPositionParte3 = limonParte3.transform.position;
        initialPositionParte4 = limonParte4.transform.position;

        initialRotationLimonEntero = limonEntero.transform.rotation;
        initialRotationParte1 = limonParte1.transform.rotation;
        initialRotationParte2 = limonParte2.transform.rotation;
        initialRotationParte3 = limonParte3.transform.rotation;
        initialRotationParte4 = limonParte4.transform.rotation;

        initialActiveLimonEntero = limonEntero.activeSelf;
        initialActiveParte1 = limonParte1.activeSelf;
        initialActiveParte2 = limonParte2.activeSelf;
        initialActiveParte3 = limonParte3.activeSelf;
        initialActiveParte4 = limonParte4.activeSelf;

        rb_limonentero = limonEntero.GetComponent<Rigidbody>();
        rb_parte1 = limonParte1.GetComponent<Rigidbody>();
        rb_parte2 = limonParte2.GetComponent<Rigidbody>();
        rb_parte3 = limonParte3.GetComponent<Rigidbody>();
        rb_parte4 = limonParte4.GetComponent<Rigidbody>();

        if (rb_limonentero == null || rb_parte1 == null || rb_parte2 == null || rb_parte3 == null || rb_parte4 == null)
        {
            Debug.LogError("Uno o más Rigidbodies no están asignados correctamente.");
            return;
        }

        initialKinematicLimonEntero = rb_limonentero.isKinematic;
        initialKinematicParte1 = rb_parte1.isKinematic;
        initialKinematicParte2 = rb_parte2.isKinematic;
        initialKinematicParte3 = rb_parte3.isKinematic;
        initialKinematicParte4 = rb_parte4.isKinematic;

        initialUseGravityLimonEntero = rb_limonentero.useGravity;
        initialUseGravityParte1 = rb_parte1.useGravity;
        initialUseGravityParte2 = rb_parte2.useGravity;
        initialUseGravityParte3 = rb_parte3.useGravity;
        initialUseGravityParte4 = rb_parte4.useGravity;

        p_limonEntero = limonEntero.transform;
        print(p_limonEntero.position);
        p_limonParte1 = limonParte1.transform;
        p_limonParte2 = limonParte2.transform;
        p_limonParte3 = limonParte3.transform;
        p_limonParte4 = limonParte4.transform;

        m_LimonCollider = GetComponent<BoxCollider>();
        rbLimon = GetComponent<Rigidbody>();

        if (m_LimonCollider == null || rbLimon == null)
        {
            Debug.LogError("BoxCollider o Rigidbody en el GameObject actual no están asignados correctamente.");
            return;
        }

        // Asegúrate de que la simulación no esté en cámara lenta
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetToFactorySettings();
        }
    }

    public void Piezas()
    {
        limonEntero.SetActive(false);
        m_LimonCollider.enabled = false;

        limonParte1.SetActive(true);
        limonParte2.SetActive(true);
        limonParte3.SetActive(true);
        limonParte4.SetActive(true);

        limonParte1.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, 0), ForceMode.Impulse);
        limonParte2.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, 0), ForceMode.Impulse);
        limonParte3.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 10, 0), ForceMode.Impulse);
        limonParte4.GetComponent<Rigidbody>().AddForce(new Vector3(3, 10, 0), ForceMode.Impulse);

        // Asegúrate de que la gravedad esté habilitada y que las masas sean apropiadas
        rb_parte1.useGravity = true;
        rb_parte2.useGravity = true;
        rb_parte3.useGravity = true;
        rb_parte4.useGravity = true;

        rb_parte1.mass = 1f;
        rb_parte2.mass = 1f;
        rb_parte3.mass = 1f;
        rb_parte4.mass = 1f;

        rb_parte1.drag = 0f;
        rb_parte1.angularDrag = 0.05f;
        rb_parte2.drag = 0f;
        rb_parte2.angularDrag = 0.05f;
        rb_parte3.drag = 0f;
        rb_parte3.angularDrag = 0.05f;
        rb_parte4.drag = 0f;
        rb_parte4.angularDrag = 0.05f;
    }

    public void ResetToFactorySettings()
    {
        gameObject.transform.position = initialPositionLimonEntero;
        limonEntero.transform.position = initialPositionLimonEntero;
        limonEntero.transform.rotation = initialRotationLimonEntero;
        limonParte1.transform.position = initialPositionParte1;
        limonParte1.transform.rotation = initialRotationParte1;
        limonParte2.transform.position = initialPositionParte2;
        limonParte2.transform.rotation = initialRotationParte2;
        limonParte3.transform.position = initialPositionParte3;
        limonParte3.transform.rotation = initialRotationParte3;
        limonParte4.transform.position = initialPositionParte4;
        limonParte4.transform.rotation = initialRotationParte4;

        limonEntero.SetActive(initialActiveLimonEntero);
        limonParte1.SetActive(initialActiveParte1);
        limonParte2.SetActive(initialActiveParte2);
        limonParte3.SetActive(initialActiveParte3);
        limonParte4.SetActive(initialActiveParte4);

        rb_limonentero.useGravity = initialUseGravityLimonEntero;
        rb_parte1.useGravity = initialUseGravityParte1;
        rb_parte2.useGravity = initialUseGravityParte2;
        rb_parte3.useGravity = initialUseGravityParte3;
        rb_parte4.useGravity = initialUseGravityParte4;

        rb_limonentero.velocity = Vector3.zero;
        rb_parte1.velocity = Vector3.zero;
        rb_parte2.velocity = Vector3.zero;
        rb_parte3.velocity = Vector3.zero;
        rb_parte4.velocity = Vector3.zero;

        rb_limonentero.angularVelocity = Vector3.zero;
        rb_parte1.angularVelocity = Vector3.zero;
        rb_parte2.angularVelocity = Vector3.zero;
        rb_parte3.angularVelocity = Vector3.zero;
        rb_parte4.angularVelocity = Vector3.zero;

        m_LimonCollider.enabled = true;
    }
}
