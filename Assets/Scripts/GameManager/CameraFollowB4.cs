using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowB4 : MonoBehaviour
{
    public Transform mainBall;
    public float smoothSpeed = 0.125f;
    public float followZThreshold = -2;
    public float zOffset = -10f; // Added Z offset for smoother follow behind the target

    private Transform currentTarget;
    private float startingY = 18f;
    private bool cameraReset = false;
    private Vector3 currentVelocity; // For SmoothDamp use

    void Awake()
    {
        currentTarget = mainBall;

        // Move the camera to the correct Z position at the start, with the given offset
        if (currentTarget.position.z > followZThreshold)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, currentTarget.position.z + zOffset);
        }
    }

    void LateUpdate()
    {
        if (currentTarget.position.z >= followZThreshold && !cameraReset)
        {
            // Assign the target's position directly to the desired position vector
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, currentTarget.position.z + zOffset);

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
        else if (cameraReset)
        {
            // Reset camera's Y and Z axis with smooth transition
            Vector3 desiredPosition = new Vector3(transform.position.x, startingY, currentTarget.position.z + zOffset);

            // Smoothly reset the camera's position
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

            // Force the Y position to the starting value
            transform.position = new Vector3(smoothedPosition.x, startingY, smoothedPosition.z);

            // Reset the flag after the camera reset
            cameraReset = false;
        }
    }

    // Call this to reset the camera back to the main ball
    public void ResetCamera()
    {
        currentTarget = mainBall;
        cameraReset = true;
    }
}

