using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public int maxHealth = 100;
    public int damage = 15;
    public float velocity = 5f;

    private EnemyHealth myHealth;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        myHealth = GetComponent<EnemyHealth>();
        myHealth.health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        AudioManager.instance.Play("Pig");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1f * velocity, 0);
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
