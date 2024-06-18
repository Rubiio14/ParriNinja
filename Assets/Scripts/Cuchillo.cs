using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    bool m_Pulsado = false;

    void Update()
    {
        // Pulsa el Click Izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            m_Pulsado = true;
        }
        // Suelta el Click Izquierdo
        if (Input.GetMouseButtonUp(0))
        {
            m_Pulsado = false;
        }

        if (m_Pulsado)
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            float rayLength = 100f;

            
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            //El Querty es para que el Raycast detecte los Trigger
            if (Physics.Raycast(ray, out hit, rayLength, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
                if (hit.collider.CompareTag("Carne"))
                {
                    hit.collider.GetComponent<CarneBehaviour>().Cortado();
                    Score_Manager.instance.RestaCarne();
                }
                if (hit.collider.CompareTag("Hueso"))
                {
                    hit.collider.GetComponent<HuesoBehaviour>().Hueso();
                    Health_Manager.instance.RestaVida();
                }
                if (hit.collider.CompareTag("Limon"))
                {
                    hit.collider.GetComponent<Lemon_Behaviour>().Cortado();
                    Score_Manager.instance.RestaCarne();
                }


            }
        }
    }
}
