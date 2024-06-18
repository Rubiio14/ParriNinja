using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoBehaviour : MonoBehaviour
{
    public void Hueso()
    {
        Health_Manager.instance.RestaVida();
        Health_Manager.instance.Defeat();
    }
}
