using UnityEngine;

public class PanCamera : MonoBehaviour
{
  void Update()
  {
    if (Input.GetKey(KeyCode.P)) {
      transform.position += new Vector3(0, 0, .1f);
    }
  }
}
