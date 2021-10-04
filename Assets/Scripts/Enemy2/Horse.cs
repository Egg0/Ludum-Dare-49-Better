using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public int maxHealth = 50;
    public int damage = 10;
    public float velocity = 10f;

    private EnemyHealth myHealth;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        myHealth = GetComponent<EnemyHealth>();
        myHealth.health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        AudioManager.instance.Play("Horse");
        movement = new Vector2(-1f * velocity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movement;
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
