using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    int actualMoment = 0;
    int m_Carnes;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RythmManager.instance.gameLoop.Length; i++)
        {
            for (int j = 0; j < RythmManager.instance.gameLoop[j].Length; j++)
                m_Carnes++;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
