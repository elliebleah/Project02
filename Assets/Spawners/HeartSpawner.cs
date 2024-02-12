using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heartPrefab;
    public GameObject spawnArea; // GameObject to define the spawning area
    public float spawnInterval = 3f; // Adjust spawn interval as needed

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning hearts
        InvokeRepeating("SpawnHeart", 0f, spawnInterval);
    }

    // Function to spawn a heart
    void SpawnHeart()
    {
        // Calculate random position within the spawn area
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the heartPrefab at the random position
        Instantiate(heartPrefab, spawnPosition, Quaternion.identity);
    }

    // Function to get a random spawn position within the spawn area
    Vector3 GetRandomSpawnPosition()
    {
        if (spawnArea != null)
        {
            // Get the bounds of the spawn area
            Bounds bounds = spawnArea.GetComponent<Renderer>().bounds;

            // Generate a random position within the bounds
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);

            // Return the random position
            return new Vector3(randomX, randomY, 0f);
        }
        else
        {
            Debug.LogError("Spawn area GameObject is not assigned!");
            return Vector3.zero;
        }
    }
}
