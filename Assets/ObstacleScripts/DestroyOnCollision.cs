using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnCollision : MonoBehaviour
{
    public string targetTag;


    // Check for collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided GameObject has the specified tag
        if (other.CompareTag(targetTag))
        {
            // Destroy this GameObject
            if (this.gameObject.GetComponent<Explode>() != null)
            {
                this.gameObject.GetComponent<Explode>().explodeOnImpact();
            }        
            Destroy(gameObject);
            if (targetTag == "bullet" || targetTag == "Bullet")
            {
                Singleton.singleton.notifyScoreChange(10 * Singleton.singleton.difficulty);
            }

            if (this.tag == "Player")
            {
                Singleton.singleton.endGame();
            }

            if (this.tag == "Poison" && targetTag == "Bullet")
            {
                int health = GameObject.Find("PlayerShip").GetComponent<PlayerCollision>().health;
                health -= 1;
                Singleton.singleton.notifyHealthChange(health);
            }

            
        }

        
    }



    // Check if the GameObject doesn't have a Collider2D attached
    void OnValidate()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning("GarbageCollector: No Collider2D attached to GameObject.");
        }
    }
}
