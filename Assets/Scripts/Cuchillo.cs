using System.Collections;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    bool m_Pulsado = false;
    Vector3 m_LastMousePosition;
    public float m_MouseMoveOffset = 5f;
    public AudioSource m_CutSound;
    public AudioSource m_BoneSound;

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

            if (hit.collider.CompareTag("Carne"))
            {
                CarneBehaviour carne = hit.collider.GetComponent<CarneBehaviour>();
                if (carne != null)
                {
                    carne.Cortado();
                    m_CutSound.Play();

                }
            }
            else if (hit.collider.CompareTag("Hueso"))
            {
                HuesoBehaviour hueso = hit.collider.GetComponent<HuesoBehaviour>();
                if (hueso != null)
                {
                    hueso.Hueso();
                    m_CutSound.Play();
                    m_BoneSound.Play();
                    Health_Manager.instance.Defeat();

                }
            }
            else if (hit.collider.CompareTag("Limon"))
            {
                Lemon_Behaviour limon = hit.collider.GetComponent<Lemon_Behaviour>();
                if (limon != null)
                {
                    limon.Cortado();
                    m_CutSound.Play();
                }
            }

            //Menus
            else if (hit.collider.CompareTag("Limon_UI"))
            {
                m_CutSound.Play();
                InitialMenu.instance.SettingsButton();
                LimonUIBehaviour.instance.Piezas();
                Pollo_UI_Behaviour.instance.gameObject.SetActive(false);
            }

            else if (hit.collider.CompareTag("Pollo_UI"))
            {
                m_CutSound.Play();
                InitialMenu.instance.GoToLevelMenu();
                Pollo_UI_Behaviour.instance.Piezas();
                LimonUIBehaviour.instance.gameObject.SetActive(false);
                Hueso_UI_Levels.instance.HuesoInstanciado();
            }
            else if (hit.collider.CompareTag("Hueso_UI")) 
            {
                SettingsScreen.instance.BackToInitialMenu();
                LimonUIBehaviour.instance.gameObject.SetActive(true);
                Pollo_UI_Behaviour.instance.gameObject.SetActive(true);
                LimonUIBehaviour.instance.ResetToFactorySettings();
                Pollo_UI_Behaviour.instance.ResetToFactorySettings();
                Hueso_UI.instance.HuesoCortado();
            }
            else if (hit.collider.CompareTag("Hueso_UI_Levels"))
            {
                MenuLevels.instance.MenuLevelToInitial();
                LimonUIBehaviour.instance.gameObject.SetActive(true);
                Pollo_UI_Behaviour.instance.gameObject.SetActive(true);
                LimonUIBehaviour.instance.ResetToFactorySettings();
                Pollo_UI_Behaviour.instance.ResetToFactorySettings();
                Hueso_UI_Levels.instance.HuesoCortado();
            }
        }
    }
}