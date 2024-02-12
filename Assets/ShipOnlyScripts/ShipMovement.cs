using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust speed as needed
    public float rotationSpeed = 100f;
    
    public GameObject rotator; // Adjust rotation speed as needed

    // Update is called once per frame
    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotatePivot(rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotatePivot(-rotationSpeed * Time.deltaTime);
        }
    }

    void RotatePivot(float angle)
    {
        // Rotate the pivot point of the ship
        // Adjust 'pivot' to the appropriate pivot point in your ship hierarchy
        rotator.transform.RotateAround(rotator.transform.position, Vector3.forward, angle);
    }

    // Optionally, you can add collision detection and handling here
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Handle collision here
    // }
}
