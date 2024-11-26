using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosAutomaticos : MonoBehaviour
{
    // Start is called before the first frame update
    public float altura = 8f;

    public bool Suelo = true;

    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;

    }
    private void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.CompareTag("Suelo")){
            rigidbody.AddForce(Vector3.up*altura,ForceMode.Impulse);
            Debug.Log("Npc en Suelo");
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("Suelo")){
            Debug.Log("Npc en el Aire");
            Suelo = false;
        }       
    }
    // Update is called once per frame


    void Update()
    {
        
    }
}
