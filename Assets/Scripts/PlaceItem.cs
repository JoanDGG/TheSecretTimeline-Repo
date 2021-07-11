using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    public GameObject required;

    public void OnTriggerStay2D(Collider2D other)
    {
        print(other.gameObject.name.Contains(required.name));
        if (other.gameObject.name.Contains(required.name))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            Destroy(other.gameObject);
            
        }
    }
}
