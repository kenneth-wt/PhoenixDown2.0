using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newpartical : MonoBehaviour
{

    public ParticleSystem particleEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Instantiate(particleEffect, collision.contacts[0].point, Quaternion.identity);

           
        }

    }
}

