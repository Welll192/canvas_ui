using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsador : MonoBehaviour
{
    [SerializeField]
    private float Fuerza;
    [SerializeField]
    private float DesplazamientoMaximo;
    [SerializeField]
    private BoxCollider ColliderBase;
    private Rigidbody PulsadorRigid;
    private float PosicionInicial;
    private BoxCollider ColliderPulsador;
    private float PosicionCorregida;
    private bool EstaPresionado;
    [SerializeField]
    private Pantalla ScriptPantalla;
    private bool acabanPresionar;
    [SerializeField]
    private char Letra;

    private void Awake()
    {
        ColliderPulsador = GetComponent<BoxCollider>();
        Physics.IgnoreCollision(ColliderBase, ColliderPulsador);
        PulsadorRigid = GetComponent<Rigidbody>();
        PosicionInicial = transform.localPosition.y;
        EstaPresionado = false;
        acabanPresionar = false;
    }

    private void Update()
    {
        float alturaActual = transform.localPosition.y;
        if (alturaActual >= PosicionInicial)
        {
            PosicionCorregida = PosicionInicial;
            EstaPresionado = false;
        }
        else
        {
            if (alturaActual <= PosicionInicial - DesplazamientoMaximo)
            {
                PosicionCorregida = PosicionInicial - DesplazamientoMaximo;
                PulsadorRigid.AddForce(transform.up * Fuerza * (PosicionInicial - alturaActual));
                if (!EstaPresionado)
                {
                    EstaPresionado = true;
                    acabanPresionar = true;
                }
            }
            else
            {
                PulsadorRigid.AddForce(transform.up * Fuerza * (PosicionInicial - alturaActual));
                PosicionCorregida = alturaActual;
            }
        }
    }

    private void LateUpdate()
    {
        transform.localPosition = new Vector3(0, PosicionCorregida, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        if (acabanPresionar)
        {
            ScriptPantalla.TeclaPresionada(Letra);
            acabanPresionar = false;
        }
    }
}
