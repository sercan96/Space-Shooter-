using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    
    Rigidbody physic;
    [SerializeField] int speed;   // Bu deðiþkene Unity'den eriþmek istiyorum. Lakin baþka bir yerden de eriþilmesini istemiyorsam;
    [SerializeField] int tilt;
    public Boundary boundary;
    
    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()  //Fizik iþlermleriden fixedupdate kullanýlmaktadýr.
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movehorizontal, 0f, movevertical);
        physic.velocity = movement * speed;
        //transform.Translate(horizontal * Time.deltaTime * hiz, 0f, vertical * Time.deltaTime * hiz); 
        //Performans kaybý olacaðý için bunun yerine Rigidbody-Velocity kullanýyoruz.

        Vector3 position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),  //Kendi pozisyonu, min gidebileceði x noktasý, max gidebileceði x noktasý
            0.832f,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax));
        transform.position = position;
        // Sýnýrlarý Collider yapmadan kod ile bu þekilde yapabiliyoruz.

        transform.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt);  // Saða-sola eðim vererek hareket ettirme kodu.


    }
}
