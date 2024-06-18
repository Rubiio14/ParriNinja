using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fade_Manchas : MonoBehaviour
{
    public static Fade_Manchas instance;

    [SerializeField] GameObject manchas;

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
        manchas.transform.position = objeto.transform.position;

        manchas.SetActive(true);

        CanvasGroup manchaCanvas = mancha.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>();

        LeanTween.alphaCanvas(manchaCanvas, 0, 1f).setOnComplete(() =>
        {
            manchas.SetActive(false);
        });
    }
}
