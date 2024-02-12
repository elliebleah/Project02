using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying the score

    private int score = 0;  

    void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    // Call this method whenever the score changes
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Update the score text to display the current score
        scoreText.text = "Score: " + score.ToString();
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int s)
    {
        score = s;
    }


}