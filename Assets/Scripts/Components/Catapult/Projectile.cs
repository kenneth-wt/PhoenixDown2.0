using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject launchVector;
    private float minRelease = 325;
    private float maxRelease = 267;
    private float minForce = 10f;
    private float maxForce = 40f;
    public Transform resetPosition;

    private Transform startingParent;

    void Start()
    {
        startingParent = transform.parent;
    }

    public void Launch(float releasePoint)
    {
        GetComponent<Rigidbody>().isKinematic = false;

        float i = releasePoint - minRelease;
        float j = maxRelease - minRelease;
        float t = i / j;
        float force = Mathf.Lerp(minForce, maxForce, t);

        GetComponent<Rigidbody>().AddForce(launchVector.transform.forward * force, ForceMode.Impulse);
        transform.parent = null;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // If it hits the target, move to the next catapult
            gameManager.GetComponent<CatapultSequence>().RegisterHit();
        }
        else
        {
            // If missed, reset the projectile and catapult
            Reset();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // If it hits the target, move to the next catapult
            gameManager.GetComponent<CatapultSequence>().RegisterHit();
        }
        else
        {
            // If missed, reset the projectile and catapult
            Reset();
        }
    }

    public void Reset()
    {
        // Reset the projectile's state
        gameObject.SetActive(true);
        transform.position = resetPosition.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // Ensure the Rigidbody is kinematic so the projectile doesn't move until launched again
        GetComponent<Rigidbody>().isKinematic = true;

        // Parent the projectile back to the catapult
        transform.parent = startingParent;

        // Get the Catapult component from the parent object and set 'ready' to true to allow another shot
        Catapult parentCatapult = startingParent.GetComponent<Catapult>();
        if (parentCatapult != null)
        {
            parentCatapult.ready = true;
        }
    }
}

