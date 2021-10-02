using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerObject")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                // They take 10 damage
                player.takeDamage(10);
                Debug.Log(player.name + " has " + player.currentHealth);
            }
            Destroy(gameObject);
        }
    }
}
