using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private SpriteRenderer sprRenderer;
    public GameObject Talk;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color tmp = sprRenderer.color;
        tmp.a = 0.5f;
        sprRenderer.color = tmp;
        Talk.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Color tmp = sprRenderer.color;
        tmp.a = 1;
        sprRenderer.color = tmp;
    }
}
