using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMachine : MonoBehaviour
{

    public Text Date;
    public GameObject Phone;
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

    public void Key(int value)
    {
        if(value == -1)
        {
            Date.text = "";
        }
        else if(value == 10)
        {
            print("Traveling to " + Date.text + "...");
            //Scene transition
        }
        else
        {
            Date.text += value.ToString();
        }
    }
}
