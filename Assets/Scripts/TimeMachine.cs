using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeMachine : MonoBehaviour
{

    public GameObject Phone;
    public GameObject apps;
    public GameObject Notes;
    public GameObject TimePeriods;
    private bool PhoneShowing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool input = Input.GetKeyDown("t");
        if (input && PhoneShowing)
        {
            PhoneShowing = false;
            Phone.SetActive(PhoneShowing);
        }
        else if(input && !PhoneShowing)
        {
            PhoneShowing = true;
            Phone.SetActive(PhoneShowing);
        }
    }

    public void TimeTravel(int value)
    {
        GameObject.Find("Player").gameObject.GetComponent<Movement>().SaveLocationPlayer();
        print("Traveling...");
        GameManager.scene = value + 1;
        if(value == 3)
        {
            if (!GameManager.story1)
            {
                GameManager.scene = 4;
                SceneManager.LoadScene("Prehistoria_1");
            }
            else
            {
                GameManager.scene = 9;
                SceneManager.LoadScene("Prehistoria_2");
            }
        }
        else
        {
            SceneManager.LoadScene(value);
        }
    }

    public void Apps(int value)
    {
        switch (value)
        {
            case 0: //Clock
                apps.SetActive(false);
                TimePeriods.SetActive(true);
                break;
            case 1: //Notes
                apps.SetActive(false);
                Notes.SetActive(true);
                break;
            case 2: //Back to Apps
                apps.SetActive(true);
                TimePeriods.SetActive(false);
                Notes.SetActive(false);
                break;
        }
    }
}
