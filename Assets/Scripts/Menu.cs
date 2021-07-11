using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        // Cambiar a la escena 'EscenaTransicion'
        //SceneManager.LoadScene("Escena");
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
