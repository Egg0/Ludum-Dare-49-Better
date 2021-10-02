using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyObject" | collision.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("Player took damage. YEOUCH!");
        }
    }
}
