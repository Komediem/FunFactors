using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenus;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject CanvasModel;

    [Header("Model3D")]
    [SerializeField] private GameObject PropaneTank;
    [SerializeField] private GameObject Barrel;
    [SerializeField] private GameObject Gaztank;
    [SerializeField] private GameObject PropaneTankBlack;
    [SerializeField] private GameObject BarrelBlack;
    [SerializeField] private GameObject GaztankBlack;

    [SerializeField] private TextMeshProUGUI finalScore;

    [SerializeField] private TextMeshProUGUI propaneText;
    [SerializeField] private TextMeshProUGUI barrelText;
    [SerializeField] private TextMeshProUGUI gazText;

    private float propaneMedalValue = 4500;
    private float barrelMedalValue = 6000;
    private float gazMedalValue = 7500;

    private FishCounter fishCounter;
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        fishCounter = FindObjectOfType<FishCounter>();
    }

    private void Update()
    {
        if (timer.timerIsActive == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inGameMenus.SetActive(false);
            endMenu.SetActive(true);
            CanvasModel.SetActive(true);
            Medals();

            finalScore.text = fishCounter.fishCount.ToString();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Medals()
    {
        if (fishCounter.fishCount >= propaneMedalValue)
        {
            PropaneTank.SetActive(true);
            propaneText.text = "Bravo ! Vos 4500 poissons vous ont fait gagner la médaille de Propane !";
        }
        else
        {
            PropaneTankBlack.SetActive(true);
            propaneText.text = "dommage ! tu es à " + (propaneMedalValue - fishCounter.fishCount) + " de la médaille de Propane !";
        }

        if (fishCounter.fishCount >= barrelMedalValue)
        {
            Barrel.SetActive(true);
            barrelText.text = "Bravo ! Vos 6000 poissons vous ont fait gagner la médaille du Baril !";
        }
        else
        {
            BarrelBlack.SetActive(true);
            barrelText.text = "dommage ! tu es à " + (barrelMedalValue - fishCounter.fishCount) + " de la médaille du Baril !";
        }

        if (fishCounter.fishCount >= gazMedalValue)
        {
            Gaztank.SetActive(true) ;
            gazText.text = "Bravo ! Vos 7500 poissons vous ont fait gagner la médaille du Jerrican !";
        }
        else
        {
            GaztankBlack.SetActive(true) ;
            gazText.text = "dommage ! tu es à " + (gazMedalValue - fishCounter.fishCount) + " de la médaille du Jerrican !";
        }
    }
}
