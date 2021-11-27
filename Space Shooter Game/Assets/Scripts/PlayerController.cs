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
        //Performans kayb� olaca�� i�in bunun yerine Rigidbody-Velocity kullan�yoruz.

        Vector3 position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),  // kendi pozisyonu, min gidebilece�i x noktas�, max gidebilece�i x noktas�
            0.832f,
            Mathf.Clamp(transform.position.z, zMin, zMax));
        transform.position = position;
        // S�n�rlar� Collider yapmadan kod ile bu �ekilde yapabiliyoruz.


    }
}
