using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI preTimer;

    public GameObject preTimerGroup;

    private float timeRemaining = 30f;
    private float preTimeRemaining = 5f;

    public bool timerIsActive = false;
    public bool preTimerIsActive = true;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        PreTimer();
        GameTimer();
    }

    private void GameTimer()
    {
        if (timerIsActive && preTimerIsActive == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsActive = false;
                Time.timeScale = 0f;
            }

        }

        timer.text = timeRemaining.ToString("0.00");
    }

    private void PreTimer()
    {
        if (preTimerIsActive)
        {
            if (preTimeRemaining > 0)
            {
                preTimeRemaining -= Time.deltaTime;
            }
            else
            {
                preTimeRemaining = 0;
                preTimerIsActive = false;
                timerIsActive = true;
                preTimerGroup.SetActive(false);
            }

        }
        preTimer.text = preTimeRemaining.ToString("0");
    }
}
