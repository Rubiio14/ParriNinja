using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CarneUIBehaviour : MonoBehaviour
{
  
    [SerializeField] MenuLevels menuLevels;
    [SerializeField] SettingsScreen settingsScreen;

    [SerializeField]
    GameObject limonEntero, limonParte1, limonParte2, limonParte3, limonParte4;

    Transform p_limonEntero, p_limonParte1, p_limonParte2, p_limonParte3, p_limonParte4;

    Rigidbody rb_limonentero, rb_parte1, rb_parte2, rb_parte3, rb_parte4;

    public static CarneUIBehaviour instance;

    Rigidbody rbLimon;

   

    BoxCollider m_LimonCollider;
    // Start is called before the first frame update

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
        p_limonEntero = limonEntero.transform;
        p_limonParte1 = limonParte1.transform;
        p_limonParte2 = limonParte2.transform;
        p_limonParte3 = limonParte3.transform;
        p_limonParte4 = limonParte4.transform;

        m_LimonCollider = GetComponent<BoxCollider>();
        rbLimon = GetComponent<Rigidbody>();

        rb_limonentero = limonEntero.GetComponent<Rigidbody>();
        rb_parte1 = limonParte1.GetComponent<Rigidbody>();
        rb_parte2 = limonParte2.GetComponent<Rigidbody>();
        rb_parte3 = limonParte3.GetComponent<Rigidbody>();
        rb_parte4 = limonParte4.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            ResetLimonUI(); 
        }
    }
    public void Piezas()
    {
        limonEntero.SetActive(false);
        m_LimonCollider.enabled = false;
        //RythmManager.instance.m_IsLemonActive = false;

      
        
        

        rbLimon.isKinematic = false;
        rbLimon.useGravity = true;
      

        limonParte1.SetActive(true);
        limonParte2.SetActive(true);
        limonParte3.SetActive(true);
        limonParte4.SetActive(true);

        limonParte1.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 6, 0), ForceMode.Impulse);
        limonParte2.GetComponent<Rigidbody>().AddForce(new Vector3(3, 6, 0), ForceMode.Impulse);
        limonParte3.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 10, 0), ForceMode.Impulse);
        limonParte4.GetComponent<Rigidbody>().AddForce(new Vector3(3, 10, 0), ForceMode.Impulse);
    }

    public void ResetLimonUI()
    {
        print("holareset");
        //Objetos
        limonEntero.SetActive(true);
        limonParte1.SetActive(false);
        limonParte2.SetActive(false);
        limonParte3.SetActive(false);
        limonParte4.SetActive(false);
        //Colliders
        m_LimonCollider.enabled = true;
        rbLimon.useGravity = false;
        //Transformaciones
        limonEntero.transform.position = p_limonEntero.transform.position;
        limonParte1.transform.position = p_limonParte1.transform.position;
        limonParte2.transform.position = p_limonParte2.transform.position;
        limonParte3.transform.position = p_limonParte3.transform.position;
        limonParte4.transform.position = p_limonParte4.transform.position;

        //limonParte1.GetComponent<Rigidbody>().re
        ResetRigidbody(this.gameObject.GetComponent<Rigidbody>());
        ResetRigidbody(limonParte1.GetComponent<Rigidbody>());
        ResetRigidbody(limonParte2.GetComponent<Rigidbody>());
        ResetRigidbody(limonParte3.GetComponent<Rigidbody>());
        ResetRigidbody(limonParte4.GetComponent<Rigidbody>());
    }

    private void ResetRigidbody(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep(); // Opcional: Para asegurarse de que el Rigidbody está completamente en reposo
    }
}

