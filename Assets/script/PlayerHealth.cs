using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public float enemyCooldownDuration = 3f; // Cooldown duration for enemies damaging the player
    private float enemyCooldownTimer = 0f; // Timer for enemy cooldown

    public Image[] hearts;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        // Decrease enemy cooldown timer if it's active
        if (enemyCooldownTimer > 0f)
        {
            enemyCooldownTimer -= Time.deltaTime;
        }
        if (currentHealth <= 0)
        {
            RespawnPlayer(); // Respawn the player if health is zero or below
        }
    }

    public void TakeDamage(int damage)
    {
        // Check if enemy cooldown is active
        if (enemyCooldownTimer <= 0f)
        {
            currentHealth -= damage;
            UpdateHealthUI(); // Update health UI after taking damage

            // Set the enemy cooldown timer when the player takes damage
            enemyCooldownTimer = enemyCooldownDuration;
        }
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeartSprite;
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
            }
        }
    }

    void RespawnPlayer()
    {
        currentHealth = maxHealth; // Reset player health
        transform.position = new Vector3(38f, 4.51f, 40.5f); // Teleport player to respawn position
        UpdateHealthUI();
    }
}