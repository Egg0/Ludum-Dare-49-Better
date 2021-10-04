using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool debug;
    public bool godmode;
    public int maxHealth = 100;
    public int currentHealth;
    public BoolSO playerDeath;
    public BoolSO playerVictory;
   
    private Animator ac;
    private CameraShake cam;

    public float invincibleTime = 1f;
    public float blinkDelay = 0.25f;
    private float timeOfNextBlink;
    private float invincibleTimeRemaining;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        ac = GetComponentInChildren<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Blink();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                takeDamage(20);
            }
        }

        if (invincibleTimeRemaining > 0)
        {
            invincibleTimeRemaining -= Time.deltaTime;
            if (Time.time > timeOfNextBlink)
            {
                Blink();
                timeOfNextBlink = Time.time + blinkDelay;
            }
        } else if (invincibleTimeRemaining < 0)
        {
            sprite.enabled = true;
            invincibleTimeRemaining = 0;
        }
    }

    public void takeDamage(int damage)
    {
        if (invincibleTimeRemaining > 0 || godmode || playerVictory.active) return;

        invincibleTimeRemaining = invincibleTime;
        timeOfNextBlink = Time.time + blinkDelay;

        ac.SetTrigger("Damage");
        AudioManager.instance.Play("PlayerHurt");
        cam.TriggerShake(0.1f, 0.2f, false);

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioManager.instance.Play("Death");
        if (playerDeath != null)
            playerDeath.active = true;
        Destroy(gameObject);
    }

    private void Blink()
    {
        sprite.enabled = !sprite.enabled;
    }
}
