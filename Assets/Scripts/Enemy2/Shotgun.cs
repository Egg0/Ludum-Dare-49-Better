using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform bulletSpot;
    public GameObject bullet;
    public float delay = 0.5f;
    public float velocity = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // Target player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        StartCoroutine(shootAfterDelay());
    }


    IEnumerator shootAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        AudioManager.instance.Play("Shotgun");

        // Shoot in 3 directions
        GameObject bullet1 = Instantiate(bullet, transform, false);
        bullet1.transform.parent = null;
        bullet1.transform.position = bulletSpot.transform.position;

        GameObject bullet2 = Instantiate(bullet, transform, false);
        bullet2.transform.parent = null;
        bullet2.transform.position = bulletSpot.transform.position;
        bullet2.transform.Rotate(0, 0, 30);

        GameObject bullet3 = Instantiate(bullet, transform, false);
        bullet3.transform.parent = null;
        bullet3.transform.position = bulletSpot.transform.position;
        bullet3.transform.Rotate(0, 0, -30);

        Destroy(transform.parent.gameObject);
    }
}
