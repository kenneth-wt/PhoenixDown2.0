using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowB4 : MonoBehaviour
{
    public Transform mainBall;
    public float smoothSpeed = 0.125f;
    public float zOffset = -2f; // Offset for Z axis

    private Transform currentTarget;
    private float startingY = 20f;
    private bool cameraReset = false;
    private Vector3 currentVelocity; // For SmoothDamp use

    void Awake()
    {
        currentTarget = mainBall;

        // Initial position adjustment for Z-axis based on the ball's position
        transform.position = new Vector3(transform.position.x, transform.position.y, currentTarget.position.z + zOffset);
    }

    void LateUpdate()
    {
        if (!cameraReset)
        {
            // Desired position includes Z offset, following the ball on Z axis only
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, currentTarget.position.z + zOffset);

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

            // Update the camera position to the smoothed value
            transform.position = smoothedPosition;
        }
        else if (cameraReset)
        {
            // Desired position during reset, keep X and Z but reset Y to startingY
            Vector3 desiredPosition = new Vector3(transform.position.x, startingY, currentTarget.position.z + zOffset);

            // Smoothly reset the camera's position
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

            // Ensure Y is locked to startingY
            transform.position = new Vector3(smoothedPosition.x, startingY, smoothedPosition.z);

            // Reset the cameraReset flag once the reset is complete
            cameraReset = false;
        }
    }

    // Function to reset the camera to follow the ball
    public void ResetCamera()
    {
        currentTarget = mainBall;
        cameraReset = true;

        // Instantly move the camera to the correct Z position to avoid getting stuck
        Vector3 immediatePosition = new Vector3(transform.position.x, startingY, mainBall.position.z + zOffset);
        transform.position = immediatePosition;
    }
}
