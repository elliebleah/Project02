using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject asteroidSpawner;
    public GameObject waveSpawner;
    public GameObject circularSpawner;

    public GameObject poisonerSpawner, stillSpawner;

    public int difficulty = 0;
    void Awake()
    {
        if (PlayerPrefs.GetInt("Asteroid", 0) == 1)
        {
            asteroidSpawner.SetActive(true);
            difficulty += 1;
        }
        if (PlayerPrefs.GetInt("Wave", 0) == 1)
        {
            waveSpawner.SetActive(true);
            difficulty += 1;
        }
        if (PlayerPrefs.GetInt("Revolver", 0) == 1)
        {
            circularSpawner.SetActive(true);
            difficulty += 1;
        }
        if (PlayerPrefs.GetInt("Poisoner", 0) == 1)
        {
            poisonerSpawner.SetActive(true);
            difficulty += 1;
        }
        if (PlayerPrefs.GetInt("Still", 0) == 1)
        {
            stillSpawner.SetActive(true);
            difficulty += 1;
        }
    }

    void Start()
    {
        Singleton.singleton.difficulty = difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
