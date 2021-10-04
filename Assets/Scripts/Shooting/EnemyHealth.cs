using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    private Animator ac;
    private CameraShake cam;

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
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    public void takeDamage(int damage)
    {
        ac.SetTrigger("Damage");
        AudioManager.instance.Play("Impact");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Destroyed " + gameObject.name);
        AudioManager.instance.Play("Death");
        cam.TriggerShake(0.1f, 0.2f, false);
        Destroy(gameObject);
    }
}
