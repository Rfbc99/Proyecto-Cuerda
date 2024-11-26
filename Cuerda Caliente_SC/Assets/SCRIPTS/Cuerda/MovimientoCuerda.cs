using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCuerda : MonoBehaviour
{
    // Start is called before the first frame update
   public HingeJoint hinge;

    public float velocidadRotacion = -200f;

    public float fuerzaMotor = 50f;

    private Rigidbody rigidbody;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        rigidbody = GetComponent<Rigidbody>();

        JointMotor jointMotor = hinge.motor;

        jointMotor.force = 200f;

        jointMotor.targetVelocity = -200f;
        hinge.motor = jointMotor;
        hinge.useMotor = true;

        jointMotor.targetVelocity = velocidadRotacion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
