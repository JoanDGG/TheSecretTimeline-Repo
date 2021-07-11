using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{

    private bool NearItem;
    public Text instruction;
    private GameObject Item;
    private bool pickup;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NearItem && Input.GetKeyDown("e"))
        {
            pickup = false;
            if(Item.name == "Celular")
            {
                pickup = true;
            }
            else if (Item.name == "Huevo")
            {
                pickup = true;
            }
            else if (Item.name == "Roca")
            {
                Item.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (Item.name == "Bata")
            {
                pickup = true;
                GameManager.story3 = true;
            }
            else
            {
                if (Item.name == "Combustible")
                {
                    if(!GameManager.story1)
                    {
                        GameManager.story1 = true;
                    }
                    else
                    {
                        GameManager.story4 = true;
                    }
                }
                else if (Item.name == "Walkman")
                {
                    GameManager.story2 = true;
                }
                else if (Item.name == "Lightsaber")
                {
                    GameManager.story5 = true;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (GameManager.Inventory[i] == null)
                    {
                        GameManager.Inventory[i] = Item;
                        pickup = true;
                        break;
                    }
                }
            }
            if (pickup)
            {
                instruction.text = "You picked up " + Item.name;
                print("You picked up " + Item.name);
                Item.SetActive(false);
            }
            else
            {
                instruction.text = "You can not pick up " + Item.name;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        instruction = GameObject.Find("Instructions").GetComponent<Text>();
        if (other.gameObject.tag == "Item")
        {
            Item = other.gameObject;
            NearItem = true;
            instruction.text += "\nPress e to pick up item";
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            NearItem = false;
            instruction.text = "";
        }
    }
}