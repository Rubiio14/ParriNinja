using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_HP : MonoBehaviour
{
    [SerializeField]
    GameObject[] hp;

    public float hpTimer = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carne") && hp[0] == true || other.gameObject.CompareTag("Limon") && hp[0] == true || other.gameObject.CompareTag("Costillar") && hp[0]==true)
        {
            hp[0].transform.position = other.transform.position;
            BrokenHeart();
            
            Destroy(other.gameObject);
            Health_Manager.instance.RestaVida();
        }
        else if (other.gameObject.CompareTag("Carne") && hp[1] == true || other.gameObject.CompareTag("Limon") && hp[1] == true || other.gameObject.CompareTag("Costillar") && hp[1] == true)
        {
            hp[1].transform.position = other.transform.position;
            BrokenHeart1();
            
            Destroy(other.gameObject);
            Health_Manager.instance.RestaVida();
        }
        else if (other.gameObject.CompareTag("Carne") && hp[2] == true || other.gameObject.CompareTag("Limon") && hp[2] == true || other.gameObject.CompareTag("Costillar") && hp[2] == true)
        {
            hp[2].transform.position = other.transform.position;
            BrokenHeart2();
            
            Destroy(other.gameObject);
            Health_Manager.instance.RestaVida();
        }
    }

    public void BrokenHeart()
    {
        hp[0].SetActive(true);

        ParticleSystem heart = hp[0].GetComponent<ParticleSystem>();

        heart.Play();
        hpTimer += Time.deltaTime;

        if (hpTimer >= 1.5f)
        {
            Destroy(hp[0]);
            hpTimer = 0;
        }
    }

    public void BrokenHeart1()
    {
        hp[1].SetActive(true);

        ParticleSystem heart1 = hp[1].GetComponent<ParticleSystem>();

        heart1.Play();
        hpTimer += Time.deltaTime;

        if (hpTimer >= 1.5f)
        {
            Destroy(hp[1]);
            hpTimer = 0;
        }
    }

    public void BrokenHeart2()
    {
        hp[2].SetActive(true);

        ParticleSystem heart2 = hp[2].GetComponent<ParticleSystem>();

        heart2.Play();
        hpTimer += Time.deltaTime;

        if (hpTimer >= 1.5f)
        {
            Destroy(hp[2]);
            hpTimer = 0;
        }
    }
}
