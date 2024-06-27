using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMovement : MonoBehaviour
{
    [SerializeField] GameObject Credits;
    public float m_UpSpeed;
    Vector3 m_InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
       // Credits.transform.position = m_InitialPosition;
       m_InitialPosition.y = Credits.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
           
            Credits.transform.position += Vector3.up * m_UpSpeed * Time.deltaTime;
            if (Credits.transform.position.y > 640)
            {
                Credits.transform.position = new Vector3 (Credits.transform.position.x, m_InitialPosition.y, Credits.transform.position.z);
            }
        }
    }
    
}
