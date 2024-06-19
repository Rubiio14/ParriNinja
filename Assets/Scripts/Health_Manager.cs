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
    GameObject derrotaSound, backgroundMusic, lanzadores, derrotaScreen;

    [SerializeField]
    CanvasGroup derrotaCanvasGroup;

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

    void Update()
    {
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

            Defeat();
            RythmManager.instance.StopTime();




        }
    }

    public void RestaVida()
    {
        health--;
    }
    public void Defeat()
    {
        derrotaSound.SetActive(true);
        backgroundMusic.SetActive(false);
        lanzadores.SetActive(false);
        //pantalla Derrota
        derrotaScreen.SetActive(true);
        LeanTween.alphaCanvas(derrotaCanvasGroup, 1, 0.5f);
    }
}
