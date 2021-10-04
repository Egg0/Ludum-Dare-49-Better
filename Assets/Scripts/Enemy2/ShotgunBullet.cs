using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    public int damage = 10;
    public float velocity = 15f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * -velocity;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player collision: Damage player
        if (collision.tag == "Player")
        {
            PlayerHealth pHealth = collision.GetComponent<PlayerHealth>();
            pHealth.takeDamage(damage);
        }

        // Bounds collision: Destroy this
        if (collision.gameObject.layer == LayerMask.NameToLayer("ScreenBounds"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
