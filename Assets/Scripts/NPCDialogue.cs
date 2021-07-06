using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private SpriteRenderer sprRenderer;
    public Dialogue dialogue;
    public GameObject Talk;
            
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Color tmp = sprRenderer.color;
            tmp.a = 0.5f;
            sprRenderer.color = tmp;
            Talk.SetActive(true);
            Talk.GetComponent<DialogueTrigger>().dialogue = dialogue;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color tmp = sprRenderer.color;
            tmp.a = 1;
            sprRenderer.color = tmp;
            Talk.SetActive(false);
        }
    }
}
