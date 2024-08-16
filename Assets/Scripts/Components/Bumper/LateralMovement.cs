using UnityEngine;

// Shifts an object between two points
public class LateralMovement : MonoBehaviour
{
  public GameObject leftPointBoundary;
  public GameObject rightPointBoundary;
  public float boundaryOffset;
  public float speed = 1.0f;
  public bool isMovingRight;
  public float initiatePauseTimerMaxDuration;
  public float pauseTimerMaxDuration;
  public bool pauseEnabled = false;

  private Vector3 leftPointMax;
  private Vector3 rightPointMax;
  private bool isPaused = false;
  private float pauseDuration;
  private float pauseTimer;
  private float initiatePauseTimer;
  private float initiatePauseTimerDuration;
  private bool initiatePauseTimerSet;

  void Start()
  {
    leftPointMax = new Vector3(leftPointBoundary.transform.position.x + boundaryOffset, transform.position.y, transform.position.z);
    rightPointMax = new Vector3(rightPointBoundary.transform.position.x - boundaryOffset, transform.position.y, transform.position.z);

    if (isMovingRight)
    {
      transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    else
    {
      transform.rotation = Quaternion.Euler(0, -90, 0);
    }
  }

  void Update()
  {
    if (pauseEnabled)
    {
      if (!initiatePauseTimerSet && !isPaused)
      {
        initiatePauseTimerDuration = Random.Range(1.0f, initiatePauseTimerMaxDuration);
        initiatePauseTimerSet = true;
      }
      else if (!isPaused)
      {
        initiatePauseTimer += Time.deltaTime;
        if (initiatePauseTimer >= initiatePauseTimerDuration)
        {
          // Set a new pause duration
          pauseDuration = Random.Range(1.0f, pauseTimerMaxDuration);
          isPaused = true;
        }
      }
    }
    
    if (!isPaused)
    {
      // Calculate the target position based on the current direction
      Vector3 targetPosition = isMovingRight ? rightPointMax : leftPointMax;

      // Move the object towards the target position
      transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

      // Check if the object has reached the target position
      if (transform.position == targetPosition)
      {
        // Reverse the direction
        isMovingRight = !isMovingRight;
        if (isMovingRight)
        {
          transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
          transform.rotation = Quaternion.Euler(0, -90, 0);
        }
      }
    }
    else
    {
      // Increment the pause timer
      pauseTimer += Time.deltaTime;

      // Check if the pause duration has elapsed
      if (pauseTimer >= pauseDuration)
      {
        pauseTimer = 0.0f;
        initiatePauseTimer = 0.0f;

        isMovingRight = Random.value > 0.5f;
        
        // Resume movement
        isPaused = false;
        initiatePauseTimerSet = false;
      }
    }
  }
}