using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMenu : MonoBehaviour
{
    [SerializeField] GameObject Logo, ButtonStart, ButtonSettings, MeetToStart, MeetToSettings;
    [SerializeField] GameObject Opciones;

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
        LeanTween.moveLocal(Logo, new Vector2(0, 200), 0.5f).setEase(LeanTweenType.linear);
        LeanTween.scale(ButtonStart, Vector3.one, 0.5f);
        LeanTween.scale(ButtonSettings, Vector3.one, 0.5f);
        LeanTween.scale(MeetToStart, Vector3.one, 0.5f);
        LeanTween.scale(MeetToSettings, Vector3.one, 0.5f);
    }

    //funciones para los botones
    public void SettingsButton()
    {
        LeanTween.moveLocal(Logo, new Vector2(0, 1164), 1f).setEase(LeanTweenType.linear).setOnComplete(() => 
        { 
            this.gameObject.SetActive(false);
            Opciones.gameObject.SetActive(true);

        }); ;
        LeanTween.scale(ButtonStart, Vector3.zero, 0.5f);
        LeanTween.scale(ButtonSettings, Vector3.zero, 0.5f);
        LeanTween.scale(MeetToStart, Vector3.zero, 0.5f);
        LeanTween.scale(MeetToSettings, Vector3.zero, 0.5f);
       
    }

}
