using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Audio : MonoBehaviour
{
    [SerializeField] GameObject ButtonAudioOn;
    [SerializeField] GameObject ButtonAudioOff;
    [SerializeField] GameObject ButtonEffectsOn;
    [SerializeField] GameObject ButtonEffectsOff;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectsOn()
    {
        print("hola");
        ButtonEffectsOn.SetActive(true);
        ButtonEffectsOff.SetActive(false);
    }
    public void EffectOff() 
    {
        ButtonEffectsOn.SetActive(false);
        ButtonEffectsOff.SetActive(true);
    }
    public void AudioOn()
    {
        ButtonAudioOn.SetActive(true);
        ButtonAudioOff.SetActive(false);

    }
    public void AudioOff()
    {
        ButtonAudioOn.SetActive(false);
        ButtonAudioOff.SetActive(true);
    }
}
