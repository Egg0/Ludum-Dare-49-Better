using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity;
    public float jumpForce;
    private bool isGrounded;
    
    public LayerMask GroundMask;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Debug.Log("Initialized player man");
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if (movement != 0) {
            rb.velocity = new Vector2(velocity * movement, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Raycast to check grounded
        RaycastHit2D raycast = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 0.1f, GroundMask);
        isGrounded = raycast.collider != null;

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            
            rb.velocity += Vector2.up * jumpForce;
        }
    }
}
