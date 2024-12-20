using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewScoreManager : MonoBehaviour
{
    public int m_Score = 0;


    [SerializeField]
    public TextMeshProUGUI m_ScoreTxt;

    [SerializeField]
    UI_GamePlay ui_GamePlay;


    public static NewScoreManager instance;
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
        m_ScoreTxt.text = m_Score.ToString("00");
        m_Score = 0;
    }
    public void SumaPuntos(int puntos)
    {
        m_Score += puntos;
        m_ScoreTxt.text = m_Score.ToString("00");
        ui_GamePlay.AnimationPoints();
    }
}
