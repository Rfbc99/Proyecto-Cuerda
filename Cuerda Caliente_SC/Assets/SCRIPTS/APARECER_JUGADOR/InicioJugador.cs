using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    void Start()
    {
        // Recuperar el �ndice del personaje seleccionado
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Debug.Log("Personaje seleccionado: " + indexJugador);  // Para verificar el �ndice

        // Instanciar el personaje seleccionado con una rotaci�n de -90 grados en Y
        Instantiate(GameManager.Instance.Personajes[indexJugador].personajeJugable,
                    transform.position,
                    Quaternion.Euler(0, -90, 0));  // Rotaci�n en Y de -90 grados
    }
}


