using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpdate : MonoBehaviour
{
    private Sprite currentSprite;
    private int Number;
    private Sprite itemSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = gameObject.GetComponent<Image>().sprite;
        Number = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1)) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Inventory[Number] != null)
        {
            itemSprite = GameManager.Inventory[Number].GetComponent<SpriteRenderer>().sprite;
            if (currentSprite != itemSprite)
            {
                gameObject.GetComponent<Image>().sprite = itemSprite;
            }
        }
    }
}