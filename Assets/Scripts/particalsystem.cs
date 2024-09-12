using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particalsystem : MonoBehaviour
{
    // Reference to your particle system
    public ParticleSystem particleEffect;

    // This method is called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check for specific collision conditions if necessary, or activate on any collision
        if (collision.gameObject.CompareTag("Ball")) // Adjust "Target" to the tag of the object you want to trigger the effect on
        {
            // Instantiate and play the particle system at the point of collision
            Instantiate(particleEffect, collision.contacts[0].point, Quaternion.identity);

            // Optionally, you can also destroy the particle system after a certain time
            //Destroy(particleEffect.gameObject, particleEffect.main.duration);
        }
    }
}
