using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitchfork : MonoBehaviour
{
    public int damage = 10;
    public float delay = 0.5f;
    public float velocity = 15f;
    private Rigidbody2D rb;
    private bool throwing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Target player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        StartCoroutine(throwAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (throwing)
            rb.velocity = transform.right * -velocity;
    }

    IEnumerator throwAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        AudioManager.instance.Play("Pitchfork");
        throwing = true;
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
