using UnityEngine;

public class Catapult : MonoBehaviour
{
  public GameObject projectile;
  public bool rotated = false;
  public bool ready = false;
  public string inputButtonName = "Plunger";

  private Vector3 rotationVector;
  private Vector3 releaseVector;
  private bool maxTensionReached = false;
  private bool released = false;
  private bool canRelease = false;
  private float releaseRotation;

  void Start()
  {
    rotationVector = new Vector3(0, .25f, 0);
    releaseVector = new Vector3(0, -20f, 0);
  }

  // TODO: Decouple the arm rotation from framerate
  // TODO: Handle inputs correctly
  void Update()
  {
    if (Input.GetButton(inputButtonName) && !maxTensionReached && !released && ready)
    {
      canRelease = true;
      transform.Rotate(rotationVector, Space.Self);

      if (transform.rotation.eulerAngles.x < 272)
      {
        maxTensionReached = true;
      }
    }
    else if (Input.GetButtonUp(inputButtonName) && canRelease)
    {
      released = true;
      maxTensionReached = false;
      canRelease = false;
      releaseRotation = transform.rotation.eulerAngles.x;
    }

    if (released)
    {
      transform.Rotate(releaseVector, Space.Self);

      if (transform.rotation.eulerAngles.x >= 320)
      {
        released = false;
        ready = false;
        projectile.GetComponent<Projectile>().Launch(releaseRotation);
      }
    }
  }
}
