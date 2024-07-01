using System.Collections;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    bool m_Pulsado = false;
    Vector3 m_LastMousePosition;
    public float m_MouseMoveOffset = 5f;
    public AudioSource m_CutSound;
    public AudioSource m_BoneSound;
    public AudioSource m_MeatCutSound;
    public static Cuchillo instance;

    /*public bool initialMenuActive;
    public bool settingsActive;
    public bool menuLevelActive;*/

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
    void Update()
    {
        
        DetectMouseClick();

        if (m_Pulsado && MouseMoved())
        {
            PerformRaycast();
        }
    }

    void DetectMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Pulsado = true;
            m_LastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_Pulsado = false;
        }
    }

    bool MouseMoved()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        if (Vector3.Distance(currentMousePosition, m_LastMousePosition) >= m_MouseMoveOffset)
        {
            m_LastMousePosition = currentMousePosition;
            return true;
        }
        return false;
    }

    void PerformRaycast()
    {
        Vector3 m_MousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(m_MousePosition);
        RaycastHit hit;
        float rayLength = 800f;

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        // Asegurarse de que el raycast detecte los triggers
        if (Physics.Raycast(ray, out hit, rayLength, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            
            //Todo objeto con interfaz SlizableItem se puede cortar
            hit.collider.GetComponent<SlizableItem>().Slice();
        }
    }
}