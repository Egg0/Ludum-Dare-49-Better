using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public BoolSO playerDeath;
    private Animator ac;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        ac = GetComponentInChildren<Animator>();
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
