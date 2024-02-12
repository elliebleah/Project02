using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    public List<string> allTags;

    public int health = 5;

    public bool invincible;
    public float invincibleTimer;


    public void Start()
    {   
        Singleton.singleton.notifyHealthChange(health);
    }

    

    // Check for collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided GameObject has the specified tag
        string tag = other.gameObject.tag;
        if (inTag(tag) && !invincible)
        {
            Debug.Log("over");
            health -= 1;
            //Debug.Log("Health: " + health);
            Singleton.singleton.notifyHealthChange(health);
            invincible = true;
            StartCoroutine(InvincibleFrame());

            // Destroy this GameObject
            if (this.gameObject.GetComponent<Explode>() != null)
            {
                this.gameObject.GetComponent<Explode>().explodeOnImpact();
            }            
            if (health <= 0)
            {
                
                Destroy(gameObject);
                Singleton.singleton.endGame();
            }
        }
    }


    bool inTag(string target)
    {
        foreach (string s in allTags)
        {
            if (target == s)
            {
                return true;
            }
            
            //break;
        }
        return false;
    }

    // Check if the GameObject doesn't have a Collider2D attached
    void OnValidate()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning("GarbageCollector: No Collider2D attached to GameObject.");
        }
    }

    IEnumerator InvincibleFrame()
    {
        while (true)
        {
            yield return new WaitForSeconds(invincibleTimer);
            invincible = false;
        }
    }
}
