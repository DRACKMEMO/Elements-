using UnityEngine;
using UnityEngine.UI;

public class HealthbarSystem : MonoBehaviour
{
    public int defaultHealth = 100; // Default health.
    private int currentHealth; // Current health.

    public Image healthbarImage; // Healthbar UI element for Player 1.
    public Image healthbarImage2; // Healthbar UI element for Player 2.
    public HealthReducer[] healthReducers; // Array to store obstacles and enemies.

    void Start()
    {
        currentHealth = defaultHealth; // Initialize current health.
        UpdateHealthbar(); // Initialize healthbar image.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (HealthReducer reducer in healthReducers) // Check if the collision is with an obstacle or enemy.
        {
            if (collision.gameObject.CompareTag(reducer.tag))
            {
                // Reduce health
                ReduceHealth(reducer.healthReduction);
                break;
            }
        }
    }

    public void ReduceHealth(int amount)
    {
        // Reduce current health
        currentHealth -= amount;

        // Ensure health doesn't go below zero
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update healthbar image
        UpdateHealthbar();

        // Check if health is zero
        if (currentHealth <= 0)
        {
            // Game over logic here
            Debug.Log("Game Over!");
        }
    }

    void UpdateHealthbar()
    {
        // Calculate the health percentage and update the image fill amount
        float healthPercentage = (float)currentHealth / defaultHealth;
        healthbarImage.fillAmount = healthPercentage; // Assuming the Image component's type is set to "Filled" with "Fill Method" set to "Horizontal" or "Vertical"
    }

    public void UpdateHealthbarForPlayer2(int player2CurrentHealth)
    {
        // Calculate the health percentage for Player 2 and update the image fill amount
        float healthPercentage2 = (float)player2CurrentHealth / defaultHealth;
        healthbarImage2.fillAmount = healthPercentage2; // Update Player 2 healthbar
    }

    [System.Serializable]
    public struct HealthReducer
    {
        public string tag;
        public int healthReduction;
    }
}