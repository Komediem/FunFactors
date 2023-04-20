using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;

    private float timeRemaining = 30f;
    public bool timerIsActive = true;


    void Update()
    {
        if(timerIsActive)
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
}
