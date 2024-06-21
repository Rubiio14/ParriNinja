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
        if (other.gameObject.CompareTag("Carne") && hp[0]==true)
        {
            hp[0].transform.position = other.transform.position;
            BrokenHeart();
            print("cae");
            other.gameObject.SetActive(false);
            Health_Manager.instance.RestaVida();
        }
        else if (other.gameObject.CompareTag("Carne") && hp[1] == true)
        {
            hp[1].transform.position = other.transform.position;
            BrokenHeart1();
            other.gameObject.SetActive(false);
            Health_Manager.instance.RestaVida();
        }
        else if (other.gameObject.CompareTag("Carne") && hp[2] == true)
        {
            hp[2].transform.position = other.transform.position;
            BrokenHeart2();
            other.gameObject.SetActive(false);
            Health_Manager.instance.RestaVida();
        }
    }

    public void BrokenHeart()
    {
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
