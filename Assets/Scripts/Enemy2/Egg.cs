using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public int damage = 10;
    public float velocity = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioManager.instance.Play("Egg");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -1f * velocity);
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
