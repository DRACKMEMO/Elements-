using UnityEngine;
using System.Collections;

public class DelayedPlatformMover : MonoBehaviour
{
    public Transform point1;      // Start position
    public Transform point2;      // End position
    public float speed = 1f;      // Movement speed
    public float startDelay = 30f; // Delay before movement starts

    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isInitialized = false;

    void Start()
    {
        // Ensure points are assigned and log initialization
        if (point1 == null || point2 == null)
        {
            Debug.LogError("Point1 and Point2 must be assigned for " + gameObject.name);
            return;
        }

        Debug.Log(gameObject.name + " is initializing and will wait for " + startDelay + " seconds.");

        // Start coroutine for delay
        StartCoroutine(StartMovementAfterDelay());
    }

    IEnumerator StartMovementAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(startDelay);

        // Start moving and initialize target
        isMoving = true;
        isInitialized = true;
        targetPosition = point1.position; // Set initial target to point1

        Debug.Log(gameObject.name + " has started moving.");
    }

    void Update()
    {
        // Log if Update is running without initialization
        if (!isInitialized)
        {
            Debug.LogWarning(gameObject.name + " Update is running, but movement is not initialized yet.");
            return;
        }

        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the platform reaches the target position, switch the target
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // Small threshold for precision
            {
                targetPosition = (targetPosition == point1.position) ? point2.position : point1.position;
                Debug.Log(gameObject.name + " reached a waypoint and is switching targets.");
            }
        }
    }
}
