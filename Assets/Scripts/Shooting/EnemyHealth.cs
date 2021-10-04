using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem DeathParticles;
    public List<GameObject> Pickups;

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
        // Have a 40% chance of dropping a pickup
        if (Pickups.Count > 0 && Random.Range(0, 1f) > 0.6f)
        {
            GameObject choice = Pickups[Random.Range(0, Pickups.Count)];
            Instantiate(choice, transform.position, choice.transform.rotation);
        }

        Debug.Log("Destroyed " + gameObject.name);
        AudioManager.instance.Play("Death");
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        cam.TriggerShake(0.1f, 0.2f, false);
        Destroy(transform.parent.gameObject);
    }
}
