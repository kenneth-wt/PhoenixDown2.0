using UnityEngine;

public class Catapult_Static : MonoBehaviour
{
    public GameObject projectile; // This will be set by the trigger script
    public bool ready = false;
    public float launchPower = 30f; // Set this to the desired launch power

    private Vector3 releaseVector;
    private bool released = false;

    void Start()
    {
        releaseVector = new Vector3(0, -20f, 0);
    }

    void Update()
    {

    }

    public void LaunchBall()
    {
        if (ready && projectile != null)
        {
            released = true;
            projectile.GetComponent<Projectile_Static>().Launch(launchPower);
        }
    }
}



