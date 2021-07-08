using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name.Contains("Prehistoric"))
        {
            SceneManager.LoadScene("Prehistoria_1");
        }

        else if (gameObject.name.Contains("80"))
        {
            SceneManager.LoadScene("Prehistoria_1");
        }

        else if (gameObject.name.Contains("WWII"))
        {
            SceneManager.LoadScene("Prehistoria_1");
        }

        else if (gameObject.name.Contains("Covid"))
        {
            SceneManager.LoadScene("Prehistoria_1");
        }

        else if (gameObject.name.Contains("Future"))
        {
            SceneManager.LoadScene("Prehistoria_1");
        }

        else if (gameObject.name.Contains("Apocalipsis"))
        {
            SceneManager.LoadScene("Apocalipsis");
        }
    }
}
