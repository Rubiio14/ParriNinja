using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Win;
    [SerializeField] GameObject GameOver;

    [SerializeField] GameObject PanelVictory;
    [SerializeField] GameObject PanelGameOver;
    [SerializeField] GameObject RingNext;
    [SerializeField] GameObject RingQuit;
    [SerializeField] GameObject RingTryAgain;
    [SerializeField] GameObject ProvisionalButtonQuit;
    [SerializeField] GameObject ProvisionalButtonNext;
    [SerializeField] GameObject ProvisionalButtonTryAgain;
    [SerializeField] CanvasGroup FondoMiddle;
    [SerializeField] CanvasGroup FondoOn;

    public static VictoryScreen instance;
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
       
    }
    public void VictoryGameOverScreenCome(GameObject WinOrGameOver)
    {
              
        LeanTween.scale(RingQuit, new Vector3(3,3,3), 1f);     
        LeanTween.scale(ProvisionalButtonQuit, Vector3.one, 1f);

        if (WinOrGameOver == Win)
        {
            LeanTween.scale(RingNext, Vector3.one, 1f);
            LeanTween.scale(ProvisionalButtonNext, Vector3.one, 1f);
            LeanTween.moveY(PanelVictory, 80, 1);
        }
        else if(WinOrGameOver == GameOver)
        {
            LeanTween.scale(RingTryAgain, new Vector3(3, 3, 3), 1f);
            LeanTween.scale(ProvisionalButtonTryAgain, Vector3.one, 1f);
            LeanTween.moveY(PanelGameOver, 80, 1);
        }

    }

    public void VictoryGameOverScreenGone()
    {
        LeanTween.moveY(PanelVictory, 1000, 1);
        LeanTween.moveY(PanelGameOver, 1000, 1);
        LeanTween.scale(RingNext, Vector3.zero, 1f);
        LeanTween.scale(RingQuit, Vector3.zero, 1f);
        LeanTween.scale(ProvisionalButtonNext, Vector3.zero, 1f);
        LeanTween.scale(ProvisionalButtonQuit, Vector3.zero, 1f);
        LeanTween.scale(RingTryAgain, Vector3.zero, 1);
        LeanTween.scale(ProvisionalButtonTryAgain, Vector3.zero, 1f);


    }
    public void MainButton()
    {
        VictoryGameOverScreenGone();
        LeanTween.scale(ProvisionalButtonQuit, Vector3.zero, 1f).setOnComplete(() =>
        {
         SceneManager.LoadScene(0);
        });
       
    }

    public void RetryButton()
    {
        VictoryGameOverScreenGone();
        LeanTween.scale(ProvisionalButtonQuit, Vector3.zero, 1f).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(FondoMiddle, 1, 1f).setOnComplete(() =>
            {
                LeanTween.alphaCanvas(FondoOn, 1, 1f).setOnComplete(() =>
                {
                     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                });
            });
        });
       
    }

    public void NoMoreLevels()
    {
        LeanTween.scale(RingNext, Vector3.zero, 1f);
        LeanTween.scale(ProvisionalButtonNext, Vector3.zero, 1f).setOnComplete(() =>
        {
            LeanTween.moveX(RingQuit, 0, 1f);
            LeanTween.moveX(ProvisionalButtonQuit, 0, 1f);

        });


    }
    public void Next_Level()
    {
      
            
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {   VictoryGameOverScreenGone();
            LeanTween.scale(ProvisionalButtonQuit, Vector3.zero, 1f).setOnComplete(() =>
           {
               LeanTween.alphaCanvas(FondoMiddle, 1, 1f).setOnComplete(() =>
               {
                   LeanTween.alphaCanvas(FondoOn, 1,1f).setOnComplete(() =>
                   {
                       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                   });             
               });
           });
        }
        else
        {
            NoMoreLevels();
            Debug.Log("No quedan mas niveles");
        }  
       
        
        
    }
}
