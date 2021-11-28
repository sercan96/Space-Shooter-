using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerexplosion;
    


  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("background"))
        {
            return;   // return yazýldýktan sonra kodu sonlandýrýr. Taga çarpýtýðý sürece hiçbir þey yapmaz.
        }
        if(other.gameObject.tag =="boundary")
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(playerexplosion, other.transform.position, other.transform.rotation); // Diðer türlü GameObject.Find yapmamýz gerekirdi.
        }
        GameObject explosionClone =Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosionClone, 2);
        Destroy(other.gameObject);
    }
}
