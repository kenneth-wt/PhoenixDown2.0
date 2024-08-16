using UnityEngine;

public class Plunger : MonoBehaviour
{
  public float minAngle = -30f;
  public float maxAngle = 30f;

  private bool rotateClockwise = false;
  private bool rotateCounterClockwise = false;

  private string clockwiseRotationInputButtonName = "ClockwiseRotatePlunger";
  private string counterClockwiseRotationInputButtonName = "CounterClockwiseRotatePlunger";
 
  // TODO: Lock ball in place while plunger is being pulled back
  void Update()
  {
    // Check for input to rotate clockwise or counterclockwise
    if (Input.GetButton(counterClockwiseRotationInputButtonName))
    {
      if (transform.rotation.y >= minAngle)
      {
        rotateClockwise = true;
        rotateCounterClockwise = false;
      } else {
        rotateClockwise = false;
      }
    }
    else if (Input.GetButton(clockwiseRotationInputButtonName))
    {
      if (transform.rotation.y <= maxAngle)
      {
        rotateCounterClockwise = true;
        rotateClockwise = false;
      } else {
        rotateCounterClockwise = false;
      }
    }
    else
    {
      rotateClockwise = false;
      rotateCounterClockwise = false;
    }
  }

  void FixedUpdate()
  {
    // Rotate the object based on input
    if (rotateClockwise)
    {
      RotateObject(-0.5f);
    }
    else if (rotateCounterClockwise)
    {
      RotateObject(0.5f);
    }
  }

  void RotateObject(float direction)
  {
    transform.Rotate(0f, direction, 0f);
  }
}
