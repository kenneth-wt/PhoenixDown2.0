using UnityEngine;

public class CatapultRotate : MonoBehaviour
{
  public bool shouldRotate = false;

  void Update()
  {
    if (shouldRotate)
    {
      transform.Rotate(new Vector3(0, 90f, 0) * Time.deltaTime, Space.Self);

      // TODO: Clean up this magic number
      if (transform.rotation.y > 0.7071068)
      {
        shouldRotate = false;
      }
      
      GetComponentInChildren<Catapult>().rotated = true;
    }
  }
}
