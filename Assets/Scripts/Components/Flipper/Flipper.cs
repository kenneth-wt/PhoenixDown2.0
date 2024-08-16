using UnityEngine;

public class Flipper : MonoBehaviour
{
  // Where the flipper sits when not in use
  public float restPosition;
  
  // Where the flipper sits at max extent of rotation
  public float pressedPosition;

  // Strength of force applied on activation
  public float flipperStrength;

  public float force;

  // Damping of return to rest position
  public float flipperDamper;
  public string inputButtonName;

  private new HingeJoint hingeJoint;

  private void Awake()
  {
    hingeJoint = GetComponent<HingeJoint>();
  }

  private void Update()
  {
    JointSpring spring = new JointSpring
    {
      spring = flipperStrength,
      damper = flipperDamper
    };

    if (Input.GetButton(inputButtonName))
    {
      spring.targetPosition = pressedPosition;
    }
    else
    {
      spring.targetPosition = restPosition;
    }

    hingeJoint.spring = spring;
    JointLimits limits = hingeJoint.limits;
    limits.min = restPosition;
    limits.max = pressedPosition;
    hingeJoint.limits = limits;
  }

  void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ball") && Input.GetButton(inputButtonName))
    {
      Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

      otherRigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
  }
}