using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProbarBotones : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Titulo;

    public void Presiono1()
    {
        Titulo.text = "Presiono boton 1";
    }

    public void Presiono2()
    {
        Titulo.text = "Presiono boton 2";
    }

    public void Presiono3()
    {
        Titulo.text = "Presiono boton 3";
    }
}
