using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physic;
    public int speed;
    void Start()
    {
        
        physic = GetComponent<Rigidbody>();
        physic.angularVelocity = Random.insideUnitSphere * speed; //H�z� verdi�imiz i�in Start'a yazmam�z yeterli oluyor. [0.2, 0.6, 0.4] olacak.
    }

    
   
}
