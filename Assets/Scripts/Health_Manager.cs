using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    public static Health_Manager instance;
    public float health = 3;
    [SerializeField]
    GameObject vida1, vida2, vida3;

    [SerializeField]
    GameObject lanzadores, derrotaScreen;

    public AudioSource m_DefeatSound;

    [SerializeField]
    CanvasGroup derrotaCanvasGroup;
    public bool IsDefeat = false;
    public void Awake()
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
        if (health >= 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }
    }

    public void RestaVida()
    {
        health--;
        if (health == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        if (health == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }

        if (health <= 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
            if (IsDefeat == false)
            {
                Defeat();
            }  
        }  
    }

    public void Defeat()
    {
        IsDefeat = true;
        m_DefeatSound.Play();
        Debug.Log("Defeat method called.");
        if (m_DefeatSound != null)
        {
            m_DefeatSound.Play();
            Debug.Log("Playing defeat sound.");
        }
        else
        {
            Debug.LogError("AudioSource is not assigned in the inspector.");
        }
        lanzadores.SetActive(false);

        //pantalla Derrota
        derrotaScreen.SetActive(true);
        LeanTween.alphaCanvas(derrotaCanvasGroup, 1, 0.5f);
        RythmManager.instance.StopTime();
    }
}
