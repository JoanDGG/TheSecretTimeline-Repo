using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject CanvasMenu;
    private bool Paused = false;

     void Update () {
         if (Input.GetKeyDown (KeyCode.Escape)) {
             print("escape");
             print(Paused);
             if(Paused == true){
                 Time.timeScale = 1.0f;
                 CanvasMenu.gameObject.SetActive (false);
                 Paused = false;
             } else {
                 Time.timeScale = 0.0f;
                 CanvasMenu.gameObject.SetActive (true);
                 Paused = true;
             }
         }
     }

    public void Reanudar()
    {
        CanvasMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
