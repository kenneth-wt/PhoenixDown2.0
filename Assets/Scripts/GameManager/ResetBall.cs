using UnityEngine;

public class ResetBall : MonoBehaviour
{
  private GameObject ball;
  private Vector3 startingPosition;
    void Awake()
    {
      ball = GameObject.FindGameObjectWithTag("Ball");
      startingPosition = ball.transform.position;
    }

    void OnTriggerEnter()
    {
      ball.transform.position = startingPosition;
      ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
      ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
