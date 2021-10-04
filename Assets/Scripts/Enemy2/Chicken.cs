using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject egg;
    public int maxHealth = 30;
    public int damage = 5;
    public float velocity = 6f;
    public float eggTimer = 0.75f;

    private EnemyHealth myHealth;
    private Rigidbody2D rb;
    private float nextEggTime;

    // Start is called before the first frame update
    void Start()
    {
        myHealth = GetComponent<EnemyHealth>();
        myHealth.health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        AudioManager.instance.Play("Chicken");
        nextEggTime = Time.time + Random.Range(0, nextEggTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1f * velocity, 0);

        if (Time.time > nextEggTime)
        {
            Instantiate(egg, transform.position, transform.rotation);
            nextEggTime = Time.time + eggTimer;
        }
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
