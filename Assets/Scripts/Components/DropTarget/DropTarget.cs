using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTarget : MonoBehaviour
{
    // Adjust this tag to match your ball's tag in the Unity Editor
    public GameObject DropTargetSpace;
    private bool droptargetFall;
    public string ballTag = "Ball";

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the ball
         if (collision.gameObject.CompareTag(ballTag))
        {
            // Optional: Add any effects or sounds here before disabling the collider

            // Destroy this drop target GameObject
            // Destroy(gameObject);

            // Disable the collider component
            droptargetFall = !droptargetFall;
            DropTargetSpace.GetComponent<Animator>().SetBool("IsFall", droptargetFall);

            GetComponent<Collider>().enabled = false;

            // Optional: Start any animations or further processing here
        }
    }
}

