using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    void Start()
    {
        // Recuperar el índice del personaje seleccionado
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Debug.Log("Personaje seleccionado: " + indexJugador);  // Para verificar el índice

        // Instanciar el personaje seleccionado con una rotación de -90 grados en Y
        Instantiate(GameManager.Instance.Personajes[indexJugador].personajeJugable,
                    transform.position,
                    Quaternion.Euler(0, -90, 0));  // Rotación en Y de -90 grados
    }
}


