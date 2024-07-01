using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneSlizable : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        this.gameObject.GetComponent<CarneBehaviour>().Cortado();
        Cuchillo.instance.m_CutSound.Play();
    }
}
