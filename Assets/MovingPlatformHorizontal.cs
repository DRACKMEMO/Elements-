using UnityEngine;
using System.Collections; // Needed for using IEnumerator

public class MovingPlatformHorizontal : MonoBehaviour
{
    public Transform point1; // Horizontal start position
    public Transform point2; // Horizontal end position
    public float speed = 2f;
    public float startDelay = 30f; // Delay before starting movement

    private Vector3 targetPosition;
    private bool isMoving = false; // Flag to check if movement should start

    void Start()
    {
        // Start the coroutine to handle the delay
        StartCoroutine(StartMovementAfterDelay(startDelay));
    }

    private IEnumerator StartMovementAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // After the delay, set the initial target position and allow movement
        targetPosition = point2.position;
        isMoving = true; // Set the flag to true to indicate movement can start
    }

    void Update()
    {
        // Only move if the platform is allowed to move
        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the platform reaches the target position, switch the target
            if (transform.position == targetPosition)
            {
                targetPosition = (targetPosition == point1.position) ? point2.position : point1.position;
            }
        }
    }
}