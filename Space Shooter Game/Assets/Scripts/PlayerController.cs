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
    [SerializeField] int speed;   // Bu de�i�kene Unity'den eri�mek istiyorum. Lakin ba�ka bir yerden de eri�ilmesini istemiyorsam;
    [SerializeField] int tilt;
    [SerializeField] float fireRate;
    [SerializeField] float nextFire;

    public GameObject shot;
    public GameObject shotPos;
    public Boundary boundary;

    Rigidbody physic;
    float zaman = 0.5f;
    

    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()  //Fizik i�lermleriden fixedupdate kullan�lmaktad�r.
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movehorizontal, 0f, movevertical);
        physic.velocity = movement * speed;
        //transform.Translate(horizontal * Time.deltaTime * hiz, 0f, vertical * Time.deltaTime * hiz); 
        //Performans kayb� olaca�� i�in bunun yerine Rigidbody-Velocity kullan�yoruz.

        Vector3 position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),  //Kendi pozisyonu, min gidebilece�i x noktas�, max gidebilece�i x noktas�
            0.832f,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax));
        transform.position = position;
        // S�n�rlar� Collider yapmadan kod ile bu �ekilde yapabiliyoruz.

        transform.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt);  // Sa�a-sola e�im vererek hareket ettirme kodu.

       

    }
    private void Update()
    {
        //Debug.Log(Time.time);
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;  // bu de�er zamandan her zaman 0.25 kadar b�y�k olaca�� i�in saniyede 4 defa ate� edebilecek.
            Instantiate(shot, shotPos.transform.position, shotPos.transform.rotation);
            
        }
    }



}
