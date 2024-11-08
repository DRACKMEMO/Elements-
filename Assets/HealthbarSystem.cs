using UnityEngine;
using UnityEngine.UI;

public class HealthbarSystem : MonoBehaviour
{
    public int defaultHealth = 100; // Default health.

    private int currentHealth; // Current health.

    public Slider healthbarSlider; // Healthbar UI element.

    public HealthReducer[] healthReducers; // Array to store obstacles and enemies.

    void Start()
    {
        currentHealth = defaultHealth; // Initialize current health.

        healthbarSlider.maxValue = defaultHealth; // Initialize healthbar slider.
        healthbarSlider.value = currentHealth;
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

    void ReduceHealth(int amount)
    {
        // Reduce current health
        currentHealth -= amount;

        // Update healthbar slider
        healthbarSlider.value = currentHealth;

        // Check if health is zero
        if (currentHealth <= 0)
        {
            // Game over logic here
            Debug.Log("Game Over!");
        }
    }

    [System.Serializable]
    public struct HealthReducer
    {
        public string tag;
        public int healthReduction;
    }
}