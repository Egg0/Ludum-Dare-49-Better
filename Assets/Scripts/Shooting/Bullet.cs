using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
