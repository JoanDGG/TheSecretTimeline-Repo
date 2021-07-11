using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsage : MonoBehaviour
{
    private int Number;
    private GameObject Player;
    private GameObject inventoryItem;

    public void UseItem(int Number)
    {
        inventoryItem = GameObject.Find("InventoryItem" + (Number + 1).ToString());
        Player = GameObject.Find("Player");
        if (GameManager.Inventory[Number] != null)
        {
            float PositionX = Player.transform.position.x;
            float PositionY = Player.transform.position.y;
            GameObject Item = (GameObject)Instantiate(GameManager.Inventory[Number], new Vector3(PositionX, PositionY + 1, 0), Quaternion.identity);
            Item.SetActive(true);
            GameManager.Inventory[Number] = null;
            inventoryItem.GetComponent<Image>().sprite = null;
        }
    }
}