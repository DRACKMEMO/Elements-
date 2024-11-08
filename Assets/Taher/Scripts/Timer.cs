using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]  Text timerText; // Reference to the UI Text component
    [SerializeField] private float remainingTime; // Time in seconds
    private bool timerIsRunning = false; // Flag to check if the timer is running

    void Start()
    {
        StartTimer(); // Start the timer when the game starts
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime; // Decrease remaining time
                UpdateTimerText(); // Update the UI text
            }
            else
            {
                remainingTime = 0; // Ensure remaining time does not go negative
                timerIsRunning = false; // Stop the timer
                timerText.color = Color.red; // Change text color to red when time is up
                TimerEnded(); // Call a method when the timer ends
            }
        }
    }

    private void UpdateTimerText()
    {
        // Display remaining time as whole seconds
        timerText.text = Mathf.Ceil(remainingTime).ToString(); // Update the timer text to show seconds
    }

    public void StartTimer()
    {
        timerIsRunning = true; // Set the flag to true to start the timer
    }

    public void ResetTimer(float newTime)
    {
        remainingTime = newTime; // Reset the remaining time to a new value
        timerText.color = Color.white; // Reset text color to default
        UpdateTimerText(); // Update the displayed timer text
        timerIsRunning = true; // Start the timer
    }

    private void TimerEnded()
    {
        // Handle what happens when the timer ends
        Debug.Log("Timer has ended!");
        // You can add more logic here, like showing a game over screen or restarting the level
    }
}