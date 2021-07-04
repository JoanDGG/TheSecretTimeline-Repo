using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Alive = false;
            this.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            print("Game over");
        }
    }

}

