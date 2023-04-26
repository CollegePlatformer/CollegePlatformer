using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float lerpSpeed = 1.0f; // Speed of the lerp
    public float yOffsetRange = 10f; // Maximum random offset from the original y position

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private bool isLerpingForward = true; // flag to track the direction of the lerp
    private const float epsilon = 0.1f; // small value used to avoid overshooting the target position

    public Vector3 rotationSpeed = new Vector3(2, 10, 3);

    private void Start()
    {
        originalPosition = transform.position;
        float yOffset = Random.Range(-yOffsetRange, yOffsetRange);
        targetPosition = originalPosition + new Vector3(0.0f, yOffset, 0.0f);
    }

    private void Update()
    {
        // Calculate the next position based on the current direction of the lerp
    Vector3 nextPosition;
    if (isLerpingForward)
    {
        nextPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
    }
    else
    {
        nextPosition = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * lerpSpeed);
    }
    
    // Check if we have reached the target position or the original position
    if ((nextPosition - targetPosition).magnitude < epsilon)
    {
        isLerpingForward = false; // flip the direction of the lerp
    }
    else if ((nextPosition - originalPosition).magnitude < epsilon)
    {
        isLerpingForward = true; // flip the direction of the lerp
    }

    // Update the position of the gameobject
    transform.position = nextPosition;

    transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
