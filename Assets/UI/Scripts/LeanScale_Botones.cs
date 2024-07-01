using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanScale_Botones : MonoBehaviour
{
    public static LeanScale_Botones instance;
    [SerializeField]
    GameObject pollo_UI, LemonSett_UI, huesoSett_UI, HuesoNiv_UI;

    [SerializeField]
    GameObject menuEmpty, optionsEmpty, levelsEmpty;

    Vector3 botonesFullScale;
    Vector3 huesosFullScale;

    private void Awake()
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
    private void Start()
    {
       // Cuchillo.instance.initialMenuActive = true;

        botonesFullScale = new Vector3(1.6f, 1.6f, 1.6f);
        huesosFullScale = new Vector3(25f, 25f, 25f);
        //EnterInitialMenu();
    }

    public void EnterInitialMenu()
    {
        LeanTween.scale(pollo_UI, botonesFullScale, 0.5f);
        LeanTween.scale(LemonSett_UI, botonesFullScale, 0.5f);

        huesoSett_UI.transform.localScale -= huesoSett_UI.transform.localScale;
        HuesoNiv_UI.transform.localScale -= HuesoNiv_UI.transform.localScale;
       
    }

    public void EnterInSettings()
    {
        LeanTween.scale(huesoSett_UI, huesosFullScale, 1f);

        StartCoroutine(DelayPolloLimon());
        

    }

    public void EnterInLevelMenu()
    {
        LeanTween.scale(HuesoNiv_UI, huesosFullScale, 0.75f);

        StartCoroutine(DelayPolloLimon());
        

    }

    public void EnterToLevel()
    {
      
        huesoSett_UI.transform.localScale -= huesoSett_UI.transform.localScale;
        HuesoNiv_UI.transform.localScale -= HuesoNiv_UI.transform.localScale;
       
       
    }
    IEnumerator DelayPolloLimon()
    {
        yield return new WaitForSeconds(1f);
        pollo_UI.transform.localScale -= pollo_UI.transform.localScale;
        LemonSett_UI.transform.localScale -= LemonSett_UI.transform.localScale;
    }
    
}
