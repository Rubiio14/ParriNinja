using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    [SerializeField] GameObject Logo, ButtonStart, ButtonSettings, MeetToStart, MeetToSettings;
    [SerializeField] GameObject Opciones;
    [SerializeField] GameObject MenuLevels;

    [SerializeField] SettingsScreen settingsScreen;
    [SerializeField] MenuLevels menuLevels;

    public float m_TimeOfTransition;

    public static InitialMenu instance;


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
       MenuInicialCame();
        Opciones.gameObject.SetActive(false);
        MenuLevels.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }


    public void MenuInicialCame()
    {
        LeanTween.moveLocal(Logo, new Vector2(0, 0), m_TimeOfTransition).setEase(LeanTweenType.linear);
        LeanTween.scale(ButtonStart, new Vector3(3.5f,3.5f,3.5f), m_TimeOfTransition);
        LeanTween.scale(ButtonSettings, new Vector3 (3.5f, 3.5f, 3.5f), m_TimeOfTransition);
        LeanTween.scale(MeetToStart, Vector3.one, m_TimeOfTransition);
        LeanTween.scale(MeetToSettings, Vector3.one, m_TimeOfTransition);
    }
    public void MenuInicialIsGone()
    {
        LeanTween.scale(ButtonStart, Vector3.zero, m_TimeOfTransition);
        LeanTween.scale(ButtonSettings, Vector3.zero, m_TimeOfTransition);
        LeanTween.scale(MeetToStart, Vector3.zero, m_TimeOfTransition);
        LeanTween.scale(MeetToSettings, Vector3.zero, m_TimeOfTransition);

    }

    //funciones para los botones
    public void SettingsButton()
    {
        print("hola");
        MenuInicialIsGone();
        LeanTween.moveLocal(Logo, new Vector2(0, 1300), m_TimeOfTransition).setEase(LeanTweenType.linear).setOnComplete(() => 
        { 
            
            Opciones.gameObject.SetActive(true);
            settingsScreen.MenuSettingsCame();
            this.gameObject.SetActive(false);
            Hueso_UI.instance.HuesoInstanciado();

        }); ;
       
       
    }

    
    public void GoToLevelMenu()
    {
        MenuInicialIsGone();
        MenuLevels.gameObject.SetActive(true);
        LeanTween.moveLocal(Logo, new Vector2(0, 1300), m_TimeOfTransition).setEase(LeanTweenType.linear).setOnComplete(() =>
        {
           MenuLevels.gameObject.SetActive(true);
           menuLevels.MenuLevelCome();


            this.gameObject.SetActive(false);

        }); ;

    }

  
}
