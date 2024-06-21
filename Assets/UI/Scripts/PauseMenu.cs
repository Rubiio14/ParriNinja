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

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuActive == true)
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
        }
    }
    public void PauseButton()
    {
        pauseMenuActive = true;
        Time.timeScale = 0.0f;
    }
    public void ContinueButton()
    {
        pauseMenuActive = false;
        Time.timeScale = 1.0f;
    }
    public void MainButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
