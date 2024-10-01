using UnityEngine;

public class LightActivator : MonoBehaviour
{
    // Two GameObjects whose colors will change when both LightActivators are hit.
    public GameObject targetObject1;
    public GameObject targetObject2;

    // Two GameObjects that will be disabled after color change.
    public GameObject objectToDisable1;
    public GameObject objectToDisable2;

    private bool isHit = false; // Tracks if this LightActivator has been hit.

    // Static variable tracks how many LightActivators have been hit.
    private static int hitCount = 0;

    void Start()
    {
        // Initialize the LightActivator status.
    }

    // Detect collision with the ball (tagged "Ball").
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isHit)
        {
            isHit = true;
            hitCount++;

            // Check if both LightActivators have been hit.
            if (hitCount >= 2)
            {
                // Change the color of the two target GameObjects to red.
                if (targetObject1 != null)
                {
                    Renderer targetRenderer1 = targetObject1.GetComponent<Renderer>();
                    if (targetRenderer1 != null)
                        targetRenderer1.material.color = Color.red;
                }

                if (targetObject2 != null)
                {
                    Renderer targetRenderer2 = targetObject2.GetComponent<Renderer>();
                    if (targetRenderer2 != null)
                        targetRenderer2.material.color = Color.red;
                }

                // Disable both GameObjects if required.
                if (objectToDisable1 != null)
                    objectToDisable1.SetActive(false);

                if (objectToDisable2 != null)
                    objectToDisable2.SetActive(false);
            }
        }
    }

    // Optional: Reset hitCount and status when restarting.
    public static void ResetActivators()
    {
        hitCount = 0;
    }
}
