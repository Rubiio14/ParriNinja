using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 1;
      //  GetComponent<Rigidbody>().AddForce(Vector3.up * -500f, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 50f, ForceMode.Impulse);

        }
    }
}
