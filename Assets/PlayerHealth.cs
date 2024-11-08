using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // The player's current health
    public float currentHealth = 100f;

    // The UI text component that displays the player's health
    public TMP_Text healthText;

    void Start()
    {
        // Initialize the health text with the current health
        healthText.text = "Health: " + currentHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce the player's health by the damage amount
        currentHealth -= damage;

        // Clamp the health to ensure it doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);

        // Update the health text with the new health value
        healthText.text = "Health: " + currentHealth;

        // If the player's health reaches 0, game over!
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}