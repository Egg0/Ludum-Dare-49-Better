using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public BoolSO playerDeath;
    private Animator ac;
    private CameraShake cam;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        ac = GetComponentInChildren<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(20);
            Debug.Log(currentHealth);
        }
    }

    public void takeDamage(int damage)
    {
        ac.SetTrigger("Damage");
        cam.TriggerShake(0.1f, 0.2f, false);

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (playerDeath != null)
            playerDeath.active = true;
        Destroy(gameObject);
    }
}
