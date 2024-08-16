using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform mainBall;
  public Transform projectile;
  public Transform catapultSequence;
  public float smoothSpeed = 0.125f;
  public float followZThreshold = -2;

  private Transform currentTarget;
  private bool followingCatapult = false;
  private float startingY = 20;
  private bool cameraReset = false;

  void Awake()
  {
    currentTarget = mainBall;

    if (currentTarget.position.z > followZThreshold)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, currentTarget.position.z);
    }
  }

  void LateUpdate()
  {
    if (currentTarget.position.z >= followZThreshold && !cameraReset) 
    {
      // Assign the target's position directly to the desired position vector
      Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, currentTarget.position.z);

      // Smoothly move the camera towards the desired position
      Vector3 smoothedPosition = Vector3.Lerp(transform.position, followingCatapult ? currentTarget.position : desiredPosition, smoothSpeed);

      // Set the camera's position to the smoothed position
      transform.position = smoothedPosition;
    } else if (cameraReset)
    {
      Vector3 desiredPosition = new Vector3(transform.position.x, startingY, currentTarget.position.z);

      Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

      smoothedPosition.y = startingY;
      transform.position = smoothedPosition;
      cameraReset = false;
    }
  }

  public void CatapultFollow()
  {
    currentTarget = projectile;

    StartCoroutine(WaitToFollowCatapultSequeunce());
  }

  IEnumerator WaitToFollowCatapultSequeunce()
  {
    yield return new WaitForSeconds(3f);

    currentTarget = catapultSequence;
    followingCatapult = true;
  }

  public void ResetCamera()
  {
    currentTarget = mainBall;
    followingCatapult = false;
    cameraReset = true;
  }
}