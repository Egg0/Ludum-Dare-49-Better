using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireDelay; // Time between shots

    private float timeOfLastShot;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOfLastShot + fireDelay && Input.GetAxisRaw("Fire1") > 0)
        {
            timeOfLastShot = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
