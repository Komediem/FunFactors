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

    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        if (timer.timerIsActive == false)
        {
            inGameMenus.SetActive(false);
            endMenu.SetActive(true);
            CanvasModel.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level");
    }
}
