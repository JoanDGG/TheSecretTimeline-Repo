using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derrumbe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "T_rex")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Collapse");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
