using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    public AudioSource m_VictorySound;
    public int m_NCarnes = 0;
    public int m_Score = 0;
    [SerializeField]
    GameObject m_VictoryCanvas;

    [SerializeField]
    public TextMeshProUGUI m_MaxCarneTxt;

    public static Score_Manager instance;

    [SerializeField]
    public TextMeshProUGUI m_CarnesTxt;
    [SerializeField]
    public TextMeshProUGUI m_ScoreTxt;
    [SerializeField]
    public TextMeshProUGUI m_VictoryScreenScore;
    [SerializeField]
    public TextMeshProUGUI m_VCarnesTxt;
    [SerializeField]
    public TextMeshProUGUI m_VScoreTxt;

    [SerializeField]
    UI_GamePlay ui_GamePlay;

    [SerializeField] GameObject Win;

    // Add a reference to the Bloqueos_Nivel script
    [SerializeField]
    Bloqueos_Nivel bloqueos_Nivel;

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

    void Start()
    {
        for (int i = 0; i < RythmManager.instance.gameLoop.Length; i++)
        {
            for (int j = 0; j < RythmManager.instance.gameLoop[i].m_objectTypes.Length; j++)
            {
                if (RythmManager.instance.gameLoop[i].m_objectTypes[j] == ObjectTypes.Chicken ||
                    RythmManager.instance.gameLoop[i].m_objectTypes[j] == ObjectTypes.Lamb ||
                    RythmManager.instance.gameLoop[i].m_objectTypes[j] == ObjectTypes.Ribs ||
                    RythmManager.instance.gameLoop[i].m_objectTypes[j] == ObjectTypes.Sausage ||
                    RythmManager.instance.gameLoop[i].m_objectTypes[j] == ObjectTypes.Meatball)
                {
                    m_NCarnes++;
                }
            }
        }
        m_CarnesTxt.text = m_NCarnes.ToString("00");
        m_MaxCarneTxt.text = m_NCarnes.ToString("00");
        m_VCarnesTxt.text = "Te quedaron " + m_NCarnes + " por cortar";
    }

    public void VictoryScreen()
    {
        m_VictorySound.Play();
        m_VScoreTxt.text = "Score: " + m_Score;
        /* m_VictoryCanvas.SetActive(true);
         m_ScoreTxt.gameObject.SetActive(false);
         m_CarnesTxt.gameObject.SetActive(false); */
        UI_GamePlay.instance.EndOfLevel(Win, m_VictoryCanvas);
        

    }

    public void RestaCarne()
    {
        m_NCarnes--;
        m_CarnesTxt.text = m_NCarnes.ToString("00");
        if (m_NCarnes == 0)
        {
            m_VCarnesTxt.text = "Has cortado todas las carnes";
        }
        else
        {
            m_VCarnesTxt.text = "Te quedaron " + m_NCarnes + " por cortar";
        }
    }

    public void SumaPuntos(int puntos)
    {
        m_Score += puntos;
        m_ScoreTxt.text = m_Score.ToString("00");
        m_VictoryScreenScore.text = m_Score.ToString("00");
        ui_GamePlay.AnimationPoints();
    }
}
