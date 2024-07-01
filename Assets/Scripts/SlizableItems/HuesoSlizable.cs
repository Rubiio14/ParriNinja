using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoSlizable : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        this.gameObject.GetComponent<HuesoBehaviour>().Hueso();
        Cuchillo.instance.m_BoneSound.Play();
    }
}
