using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component for displaying the timer

    private float elapsedTime = 0f;

    void Start()
    {
        // Initialize the timer text
        UpdateTimerText();
    }

    void Update()
    {
        // Update the elapsed time every frame
        elapsedTime += Time.deltaTime;

        // Update the timer text every second
        if (Mathf.FloorToInt(elapsedTime) != Mathf.FloorToInt(elapsedTime - Time.deltaTime))
        {
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // Update the timer text to display the elapsed time
        timerText.text = "Timer: " + Mathf.FloorToInt(elapsedTime).ToString();
    }
}

