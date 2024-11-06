using UnityEngine;

public class SimplePlatformMover : MonoBehaviour
{
    public Transform point1; // First position (drag and drop in the inspector)
    public Transform point2; // Second position (drag and drop in the inspector)
    public float speed = 2f; // Speed at which the platform moves

    private Vector3 targetPosition;

    void Start()
    {
        // Start by moving towards point 2
        targetPosition = point2.position;
    }

    void Update()
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
