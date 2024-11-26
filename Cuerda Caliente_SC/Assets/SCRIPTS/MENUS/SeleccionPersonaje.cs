using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SeleccionPersonaje : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");
        if (index > gameManager.Personajes.Count - 1)
        {
            index = 0;
        }

        CambiarPantalla();
    }

    private void CambiarPantalla()
    {
        // Guardar el �ndice del personaje seleccionado
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = gameManager.Personajes[index].imagen;
        nombre.text = gameManager.Personajes[index].nombre;
    }

    public void SiguientePersonaje()
    {
        if (index == gameManager.Personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    }

    public void AnteriorPersonaje()
    {
        if (index == 0)
        {
            index = gameManager.Personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

