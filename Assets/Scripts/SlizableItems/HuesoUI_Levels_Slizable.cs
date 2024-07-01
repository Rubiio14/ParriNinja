using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoUI_Levels_Slizable : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        MenuLevels.instance.MenuLevelToInitial();
        LimonUIBehaviour.instance.ResetToFactorySettings();
        Pollo_UI_Behaviour.instance.ResetToFactorySettings();
        LimonUIBehaviour.instance.gameObject.SetActive(true);
        Pollo_UI_Behaviour.instance.gameObject.SetActive(true);
        Hueso_UI_Levels.instance.HuesoCortado();
    } 
}
