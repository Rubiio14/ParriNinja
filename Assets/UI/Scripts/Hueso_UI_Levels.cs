using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hueso_UI_Levels : MonoBehaviour
{
    public static Hueso_UI_Levels instance;

    [SerializeField]
    GameObject HuesoUI; 
        
    [SerializeField]
    GameObject HuesoRotoVFX;

    //Rigidbody HuesoRb;
    CapsuleCollider HuesoCollider;

    [SerializeField]
    AudioSource HuesoUIAudio;

    Vector3 initialPositionHueso;

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
    private void Start()
    {

        //HuesoRb = GetComponent<Rigidbody>();
        HuesoCollider = GetComponent<CapsuleCollider>();
        initialPositionHueso = gameObject.transform.position;

        HuesoUI.SetActive(false);
        //HuesoRb.isKinematic = true;
        //HuesoRb.useGravity = false;
        HuesoCollider.enabled = false;
        HuesoRotoVFX.SetActive(false);

    }


    public void HuesoInstanciado()
    {
        gameObject.transform.position = initialPositionHueso;
        HuesoUI.SetActive(true);
        //HuesoRb.isKinematic = true;
        //HuesoRb.useGravity = false;
        HuesoCollider.enabled = true;
        HuesoRotoVFX.SetActive(false);


    }

    public void HuesoCortado()
    {
        HuesoUI.SetActive(false);
        //HuesoRb.isKinematic = false;
        //HuesoRb.useGravity = true;
        HuesoCollider.enabled = false;

        HuesoUIAudio.Play();
        HuesoRotoVFX.SetActive(true);

    }

}
