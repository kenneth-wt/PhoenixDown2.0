using UnityEngine;

public class AltarEntry : MonoBehaviour
{
  public GameObject floor;
  public GameObject bottomOrbit;
  void OnTriggerEnter(Collider other)
  {
    Rigidbody rb = other.GetComponent<Rigidbody>();
    rb.constraints = RigidbodyConstraints.None;

    GetComponent<Collider>().enabled = false;
    bottomOrbit.GetComponent<Collider>().enabled = true;
    floor.GetComponent<Collider>().enabled = false;
    floor.GetComponent<MeshRenderer>().enabled = false;

    Physics.gravity = new Vector3(0, -50, 0);
  }
}
