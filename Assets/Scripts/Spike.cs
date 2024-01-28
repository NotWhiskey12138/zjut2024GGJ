using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>())
            {
                other.GetComponent<PlayerController>().PlayerDead();
            }
            
            if (other.GetComponent<PlayerTwoController>())
            {
                other.GetComponent<PlayerTwoController>().PlayerDead();
            }
        }
    }
}
