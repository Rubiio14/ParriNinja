using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Profiling;
using UnityEngine.SocialPlatforms.Impl;

public class UI_GamePlay : MonoBehaviour
{
    public float m_TimeOfReadyGo;
    public float m_TimeToWaitReadyGo;
    public static UI_GamePlay instance;


    // Pantalla de juego
    [SerializeField] GameObject crossBlue1;
    [SerializeField] GameObject crossBlue2;
    [SerializeField] GameObject crossBlue3;
    [SerializeField] GameObject crossRed1;
    [SerializeField] GameObject crossRed2;
    [SerializeField] GameObject crossRed3;
    [SerializeField] GameObject crossRed1Midle;
    [SerializeField] GameObject crossRed2Midle;
    [SerializeField] GameObject crossRed3Midle;
    [SerializeField] GameObject ready;
    [SerializeField] GameObject go;
    [SerializeField] GameObject Best;
   [SerializeField] CanvasGroup Ready;
    [SerializeField] CanvasGroup Go;
    [SerializeField] GameObject ImageSandia;
    [SerializeField] GameObject NumberPoints;
    [SerializeField] GameObject Record;

    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject WinLevel;

    [SerializeField] GameObject UI_LifeAndScore;

    /*// Pantalla de derrota
    [SerializeField] GameObject ButtonRetry;
    [SerializeField] GameObject ButtonQuit;
    [SerializeField] GameObject PanelGameOver;
    [SerializeField] GameObject Score;
    [SerializeField] GameObject NumberScore;*/


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
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
      
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes manejar las actualizaciones por frame
    }

    public void GameStart()
    {
        
        LeanTween.moveLocalY(ready, 0, m_TimeOfReadyGo);
        LeanTween.alphaCanvas(Ready, 1, m_TimeOfReadyGo).setOnComplete(() =>
        {
            LeanTween.moveLocalY(ready, 450, m_TimeOfReadyGo).setDelay(m_TimeToWaitReadyGo);
            LeanTween.alphaCanvas(Ready, 0, m_TimeOfReadyGo).setDelay(m_TimeToWaitReadyGo).setOnComplete(() =>
            {
                LeanTween.moveLocalY(UI_LifeAndScore, 0, 0.5f).setOnComplete(() =>
                {

            LeanTween.moveLocalY(go, 0, 0.2f);
            LeanTween.alphaCanvas(Go, 1, 0.2f).setOnComplete(() =>
            {
                LeanTween.moveLocalY (go, 450, 0.2f).setDelay(m_TimeToWaitReadyGo);
                LeanTween.alphaCanvas(Go, 0, 0.2f).setDelay(m_TimeToWaitReadyGo);
               
            });
            });
            });      
        });
        
    }

    public void AnimationPoints()
    {
        LeanTween.scale(ImageSandia, new Vector3(1.10f, 1.10f, 1), 0.15f).setOnComplete(() =>
        {
            LeanTween.scale(ImageSandia, Vector3.one, 0.15f);
        });
    }

    public void CrossRed(GameObject crossBlue, GameObject crossRed, GameObject crossMiddleRed)
    {
        crossBlue.SetActive(false); 
        crossRed.SetActive(true);

        LeanTween.scale(crossMiddleRed, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {

            LeanTween.scale(crossMiddleRed, Vector3.zero, 0.5f).setDelay(0.5f);
        });

       // LeanTween.moveLocal(crossRed, new Vector2(566.78f, 471), 1);
    }

  
    public void EndOfLevel(GameObject WinOrGameOver)
    {
        LeanTween.scale(WinOrGameOver, Vector3.one, 1).setOnComplete(() =>
        {
            LeanTween.scale(WinOrGameOver, Vector3.zero, 1).setDelay(1);
            LeanTween.moveLocalY(UI_LifeAndScore, 600, 0.5f).setDelay(1);

        });
    }
}
