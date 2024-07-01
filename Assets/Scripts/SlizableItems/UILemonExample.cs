using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILemonExample : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        LimonUIBehaviour.instance.ActivateParticles();
        LimonUIBehaviour.instance.Piezas();
        Cuchillo.instance.m_CutSound.Play();
        InitialMenu.instance.SettingsButton();
        Pollo_UI_Behaviour.instance.gameObject.SetActive(false);

        LeanScale_Botones.instance.EnterInSettings();

        Debug.Log("Slice Lemon UI");
    }
}
