using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Singleton : MonoBehaviour
{
    // Start is called before the first frame update


    public Score score;

    public static Singleton singleton;
    public TextMeshProUGUI healthText;

    public int asteroidSpawnerSpeedScale = 1;
    public int asteroidSpeedScale = 1;

    public float spawnerSpeedScale = 1f;

    public int speedUpThreshold = 100;

    public bool progDif;

    public int difficulty = 0;

    //public ProgressiveDifficulty progDif;

    //private
    void Awake()
    {
        singleton = this;
        PlayerPrefs.GetInt("Highscore", 0);

        if (PlayerPrefs.GetInt("Progressive", 0) == 1)
        {
            progDif = true;
        }

    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void notifyScoreChange(int points)
    {
        score.AddScore(points);
        if (score.getScore() % speedUpThreshold == 0 && score.getScore() > 0 && spawnerSpeedScale <= 3f && progDif)
        {
            spawnerSpeedScale *= 1.1f;
        }
    }


    public int notifyGetScore()
    {
        return score.getScore();
    }

    public void notifyHealthChange(int n)
    {
        healthText.text =  "x" + n;
    }

    public void endGame()
    {
        PlayerPrefs.SetInt("Highscore", score.getScore());
        SceneManager.LoadScene("EndingScene");
    }
}
