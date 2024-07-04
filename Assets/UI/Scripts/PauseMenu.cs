using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseMenuActive;
    [SerializeField]
    GameObject pauseScreen;
   // [SerializeField] GameObject ;

    public static PauseMenu instance;

    [SerializeField] CanvasGroup Fondo;
    [SerializeField] GameObject PanelPause;


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

    void Update()
    {

       /* if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuActive == true)
        {
            pauseMenuActive = false;
        }

        if(pauseMenuActive) 
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }*/
    }
    public void PauseScreenCome()
    {
       // pauseMenuActive = true;
        LeanTween.alphaCanvas(Fondo, 1, 1).setIgnoreTimeScale(true); 
        LeanTween.moveLocalY(PanelPause, 0, 1).setIgnoreTimeScale(true);


    }
    public void ContinueButton()
    {
        LeanTween.alphaCanvas(Fondo, 0, 1).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(PanelPause, 385, 1).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            
            UI_GamePlay.instance.PauseDesactive();
        });
       
    }
    public void MainButton()
    {  
        UI_GamePlay.instance.TrancisionFondo();
        UI_GamePlay.instance.UIGamePlayGone();
        LeanTween.alphaCanvas(Fondo, 0, 1).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(PanelPause, 385, 1).setIgnoreTimeScale(true).setOnComplete(() =>
        {
           
             SceneManager.LoadScene(0);
             Time.timeScale = 1.0f;

        });
        
    }
    public void ResetGame()
    {   
        UI_GamePlay.instance.UIGamePlayGone();
        LeanTween.alphaCanvas(Fondo, 0, 1).setIgnoreTimeScale(true);
        LeanTween.moveLocalY(PanelPause, 385, 1).setIgnoreTimeScale(true).setOnComplete(() =>
        {
         string currentSceneName = SceneManager.GetActiveScene().name;       
         SceneManager.LoadScene(currentSceneName);
         Time.timeScale = 1.0f;
           
        });
       
        
    }
}
