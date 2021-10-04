using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Like bullet, but stronger and piercing (and slower)
public class Missile : MonoBehaviour
{
    public float speed = 35f;
    public int damage = 30;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        AudioManager.instance.Play("MissileLaunch");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            //Collided with stable or bounds: Destroy
            if (collision.tag == "Stable")
            {
                AudioManager.instance.Play("MissileCollide");
                Destroy(gameObject);
            }
        } else if (collision.tag == "Bounds")
        {

            Destroy(gameObject);
        }
    }
}
