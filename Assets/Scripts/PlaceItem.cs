using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceItem : MonoBehaviour
{
    public GameObject required;
    private Text instruction;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if (gameObject.name == "Escaleras")
            {
                instruction = GameObject.Find("Instructions").GetComponent<Text>();
                instruction.text = "Click on the stairs in your inventory to place them";
            }
        }
        else if (other.gameObject.name.Contains(required.name))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (gameObject.name == "Escaleras")
            {
                instruction = GameObject.Find("Instructions").GetComponent<Text>();
                instruction.text = "";
            }
        }
    }
}
