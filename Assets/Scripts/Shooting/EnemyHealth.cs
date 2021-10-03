using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    private Animator ac;

    private void Start()
    {
        ac = GetComponent<Animator>();
        if (ac == null)
        {
            Debug.LogWarning("Enemy " + gameObject.name + " did not have an Animator");
        } else
        {
            ac.SetFloat("IdleOffset", Random.Range(0, 1f));
        }
    }

    public void takeDamage(int damage)
    {
        ac.SetTrigger("Damage");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Destroyed " + gameObject.name);
        Destroy(gameObject);
    }
}
