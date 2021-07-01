using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Game over");
        }
    }

}

