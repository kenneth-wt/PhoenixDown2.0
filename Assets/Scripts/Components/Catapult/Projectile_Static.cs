using UnityEngine;

public class Projectile_Static : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject launchVector;
    public Transform resetPosition;

    private Transform startingParent;

    void Start()
    {
        startingParent = transform.parent;
    }

    public void Launch(float force)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(launchVector.transform.forward * force, ForceMode.Impulse);
        transform.parent = null;

    }

    public void Reset()
    {
        gameObject.SetActive(true);
        transform.position = resetPosition.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = startingParent;

    }
}


