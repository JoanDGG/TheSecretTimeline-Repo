using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private SpriteRenderer sprRenderer;
    public Dialogue[] dialogue = new Dialogue[2];
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
            if((GameManager.scene == 2 && !GameManager.story1)
                || (GameManager.scene == 5 && !GameManager.story2)
                || (GameManager.scene == 8 && !GameManager.story3 && gameObject.name == "Guard")
                || (GameManager.scene == 8 && !GameManager.story4 && gameObject.name == "James")
                || (GameManager.scene == 8 && !GameManager.story5 && gameObject.name == "Amy"))
            {
                Talk.GetComponent<DialogueTrigger>().dialogue = dialogue[0];
                if(!GameManager.story2 && gameObject.name == "Martin")
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                Talk.GetComponent<DialogueTrigger>().dialogue = dialogue[1];
            }
            
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
