using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private float hiz = 5f;
    Rigidbody physic;
    public int speed;
    public float xMin, xMax, zMin, zMax;
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

        Vector3 position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),  // kendi pozisyonu, min gidebileceði x noktasý, max gidebileceði x noktasý
            0.832f,
            Mathf.Clamp(transform.position.z, zMin, zMax));
        transform.position = position;
        // Sýnýrlarý Collider yapmadan kod ile bu þekilde yapabiliyoruz.


    }
}
