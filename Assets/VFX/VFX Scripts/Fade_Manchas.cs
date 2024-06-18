using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fade_Manchas : MonoBehaviour
{
    public static Fade_Manchas instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    //Funcion para hacer aparecer una de las manchas y que esta desaparezca.
    public void Mancha(GameObject mancha, GameObject objeto)
    {
        mancha.transform.position = objeto.transform.position;

        mancha.SetActive(true);

        CanvasGroup manchaCanvas = mancha.GetComponent<CanvasGroup>();

        manchaCanvas.gameObject.SetActive(true);

        LeanTween.alphaCanvas(manchaCanvas, 0, 1f).setOnComplete(() =>
        {
            mancha.SetActive(false);
        });
    }
}
