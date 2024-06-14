using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] GameObject PanelCredits;
    [SerializeField] GameObject PanelAudio;
    [SerializeField] GameObject Back;
    [SerializeField] GameObject ButtonAudioOn;
    [SerializeField] GameObject ButtonAudioOff;
    [SerializeField] GameObject ButtonEffectsOn;
    [SerializeField] GameObject ButtonEffectsOff;
    [SerializeField] GameObject Audio;
    [SerializeField] GameObject PrefabBombBack;


    // Start is called before the first frame update
    void Start()
    {
        MenuSettingsCame();
    }

    // Update is called once per frame
    void Update()
    {
        print(PanelAudio.transform.position.y);
    }

    public void MenuSettingsCame()
    {
        LeanTween.moveLocal(PanelCredits, new Vector3(-300,0), 1f);  
        LeanTween.moveLocalX(PanelAudio, 600, 1f);
        LeanTween.scale(Back, Vector3.one, 1f);
        LeanTween.scale(PrefabBombBack, Vector3.one, 1f);
    }
}
