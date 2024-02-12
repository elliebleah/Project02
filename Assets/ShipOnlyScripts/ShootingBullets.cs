using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootCooldown = 0.5f; // Cooldown time between shots
    private bool canShoot = true; // Flag to control shooting cooldown
    public GameObject bulletHolder;

    public GameObject rotator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(ShootWithCooldown());
        }
    }

    IEnumerator ShootWithCooldown()
    {
        // Disable shooting temporarily
        canShoot = false;

        // Instantiate the bullet
        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletObject.transform.SetParent(bulletHolder.transform);
        // Calculate the rotation in degrees
        float shipRotation = rotator.transform.eulerAngles.z + 90f;
        float bulletRotation = shipRotation; // Modify this as needed based on your game's logic

        // Get the Bullet component and launch it
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Launch(bulletRotation);
        }

        // Wait for the cooldown
        yield return new WaitForSeconds(shootCooldown);

        // Enable shooting again
        canShoot = true;
    }
}