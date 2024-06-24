using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bloqueos_Nivel : MonoBehaviour
{
    public int B_Nivel1 = 470;
    public int B_Nivel2 = 500;
    public int B_Nivel3 = 600;
    public int B_Nivel4 = 700;
    public int B_Nivel5 = 520;
    public int Score = 0;

    public static Bloqueos_Nivel instance;
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
    public int SelectorBloqueo()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (sceneIndex)
        {
            case 1:
                if (Score_Manager.instance.m_Score >= B_Nivel1)
                {
                    PlayerPrefs.SetInt("IsLvL2", 1);
                }
                return B_Nivel1;
            case 2:
                if (Score_Manager.instance.m_Score >= B_Nivel1)
                {
                    PlayerPrefs.SetInt("IsLvL3", 1);
                }
                return B_Nivel2;
            case 3:
                if (Score_Manager.instance.m_Score >= B_Nivel1)
                {
                    PlayerPrefs.SetInt("IsLvL4", 1);
                }
                return B_Nivel3;
            case 4:
                if (Score_Manager.instance.m_Score >= B_Nivel1)
                {
                    PlayerPrefs.SetInt("IsLvL5", 1);
                }
                return B_Nivel4;
            case 5:
                return B_Nivel5;
            default:
                Debug.LogWarning("Scene index not recognized for block selection.");
                return 0; 
        }
    }
}

