using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    public bool taken = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !taken)
        {
            // Destroy the heart GameObject
            //Debug.Log("heart to hart");
            other.gameObject.GetComponent<PlayerCollision>().health += 1;
            int health = other.gameObject.GetComponent<PlayerCollision>().health;
            Debug.Log("Health: " + health);
            taken = true;
            Singleton.singleton.notifyHealthChange(health);
            Destroy(gameObject);
        }
    }
}

