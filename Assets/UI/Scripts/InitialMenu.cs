using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMenu : MonoBehaviour
{
    [SerializeField] GameObject Logo, ButtonStart, ButtonSettings, MeetToStart, MeetToSettings;
    [SerializeField] GameObject Opciones;

    [SerializeField] SettingsScreen settingsScreen;

    public float m_TimeOfTransition;

    // Start is called before the first frame update
    void Start()
    {
       MenuInicialCame();
        Opciones.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void MenuInicialCame()
    {
        LeanTween.moveLocal(Logo, new Vector2(0, 200), m_TimeOfTransition).setEase(LeanTweenType.linear);
        LeanTween.scale(ButtonStart, Vector3.one, m_TimeOfTransition);
        LeanTween.scale(ButtonSettings, Vector3.one, m_TimeOfTransition);
        LeanTween.scale(MeetToStart, Vector3.one, m_TimeOfTransition);
        LeanTween.scale(MeetToSettings, Vector3.one, m_TimeOfTransition);
    }

    //funciones para los botones
    public void SettingsButton()
    {
        LeanTween.moveLocal(Logo, new Vector2(0, 1164), m_TimeOfTransition).setEase(LeanTweenType.linear).setOnComplete(() => 
        { 
            
            Opciones.gameObject.SetActive(true);
            settingsScreen.MenuSettingsCame();
            this.gameObject.SetActive(false);

        }); ;
        LeanTween.scale(ButtonStart, Vector3.zero, m_TimeOfTransition);
        LeanTween.scale(ButtonSettings, Vector3.zero, m_TimeOfTransition);
        LeanTween.scale(MeetToStart, Vector3.zero, m_TimeOfTransition);
        LeanTween.scale(MeetToSettings, Vector3.zero, m_TimeOfTransition);
       
    }

}
