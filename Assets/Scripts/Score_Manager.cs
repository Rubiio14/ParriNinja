using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    public int m_NCarnes = 0;
    public int m_Score = 0;
    [SerializeField]
    GameObject m_VictoryCanvas;

    public static Score_Manager instance;
    // Start is called before the first frame update
    [SerializeField]
    public TextMeshProUGUI m_CarnesTxt;
    [SerializeField]
    public TextMeshProUGUI m_ScoreTxt;
    [SerializeField]
    public TextMeshProUGUI m_VCarnesTxt;
    [SerializeField]
    public TextMeshProUGUI m_VScoreTxt;

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
                    RythmManager.instance.gameLoop[i].m_objectTypes[j] == ObjectTypes.Ribs)
                {
                    m_NCarnes++;
                }
                
                
            }
            
        }
        m_CarnesTxt.text = "Carnes: " + m_NCarnes;
        m_VCarnesTxt.text = "Te quedaron " + m_NCarnes + " por cortar";
    }

    public void VictoryScreen()
    {
        
        m_VScoreTxt.text = "Score: " + m_Score;
        m_VictoryCanvas.SetActive(true);
        m_ScoreTxt.gameObject.SetActive(false);
        m_CarnesTxt.gameObject.SetActive(false);
    }
    public void RestaCarne()
    {
        m_NCarnes--;
        m_CarnesTxt.text = "Carnes: " + m_NCarnes;
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
        m_ScoreTxt.text = "Score: " + m_Score;

    }
}
