using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    // Method to launch the bullet in a specified direction


    public void Launch(float degrees)
    {
        //Debug.Log("going " + degrees);
        // Convert degrees to radians
        float radians = degrees * Mathf.Deg2Rad;

        // Calculate direction based on ship's rotation
        Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, degrees + 90);

        // Apply velocity to the bullet
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void LaunchTowards(Transform target)
    {
        // Calculate direction towards the target
        Vector2 direction = (target.position - transform.position).normalized;

        // Calculate rotation towards the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the bullet to face the target
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle + 90);

        // Apply velocity to the bullet towards the target
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
