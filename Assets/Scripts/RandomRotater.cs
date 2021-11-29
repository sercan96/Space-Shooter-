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
        physic.angularVelocity = Random.insideUnitSphere * speed; //Hýzý verdiðimiz için Start'a yazmamýz yeterli oluyor. [0.2, 0.6, 0.4] olacak.
    }

    
   
}
