using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    public static SettingsScreen instance;

    [SerializeField] GameObject PanelCredits;
    [SerializeField] GameObject PanelAudio;
    [SerializeField] GameObject Back;
    [SerializeField] GameObject ButtonAudioOn;
    [SerializeField] GameObject ButtonAudioOff;
    [SerializeField] GameObject ButtonEffectsOn;
    [SerializeField] GameObject ButtonEffectsOff;
    [SerializeField] GameObject Audio;
    [SerializeField] GameObject PrefabBombBack;

    [SerializeField] GameObject MenuInicial;
    [SerializeField] InitialMenu initialmenu;

    private void Awake()
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
    public void MenuSettingsCame()
    {
        print("hola");
        LeanTween.moveLocalX(PanelCredits, -450, 0.5f);  
        LeanTween.moveLocalX(PanelAudio, 900, 0.5f);
        LeanTween.scale(Back, new Vector3(3,3,3), 0.5f);
        LeanTween.scale(PrefabBombBack, Vector3.one, 0.5f);

    }

    public void BackToInitialMenu()
    {
        LeanTween.moveLocalX(PanelCredits, -2400, 0.5f).setEase(LeanTweenType.linear).setOnComplete(() =>
        {

            MenuInicial.gameObject.SetActive(true);
            initialmenu.MenuInicialCame();
            this.gameObject.SetActive(false);

        }); 
        LeanTween.scale(Back, Vector3.zero, 0.5f);
        LeanTween.scale(PrefabBombBack, Vector3.zero, 0.5f);
        LeanTween.moveLocalX(PanelAudio, 2000, 0.5f).setEase(LeanTweenType.linear);
    }
}
