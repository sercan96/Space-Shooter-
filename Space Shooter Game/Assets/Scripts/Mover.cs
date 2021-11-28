using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody physic;
    public float speed;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        physic.velocity = Vector3.forward * speed;
        //transform.Translate(Vector3.forward * speed);
    }
}
