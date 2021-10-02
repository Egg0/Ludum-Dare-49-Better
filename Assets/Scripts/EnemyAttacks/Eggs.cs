using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 10;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * -1 * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.name);
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.takeDamage(damage);
            Debug.Log(player.name + " has " + player.currentHealth);
        }
        Destroy(gameObject);
    }
}
