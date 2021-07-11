using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCItem : MonoBehaviour
{
    public Dialogue dialogueAccept;
    public Dialogue dialogueDenied;

    public GameObject required;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Contains(required.name))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueAccept);
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            if (gameObject.name == "Kevin") {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (gameObject.name == "Dumbnald") {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (gameObject.name == "Soldier") {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag != "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueDenied);
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            Destroy(other.gameObject);
        }

    }
}
