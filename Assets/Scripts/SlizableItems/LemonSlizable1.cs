using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonSlizable1 : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        this.gameObject.GetComponent<Lemon_Behaviour>().Cortado();
        Cuchillo.instance.m_CutSound.Play();
    }
}
