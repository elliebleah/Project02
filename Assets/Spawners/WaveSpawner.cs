using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject waveEnemyPrefab;
    public GameObject spawnArea; // Reference to the spawn area GameObject
    public float spawnInterval = 2f;
    
    void Start()
    {
        StartCoroutine(SpawnWaveEnemies());
    }

    IEnumerator SpawnWaveEnemies()
    {
        while (true)
        {
            // Random position within the spawn area rectangle
            Vector2 spawnPosition = new Vector2(Random.Range(spawnArea.transform.position.x - spawnArea.transform.localScale.x / 2f, spawnArea.transform.position.x + spawnArea.transform.localScale.x / 2f),
                                                Random.Range(spawnArea.transform.position.y - spawnArea.transform.localScale.y / 2f, spawnArea.transform.position.y + spawnArea.transform.localScale.y / 2f));

            // Spawn waveEnemyPrefab at the random position
            Instantiate(waveEnemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval / Singleton.singleton.spawnerSpeedScale);
        }
    }
}

