using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;
    public AudioClip sonidoPausa; // Clip de audio para el sonido de pausa
    private AudioSource audioSource; // AudioSource para reproducir el sonido

    void Start()
    {
        // Asegurarse de que el tiempo est� activo al inicio
        Time.timeScale = 1;

        // Asegurarse de que el men� de pausa est� oculto al inicio
        ObjetoMenuPausa.SetActive(false);

        // Asegurarse de que el cursor est� oculto y bloqueado
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // A�adir un AudioSource y configurarlo
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sonidoPausa;
        audioSource.playOnAwake = false; // No reproducir al iniciar
    }

    public void Update()
    {
        // Verifica si el jugador presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausa)
            {
                Pausar();
            }
            else
            {
                Resumir();
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true);
        Pausa = true;
        Time.timeScale = 0; // Detener el tiempo
        Cursor.visible = true; // Mostrar cursor al pausar
        Cursor.lockState = CursorLockMode.None; // Desbloquear cursor al pausar

        // Reproducir el sonido de pausa
        audioSource.Play();

        // Detener todos los sonidos excepto el sonido de pausa
        DetenerSonidosExcepto(audioSource);
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;
        Time.timeScale = 1; // Reanudar el tiempo
        Cursor.visible = false; // Ocultar cursor al resumir
        Cursor.lockState = CursorLockMode.Locked; // Bloquear cursor al resumir
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1; // Asegurarse de que el tiempo vuelva a la normalidad
        Cursor.visible = false; // Ocultar cursor al reiniciar
        Cursor.lockState = CursorLockMode.Locked; // Bloquear cursor al reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1; // Asegurarse de que el tiempo vuelva a la normalidad al ir al men�
        Cursor.visible = true; // Mostrar cursor al ir al men� principal
        Cursor.lockState = CursorLockMode.None; // Desbloquear cursor al ir al men� principal
        SceneManager.LoadScene(NombreMenu);
    }

    // M�todo para detener todos los sonidos excepto el de pausa
    private void DetenerSonidosExcepto(AudioSource fuenteExcepcion)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            // Si no es el AudioSource de pausa, pausar
            if (audioSource != fuenteExcepcion)
            {
                audioSource.Pause(); // Pausar cada AudioSource
            }
        }
    }
}










