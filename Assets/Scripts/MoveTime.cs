using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTime : MonoBehaviour
{

    private bool Near;
    private int Time;
    public GameObject[] TimeObjects = new GameObject[3];
    private Text Instructions;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i <= 3; i++)
        {
            if (this.gameObject.name.Contains(TimeObjects[i].name))
            {
                Time = i;
                break;
            }
        }
        Instructions = GameObject.Find("Instructions").GetComponent<Text>();
        Near = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Near)
        {
            if (Input.GetKeyDown("z") && Time >= 1) // 1 or 2 / Present or Future
            {
                //print("Going back in time...");
                Time--;
                Instantiate(TimeObjects[Time], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                Destroy(this.gameObject);
            }
            else if (Input.GetKeyDown("c") && Time <= 1) // 0 or 1 / Past or Present
            {
                //print("Going forward in time...");
                Time++;
                Instantiate(TimeObjects[Time], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Near = true;
            Instructions.text = "Press z to rewind time\nPress c to fastforward time";
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Near = false;
            Instructions.text = "";
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!Near && other.CompareTag("Player"))
        {
            Near = true;
            Instructions.text = "Press z to rewind time\nPress c to fastforward time";
        }
    }
}
