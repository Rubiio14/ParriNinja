using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Panel;
    [SerializeField] GameObject RingNext;
    [SerializeField] GameObject RingQuit;
    [SerializeField] GameObject ProvisionalButtonQuit;
    [SerializeField] GameObject ProvisionalButtonNext;
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
    public void VictoryScreenCome()
    {
        LeanTween.moveY(Panel, 80, 1);
        LeanTween.scale(RingNext, Vector3.one, 1f);
        LeanTween.scale(RingQuit, new Vector3(3,3,3), 1f);     
        LeanTween.scale( ProvisionalButtonNext, Vector3.one, 1f);
        LeanTween.scale(ProvisionalButtonQuit, Vector3.one, 1f);

    }

    public void VictoryScreenGone()
    {
        LeanTween.moveY(Panel, 1000, 1);
        LeanTween.scale(RingNext, Vector3.zero, 1f);
        LeanTween.scale(RingQuit, Vector3.zero, 1f);
        LeanTween.scale(ProvisionalButtonNext, Vector3.zero, 1f);
        LeanTween.scale(ProvisionalButtonQuit, Vector3.zero, 1f);
    }
    public void MainButton()
    {
        VictoryScreenGone();
        LeanTween.scale(ProvisionalButtonQuit, Vector3.zero, 1f).setOnComplete(() =>
        {
         SceneManager.LoadScene(0);
        });
       
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Next_Level()
    {
      
            
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {   VictoryScreenGone();
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
            Debug.Log("No quedan mas niveles");
        }  
       
        
        
    }
}
