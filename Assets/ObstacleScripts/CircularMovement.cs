using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement2D : MonoBehaviour
{
    public Transform pivotPoint; // Reference to the pivot point
    public float radius; // Radius of the circular path
    public float speed; // Speed of rotation

    private float angle = 0f;

    public void Start()
    {
        pivotPoint = GameObject.Find("CirclePivot").transform;
    }
    void Update()
    {
        // Calculate the position on the circle using trigonometry
        float x = pivotPoint.position.x + Mathf.Cos(angle) * radius;
        float y = pivotPoint.position.y + Mathf.Sin(angle) * radius;

        // Update the object's position
        transform.position = new Vector2(x, y);

        // Rotate the object to face the pivot point (optional)
        Vector2 lookDirection = (pivotPoint.position - transform.position).normalized;
        float angleInDegrees = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleInDegrees, Vector3.forward);

        // Increase the angle based on speed
        angle += speed * Time.deltaTime * Singleton.singleton.spawnerSpeedScale;

        // Wrap angle to keep it between 0 and 360 degrees
        angle = Mathf.Repeat(angle, 360f);
    }
}
