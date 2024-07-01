using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Next_Level()
    {
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No quedan mas niveles");
        }
        
    }
}
