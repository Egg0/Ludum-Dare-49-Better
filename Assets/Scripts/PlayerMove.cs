using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocity;
    public float jumpForce;
    public LayerMask GroundMask;
    public BoolSO victory;

    public SpriteRenderer sprite;
    private Vector2 initialScale;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool m_FacingRight;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        m_FacingRight = true;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0;
        if (!victory.active)
        {
            movement = Input.GetAxisRaw("Horizontal");
        }

        if (movement != 0) {
            rb.velocity = new Vector2(velocity * movement, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Raycast to check grounded
        RaycastHit2D raycast = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 0.1f, GroundMask);
        isGrounded = raycast.collider != null;

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            
            rb.velocity += Vector2.up * jumpForce;
        }

        if (movement > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        // Crouch
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale = new Vector2(initialScale.x, initialScale.y * 0.5f);
        } else
        {
            transform.localScale = initialScale;
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
