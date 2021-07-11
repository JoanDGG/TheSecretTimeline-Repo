using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Player").gameObject.GetComponent<Movement>().SaveLocationPlayer();

        if (gameObject.name.Contains("Prehistoric"))
        {
            if(!GameManager.story1)
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

        else if (gameObject.name.Contains("80"))
        {
            GameManager.scene = 5;
            SceneManager.LoadScene("80s");
        }

        else if (gameObject.name.Contains("WWII"))
        {
            GameManager.scene = 6;
            SceneManager.LoadScene("WWII");
        }

        else if (gameObject.name.Contains("Covid"))
        {
            GameManager.scene = 7;
            SceneManager.LoadScene("Covid");
        }

        else if (gameObject.name.Contains("Future"))
        {
            GameManager.scene = 8;
            SceneManager.LoadScene("Futurama");
        }

        else if (gameObject.name.Contains("Apocalipsis"))
        {
            GameManager.scene = 2;
            SceneManager.LoadScene("Apocalipsis");
        }

        else if (gameObject.name.Contains("Lab"))
        {
            GameManager.scene = 3;
            SceneManager.LoadScene("Puertas");
        }
    }
}
