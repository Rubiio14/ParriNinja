using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevels : MonoBehaviour
{
    [SerializeField] GameObject ButtonBack;
    [SerializeField] GameObject Prefab;
    [SerializeField] GameObject Levels;
    [SerializeField] GameObject ButtonLevelOne;
    [SerializeField] GameObject ButtonLevelTwo;
    [SerializeField] GameObject ButtonLevelThree;
    [SerializeField] GameObject ButtonLevelFour;
    [SerializeField] GameObject ButtonLevelFive;

    public float SpeedOfButtons;

    [SerializeField] InitialMenu initialMenu;
    [SerializeField] GameObject InitialMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuLevelCome()
    {
        LeanTween.moveLocalY(Levels, 550, 1.5f);

        LeanTween.scale(ButtonBack, Vector3.one, 1f);
        LeanTween.scale(Prefab, Vector3.one, 1f);
         LeanTween.scale(ButtonLevelOne, Vector3.one, SpeedOfButtons).setOnComplete(() =>
         {
            LeanTween.scale(ButtonLevelTwo, Vector3.one, SpeedOfButtons).setOnComplete(() =>
            {
                LeanTween.scale(ButtonLevelThree, Vector3.one, SpeedOfButtons).setOnComplete(() =>
                {
                    LeanTween.scale(ButtonLevelFour, Vector3.one, SpeedOfButtons).setOnComplete(() =>
                    {
                        LeanTween.scale(ButtonLevelFive, Vector3.one, SpeedOfButtons);
                    });
                });
            });
         });

    }

    public void MenuLevelGone()
    {
        LeanTween.moveLocalY(Levels, 800, 1.5f);

        LeanTween.scale(ButtonBack, Vector3.zero, 1f);
        LeanTween.scale(Prefab, Vector3.zero, 1f);
        LeanTween.scale(ButtonLevelOne, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
        {
            LeanTween.scale(ButtonLevelTwo, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
            {
                LeanTween.scale(ButtonLevelThree, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
                {
                    LeanTween.scale(ButtonLevelFour, Vector3.zero, SpeedOfButtons).setOnComplete(() =>
                    {
                        LeanTween.scale(ButtonLevelFive, Vector3.zero, SpeedOfButtons);

                        InitialMenu.SetActive(true);
                        initialMenu.MenuInicialCame();
                        this.gameObject.SetActive(false);
                    });
                });
            });
        });

    }
    public void StartGame(string sceneName)
    {
            SceneManager.LoadScene(sceneName);       
    }
}
