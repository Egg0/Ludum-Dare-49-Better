using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Tracks teh boss health and updates the health bar
public class PlayerHealthUI : MonoBehaviour
{
    public Image HealthBar;
    public PlayerHealth playerHealth;
    private float maxHealth;

    private Color greenHealth = new Color(85f / 255f, 1, 102f / 255f);
    private Color yellowHealth = new Color(1, 246f / 255f, 45f / 255f);
    private Color redHealth = new Color(1, 40f / 255f, 0);


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerHealth.maxHealth;
        HealthBar.color = greenHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float percentHealth = playerHealth.currentHealth / maxHealth;
        HealthBar.fillAmount = percentHealth;

        if (percentHealth < 0.25f)
        {
            HealthBar.color = redHealth;
        }
        else if (percentHealth < 0.5f)
        {
            HealthBar.color = yellowHealth;
        }


    }
}