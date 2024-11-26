using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Muerte : MonoBehaviour
{
    // Start is called before the first frame update


    
    public AudioSource audioSource;

    
    public Text Ganador;
    public Canvas canvas;
    
    Camera[] myCams = new Camera[2];

    public Font fuente;
    void Start()
    {
        myCams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myCams[1] = GameObject.FindGameObjectWithTag("Camara2").GetComponent<Camera>();
        myCams[0].enabled = true;
        myCams[1].enabled = false;
         if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en el objeto.");
        }
    }

    // Update is called once per frame
    private string Winner="No hay ganador aun";
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Personajes")){
            audioSource.Play();
            Destroy(other.gameObject);
           
            
        }

       
    }

    void Update()
    {
            GameObject [] Personajes = GameObject.FindGameObjectsWithTag("Personajes");

            Debug.Log(Personajes.Length);


            if(Personajes.Length <= 1){
               
                string UltimoJugador = Personajes[0].name;

                Debug.Log($"El personaje sobrante es: {UltimoJugador}");
                Debug.Log(Personajes.Length);

                myCams[0].enabled = false;
                myCams[1].enabled = true;

                Ganador.text = $"El ganador es el: {UltimoJugador}";
                Ganador.fontSize = 40;
                Ganador.font = fuente;
            }
    }
}
