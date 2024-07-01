using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoUISlizable : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        Hueso_UI.instance.HuesoCortado();
        SettingsScreen.instance.BackToInitialMenu();
        LimonUIBehaviour.instance.gameObject.SetActive(true);
        Pollo_UI_Behaviour.instance.gameObject.SetActive(true);
        LimonUIBehaviour.instance.ResetToFactorySettings();
        Pollo_UI_Behaviour.instance.ResetToFactorySettings();
        Hueso_UI.instance.HuesoCortado();
    }
}
