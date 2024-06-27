using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bloqueos_Ui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsSaved();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefsReset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetInt("IsLvL2", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerPrefs.SetInt("IsLvL3", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayerPrefs.SetInt("IsLvL4", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayerPrefs.SetInt("IsLvL5", 1);
        }

    }
    public void PlayerPrefsReset()
    {       
        PlayerPrefs.SetInt("IsLvL2", 0);
        PlayerPrefs.SetInt("IsLvL3", 0);
        PlayerPrefs.SetInt("IsLvL4", 0);
        PlayerPrefs.SetInt("IsLvL5", 0);
    }
    public void PlayerPrefsSaved()
    {
        PlayerPrefs.SetInt("IsLvL2", PlayerPrefs.GetInt("IsLvL2"));
        PlayerPrefs.SetInt("IsLvL3", PlayerPrefs.GetInt("IsLvL3"));
        PlayerPrefs.SetInt("IsLvL4", PlayerPrefs.GetInt("IsLvL4"));
        PlayerPrefs.SetInt("IsLvL5", PlayerPrefs.GetInt("IsLvL5"));
    }
}
