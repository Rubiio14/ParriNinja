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
    GameObject vida1_r, vida2_r, vida3_r;
    [SerializeField]
    GameObject vida1_b, vida2_b, vida3_b;

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
            UI_GamePlay.instance.CrossRed(vida3, vida3_b, vida3_r);
        }
        if (health == 1)
        {
            UI_GamePlay.instance.CrossRed(vida2, vida2_b, vida2_r);
        }

        if (health <= 0)
        {
            UI_GamePlay.instance.CrossRed(vida1, vida1_b, vida1_r);
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
