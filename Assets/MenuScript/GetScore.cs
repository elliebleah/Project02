using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = "Highscore is " + PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
