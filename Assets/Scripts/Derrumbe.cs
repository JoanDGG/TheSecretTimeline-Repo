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
            other.gameObject.GetComponent<MoveTime>().enabled = true;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        StartCoroutine(Wait5());
    }

    private IEnumerator Wait5()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(false);
    }
}
