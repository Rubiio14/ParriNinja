using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILemonExample : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        InitialMenu.instance.SettingsButton();
        LimonUIBehaviour.instance.ActivateParticles();
        LimonUIBehaviour.instance.Piezas();
        Pollo_UI_Behaviour.instance.gameObject.SetActive(false);


        Cuchillo.instance.initialMenuActive = false;
        Cuchillo.instance.settingsActive = true;
        Cuchillo.instance.menuLevelActive = false;
        Debug.Log("Slice Lemon UI");
    }
}
