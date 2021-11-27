using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private float hiz = 5f;
    Rigidbody physic;
    public int speed;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movehorizontal, 0f, movevertical);


        physic.velocity = movement * speed;

        //transform.Translate(horizontal * Time.deltaTime * hiz, 0f, vertical * Time.deltaTime * hiz); 
        //Performans kaybý olacaðý için bunun yerine Rigidbody-Velocity kullanýyoruz.
    }
}
