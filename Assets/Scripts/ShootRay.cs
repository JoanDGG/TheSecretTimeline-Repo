using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootRay : MonoBehaviour
{
    private bool ready = false;
    public GameObject Button;

    // Update is called once per frame
    void Update()
    {
        ready = true;
        for (int i = 0; i < 9; i++)
        {
            if(!gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                ready = false;
                break;
            }
        }
        if (ready)
        {
            Button.SetActive(true);
        }
    }

    public void Shoot()
    {
        SceneManager.LoadScene("Final");
    }
}
