using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pantalla : MonoBehaviour
{
    [SerializeField]
    TextMeshPro Mensaje;

    void Start()
    {
        Mensaje.text = "";
    }

    public void TeclaPresionada(char letra)
    {
        Mensaje.text += letra;
    }
}
