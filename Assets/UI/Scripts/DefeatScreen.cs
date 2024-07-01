using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatScreen : MonoBehaviour
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
}
