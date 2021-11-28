using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerexplosion;
    private int destroyTime = 2;
    GameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("background"))
        {
            return;   // return yaz�ld�ktan sonra kodu sonland�r�r. Taga �arp�t��� s�rece hi�bir �ey yapmaz.
        }
        if(other.gameObject.tag =="boundary")
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject player = Instantiate(playerexplosion, other.transform.position, other.transform.rotation); // Di�er t�rl� GameObject.Find yapmam�z gerekirdi.
            Destroy(player, destroyTime);
        }
        gc.IncreaseScore();
        GameObject explosionClone =Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosionClone, destroyTime);
        Destroy(other.gameObject);
        
    }
}
