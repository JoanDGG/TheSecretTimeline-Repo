using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        // Cambiar a la escena 'EscenaTransicion'
        SceneManager.LoadScene("Intro");
    }

    public void Begin()
    {
        SceneManager.LoadScene("Apocalipsis");
    }

    public void End()
    {
        SceneManager.LoadScene("Final");
    }

    public void HowTo()
    {
        // Cambiar a la escena 'Log In'
        SceneManager.LoadScene("HowToPlay");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
