using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceTexto : MonoBehaviour
{

    private Image Imagen;
    public Text texto;

    void Start()
    {
        Imagen = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    public void Siguiente()
    {
        if(gameObject.GetComponent<Image>().enabled)
        {
            Imagen.enabled = true;
            gameObject.GetComponent<Image>().enabled = false;
        }
    }

    public void CambiarTexto(string text)
    {
        texto.text = text;
    }
}