using UnityEngine;

public class Pull : MonoBehaviour
{
  public string inputButtonName = "Plunger";

  // Distance that plunger will draw back
  public float distance;

  // Speed at which the plunger will draw back
  public float speed;

  // Power of release
  public float power;
  public GameObject[] flippers;

  private GameObject ball;
  private bool ready = false;
  private bool fire = false;
  private float moveCount = 0f;
  private Vector3 startingPosition;

  private void Awake()
  {
    ball = GameObject.FindGameObjectWithTag("Ball");
    startingPosition = transform.position;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      ready = true;
    }
  }

  private void Update()
  {
    if (Input.GetButton(inputButtonName))
    {
      // As the button is held down, slowly move the piece
      if (moveCount < distance)
      {
        transform.Translate(0f, 0f, -speed * Time.deltaTime);
        moveCount += speed * Time.deltaTime;
        fire = true;

        foreach (GameObject flipper in flippers)
        {
          flipper.GetComponent<Collider>().enabled = false;
        }
      }
    }
    else if (moveCount > 0)
    {
      // Shoot the ball
      if (fire && ready)
      {
        ball.transform.TransformDirection(Vector3.forward * 10);
        ball.GetComponent<Rigidbody>().AddForce(0f, 0f, moveCount * power);
        fire = false;
        ready = false;
      }

      // Once we have reached the starting position, fire off the ball
      transform.Translate(0f, 0f, 20f * Time.deltaTime);
      moveCount -= 20f * Time.deltaTime;
    }

    // Reset state
    if (moveCount <= 0)
    {
      transform.position = startingPosition;
      fire = false;
      moveCount = 0f;
    }
  }
}