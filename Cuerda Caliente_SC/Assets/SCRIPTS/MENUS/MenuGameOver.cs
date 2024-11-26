using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public AudioClip sonidoGameOver; // Clip de audio para el sonido de Game Over
    private AudioSource audioSource; // AudioSource para reproducir el sonido de Game Over
    private bool gameOverActivado = false; // Verificar si el menú Game Over ya está activo

    void Start()
    {
        // Mostrar y desbloquear el cursor
        Cursor.visible = true; // Hace visible el cursor
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor para moverse libremente

        // Añadir un AudioSource para reproducir el sonido de Game Over
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sonidoGameOver;
        audioSource.playOnAwake = false; // No reproducir al iniciar

        // Detener todos los sonidos al activar el menú de Game Over
        DetenerSonidosExcepto(audioSource); // Detener otros sonidos, excepto el de Game Over

        // Reproducir el sonido de Game Over solo una vez
        if (!gameOverActivado)
        {
            audioSource.Play();
            gameOverActivado = true; // Marcar que el Game Over ha sido activado
        }
    }

    public void Reiniciar()
    {
        // Reanudar todos los sonidos al reiniciar
        ReanudarTodosLosSonidos();

        // Cargar de nuevo la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverActivado = false; // Reiniciar el estado de Game Over
    }

    public void MenuInicial(string nombre)
    {
        // Reanudar todos los sonidos al ir al menú inicial
        ReanudarTodosLosSonidos();

        SceneManager.LoadScene(nombre);
    }

    // Método para detener todos los sonidos excepto el de Game Over
    private void DetenerSonidosExcepto(AudioSource fuenteExcepcion)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            // Si no es el AudioSource de Game Over, pausar
            if (audioSource != fuenteExcepcion)
            {
                audioSource.Pause(); // Pausar cada AudioSource
            }
        }
    }

    // Método para reanudar todos los sonidos
    private void ReanudarTodosLosSonidos()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause(); // Reanudar cada AudioSource
        }
    }
}


