using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevels : MonoBehaviour
{
    public static MenuLevels instance;
    [SerializeField] GameObject ButtonBack;
    [SerializeField] GameObject Prefab;
    [SerializeField] GameObject Levels;
    [SerializeField] GameObject ButtonLevelOne;
    [SerializeField] GameObject ButtonLevelTwo;
    [SerializeField] GameObject ButtonLevelThree;
    [SerializeField] GameObject ButtonLevelFour;
    [SerializeField] GameObject ButtonLevelFive;
    [SerializeField] GameObject RingLevelOne;
    [SerializeField] GameObject RingLevelTwo;
    [SerializeField] GameObject RingLevelThree;
    [SerializeField] GameObject RingLevelFour;
    [SerializeField] GameObject RingLevelFive;

    public float SpeedOfButtons;

    [SerializeField] InitialMenu initialMenu;
    [SerializeField] GameObject InitialMenu;

    [SerializeField] CanvasGroup Fondo2;
    [SerializeField] CanvasGroup Fondo3;

    public void MenuLevelCome()
    {
      //  LeanScale_Botones.instance.EnterInLevelMenu();
        LeanTween.moveLocalY(Levels, 550, 0.5f);

        LeanTween.scale(ButtonBack, new Vector3(3,3,3), 0.5f);
        LeanTween.scale(Prefab, Vector3.one, 0.5f);
        LeanTween.scale(RingLevelOne, new Vector3(3, 3, 3), SpeedOfButtons);
         LeanTween.scale(ButtonLevelOne, Vector3.one, SpeedOfButtons).setOnComplete(() =>
         {
             LeanTween.scale(RingLevelTwo, new Vector3 (3,3,3), SpeedOfButtons);
            LeanTween.scale(ButtonLevelTwo, Vector3.one, SpeedOfButtons).setOnComplete(() =>
            {
                LeanTween.scale(RingLevelThree, new Vector3(3, 3, 3), SpeedOfButtons);
                LeanTween.scale(ButtonLevelThree, Vector3.one, SpeedOfButtons).setOnComplete(() =>
                {
                    LeanTween.scale(RingLevelFour, new Vector3(3, 3, 3), SpeedOfButtons);
                    LeanTween.scale(ButtonLevelFour, Vector3.one, SpeedOfButtons).setOnComplete(() =>
                    {
                        LeanTween.scale(RingLevelFive, new Vector3(3, 3, 3), SpeedOfButtons);
                        LeanTween.scale(ButtonLevelFive, Vector3.one, SpeedOfButtons);
                    });
                });
            });
         });

    }

    public void MenuLevelToInitial()
    {
        LeanTween.moveLocalY(Levels, 800, 0.5f);

        LeanTween.scale(ButtonBack, Vector3.zero, 0.5f);
        LeanTween.scale(Prefab, Vector3.zero, 0.5f);
        LeanTween.scale(RingLevelOne, Vector3.zero, SpeedOfButtons);
        LeanTween.scale(ButtonLevelOne, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
        {
            LeanTween.scale(RingLevelTwo, Vector3.zero, SpeedOfButtons);
            LeanTween.scale(ButtonLevelTwo, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
            {
                LeanTween.scale(RingLevelThree, Vector3.zero, SpeedOfButtons);
                LeanTween.scale(ButtonLevelThree, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
                {
                    LeanTween.scale(RingLevelFour, Vector3.zero, SpeedOfButtons);
                    LeanTween.scale(ButtonLevelFour, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
                    {
                        LeanTween.scale(RingLevelFive, Vector3.zero, SpeedOfButtons);
                        LeanTween.scale(ButtonLevelFive, Vector3.zero, SpeedOfButtons);

                        InitialMenu.SetActive(true);
                        initialMenu.MenuInicialCame();
                        this.gameObject.SetActive(false);
                    });
                });
            });
        });

    }
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
    
    public void StartLevel()
    {
        LeanTween.moveLocalY(Levels, 800, 0.5f);
        LeanScale_Botones.instance.EnterToLevel();
        LeanTween.scale(ButtonBack, Vector3.zero, 0.5f);
        LeanTween.scale(Prefab, Vector3.zero, 0.5f);
        LeanTween.scale(RingLevelOne, Vector3.zero, SpeedOfButtons);
        LeanTween.scale(ButtonLevelOne, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
        {
            LeanTween.scale(RingLevelTwo, Vector3.zero, SpeedOfButtons);
            LeanTween.scale(ButtonLevelTwo, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
          {
              LeanTween.scale(RingLevelThree, Vector3.zero, SpeedOfButtons);
              LeanTween.scale(ButtonLevelThree, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
            {
                LeanTween.scale(RingLevelFour, Vector3.zero, SpeedOfButtons);
                LeanTween.scale(ButtonLevelFour, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
                {
                    LeanTween.scale(RingLevelFive, Vector3.zero, SpeedOfButtons);
                    LeanTween.scale(ButtonLevelFive, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
                    {
                        LeanTween.alphaCanvas(Fondo2, 1, 1f);
                            /*if (sceneName == "PlayScene" && PlayerPrefs.GetInt("IsLvL1") == 1)
                            {
                                LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
                                {

                                    SceneManager.LoadScene(sceneName);

                                });
                                
                            }
                            else if (sceneName == "Nivel 2" && PlayerPrefs.GetInt("IsLvL2") == 1)
                            {
                                LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
                                {

                                    SceneManager.LoadScene(sceneName);

                                });
                                
                            }
                            else if (sceneName == "Nivel 3" && PlayerPrefs.GetInt("IsLvL3") == 1)
                            {
                                LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
                                {

                                    SceneManager.LoadScene(sceneName);

                                });
                                
                            }
                            else if (sceneName == "Nivel 4" && PlayerPrefs.GetInt("IsLvL4") == 1)
                            {
                                LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
                                {

                                    SceneManager.LoadScene(sceneName);

                                });
                                
                            }
                            else if (sceneName == "Nivel 5" && PlayerPrefs.GetInt("IsLvL5") == 1)
                            {
                                LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
                                {

                                    SceneManager.LoadScene(sceneName);

                                });
                                
                            }*/



                    });
                });
            });
        });
          //  Debug.Log(sceneName + " Bloqueado");
            
        });

    }
   
    public void Nivel_1(string sceneName)
    {
        StartLevel();
        LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

    public void Nivel_2(string sceneName)
    {

        if (sceneName == "Nivel 2" && PlayerPrefs.GetInt("IsLvL2") == 1)
        {
            StartLevel();
            LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
            });

       
        }
        else 
        {
            Debug.Log(sceneName + " Bloqueado");
        }
    }
    public void Nivel_3(string sceneName)
    {
        if (sceneName == "Nivel 3" && PlayerPrefs.GetInt("IsLvL3") == 1)
        {
            StartLevel();
            LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
            {

                SceneManager.LoadScene(sceneName);

            });

        }
        else
        {
            Debug.Log(sceneName + " Bloqueado");
        }
    }
    public void Nivel_4(string sceneName)
    {
        if (sceneName == "Nivel 4" && PlayerPrefs.GetInt("IsLvL4") == 1)
        {
            StartLevel();
            LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
            {

                SceneManager.LoadScene(sceneName);

            });

        }
        else
        {
            Debug.Log(sceneName + " Bloqueado");
        }
    }
    public void Nivel_5(string sceneName)
    {
        if (sceneName == "Nivel 5" && PlayerPrefs.GetInt("IsLvL5") == 1)
        {
            StartLevel();
            LeanTween.alphaCanvas(Fondo3, 1, 1f).setOnComplete(() =>
            {

                SceneManager.LoadScene(sceneName);

            });

        }
        else
        {
            Debug.Log(sceneName + " Bloqueado");
        }
    }
}
            
