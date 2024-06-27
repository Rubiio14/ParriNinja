using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPolloExample: MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        InitialMenu.instance.GoToLevelMenu();
        Pollo_UI_Behaviour.instance.ActivateParticles();
        Pollo_UI_Behaviour.instance.Piezas();
        LimonUIBehaviour.instance.gameObject.SetActive(false);
        Hueso_UI_Levels.instance.HuesoInstanciado();
        Cuchillo.instance.initialMenuActive = false;
        Cuchillo.instance.settingsActive = false;
        Cuchillo.instance.menuLevelActive = true;

        Debug.Log("Slice pollo UI");   
    }
}
