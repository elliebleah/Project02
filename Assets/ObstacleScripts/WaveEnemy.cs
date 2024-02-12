using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float nextFireTime;
    private float startY;

    Transform bulletHolder;

    [SerializeField]
    int launchID;

    [SerializeField]
    bool started = true;

    public float timer = 0f;

    void Start()
    {
        startY = transform.position.y;
        bulletHolder = GameObject.Find("bulletHolder").transform;
        nextFireTime = timer + 1f/fireRate;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextFireTime)
        {
            //Debug.Log(timer + "");
            Shoot();
            nextFireTime = timer + 1f / (fireRate * Singleton.singleton.spawnerSpeedScale);
        }
        

        // Horizontal movement
        
    }

    void Shoot()
    {
        // Perform raycast towards the player
        float shipRotation = firePoint.eulerAngles.z + 90f;
        float bulletRotation = shipRotation; 

        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.transform.SetParent(bulletHolder);
        Transform ship = null;
        
        
        if(GameObject.Find("PlayerShip") != null)
        {   
            //Debug.Log("Found ship");
            ship = GameObject.Find("PlayerShip").transform;
        }
        if (bullet != null && ship != null && launchID == 1)
        {
            //Debug.Log("Launch towards");
            bullet.LaunchTowards(ship);
        }
        else if (bullet != null && launchID != 1)
        {
            //Debug.Log("Launch");
            bullet.Launch(bulletRotation);
        }
        if (ship == null) Debug.Log("No ship lol");
        if (bullet == null) Debug.Log("No bullet lol");

    }
}
