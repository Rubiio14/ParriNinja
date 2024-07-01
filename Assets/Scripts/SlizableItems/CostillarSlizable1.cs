using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostillarSlizable1 : MonoBehaviour, SlizableItem
{
    public void Slice()
    {
        this.gameObject.GetComponent<CostillarBehaviour>().Cortado();
        Cuchillo.instance.m_CutSound.Play();
    }
}
