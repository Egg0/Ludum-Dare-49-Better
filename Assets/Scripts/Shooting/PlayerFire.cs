using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;

    public float bulletFireDelay; // Time between shots
    public float missileFireDelay;

    public int fireMode; // 0 = bullet, 1 = missile, 2 = shotgun
    public IntSO missileAmmo;

    private float timeOfLastShot;

    private void Start()
    {
        missileAmmo.count = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireMode == 0  && Time.time > timeOfLastShot + bulletFireDelay)
            {
                timeOfLastShot = Time.time;
                Shoot(bulletPrefab);
            } else if (fireMode == 1 && Time.time > timeOfLastShot + missileFireDelay)
            {
                timeOfLastShot = Time.time;
                Shoot(missilePrefab);
                missileAmmo.count--;
                if (missileAmmo.count <= 0) fireMode = 0;
            }
            
        }
    }

    void Shoot(GameObject bulletType)
    {
        Instantiate(bulletType, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MissileAmmo")
        {
            missileAmmo.count += 7;
            fireMode = 1;
            Destroy(collision.gameObject);
            AudioManager.instance.Play("Pickup");
        }
    }
}
