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
        print("Traveling...");
        SceneManager.LoadScene(value);
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
