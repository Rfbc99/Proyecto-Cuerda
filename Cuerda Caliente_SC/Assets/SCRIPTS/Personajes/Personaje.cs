using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
// transform.Translate(Vector3.back*velocidad*Time.deltaTime);
    Rigidbody rigidbody; 

    public bool EstaEnElSuelo = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Suelo")){
            EstaEnElSuelo = true;
            Debug.Log("Esta en el suelo");
        }
    }

    void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("Suelo")){
            EstaEnElSuelo =false;
            Debug.Log("Esta Saliendo");
        }
    }
    // Update is called once per frame
    public float altura=8;
    void Update()
    {
        if(EstaEnElSuelo && Input.GetKeyDown(KeyCode.Space)){
            rigidbody.AddForce(Vector3.up*altura,ForceMode.Impulse);
            EstaEnElSuelo = false;
            Debug.Log("Saltando");
        }
    }
}
