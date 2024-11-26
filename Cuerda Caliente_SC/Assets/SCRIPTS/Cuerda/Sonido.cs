using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    void Start()
    {
        audioSource.AddComponent<AudioSource>();
    }

    // Update is called once per frame

    void OnTriggerEnter()
    {
        audioSource.Play();
    }
    void Update()
    {
        
    }
}
